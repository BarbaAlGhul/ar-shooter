using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager Instance { set; get; }
    public GameObject[] levelPrefab;

    private List<GameObject> allBlocks;
    private int currentLevel = 0;
    private bool isGameCompleted = false;

    private void Update()
    {
        if (isGameCompleted)
            ChangeScene("Menu");
    }

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);

        ChangeScene("Menu");
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void OnLevelWasLoaded(int level)
    {
        isGameCompleted = false;

        if(SceneManager.GetActiveScene().name == "Game")
        {
            CreateLevel();
        }
    }

    private void CreateLevel()
    {
        //Instanciar o prefab do nível
        if (currentLevel < levelPrefab.Length)
            Instantiate(levelPrefab[currentLevel]);
        else
            isGameCompleted = true;

        //descobrir quantos blocos há na tela
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
        allBlocks = new List<GameObject>();
        allBlocks.AddRange(blocks);
    }

    public void RemoveBlock(GameObject block)
    {
        if (allBlocks.Find(b => b == block))
            allBlocks.Remove(block);

        if (allBlocks.Count == 0)
            Victory();
    }

    public void Victory()
    {
        currentLevel++;
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
        for (int i = 0; i < blocks.Length; i++)
            DestroyImmediate(blocks[i]);

        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        for (int i = 0; i < bullets.Length; i++)
            DestroyImmediate(bullets[i]);

        CreateLevel();
    }
}
