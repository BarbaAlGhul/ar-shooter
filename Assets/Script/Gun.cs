using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour 
{

	public GameObject bulletPrefab; //objeto que é a bala que será atirada
    public Transform spawnObject; //objeto que ficará na ponta da arma, de onde a bala será disparada

	private void Update()
	{
		if (Input.GetMouseButtonDown (0)) //quando o botão esquerdo do mouse é pressionado ou toque simples no touch
		{
            //instanciando o objeto para assumir a posição e a rotação da arma
			GameObject go = Instantiate (bulletPrefab, spawnObject.position, spawnObject.rotation) as GameObject;
            //faz o disparo do tiro, adicionando uma força nele (o método VelocityChange ignora a massa do objeto)
            //no nosso caso, fez o disparo ficar melhor
			go.GetComponent<Rigidbody> ().AddForce (transform.forward * 30, ForceMode.VelocityChange);
		}
	}
}
