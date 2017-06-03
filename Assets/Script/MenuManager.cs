using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

	public void OnPlayButton()
    {
        GameManager.Instance.ChangeScene("Game");
    }
}
