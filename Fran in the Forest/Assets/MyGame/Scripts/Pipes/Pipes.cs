using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
	[SerializeField] float speed;

	public SpawnPipes pipes;
	public GameControllerDeath GameControllerDeath;
	private void Start()
	{
		GameControllerDeath = FindObjectOfType<GameControllerDeath>();
		pipes = FindObjectOfType<SpawnPipes>();
	}

	public void Update()
	{
		if (!GameControllerDeath.isDie) return;

		transform.position += Vector3.left * speed * pipes.increaseSpeed * Time.deltaTime;		
	}
}
