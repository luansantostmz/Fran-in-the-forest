using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObjectOK : MonoBehaviour
{
	public GameObject player;

	private void Start()
	{
		player.SetActive(false);
	}
	public void Destoy() 
    {
        Destroy(gameObject);
    }
	public void DestoyAndGo()
	{		
		player.SetActive(true);
		Destroy(gameObject);
	}
}
