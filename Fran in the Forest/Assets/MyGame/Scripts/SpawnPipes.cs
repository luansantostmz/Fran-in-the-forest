using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPipes : MonoBehaviour
{
	public GameObject pipe;

	public float height;
	public float maxTime;
	public float timer;


	[Header("Speed pipes")]
	[SerializeField] private float timeToIncreaseSpeed;
	[SerializeField] private float maxTimeIncreaseSpeed;
	                 public float increaseSpeed;
	[SerializeField] private float timerIncreaseSpeed;



	public GameControllerDeath GameControllerDeath;
	private void Start()
	{
		GameControllerDeath = FindObjectOfType<GameControllerDeath>();
		GameObject newPipe = Instantiate(pipe);
		newPipe.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
	}

	private void Update()
	{		
		if (!GameControllerDeath.isDie) return;
		//colocar algo para parar quando o personagem morrer
		spawnPipes();
		IncreaseSpeedPipe();
		ControlSpawnSpeed();
	}

	void spawnPipes() 
	{
		if (timer > maxTime)
		{
			GameObject newPipe = Instantiate(pipe);
			newPipe.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
			Destroy(newPipe, 10f);
			timer = 0;
		}

		timer += Time.deltaTime;
	}
	void IncreaseSpeedPipe() 
	{
		if (timerIncreaseSpeed > maxTimeIncreaseSpeed)
		{
			increaseSpeed += 0.05f;
			timerIncreaseSpeed = 0;
		}

		timerIncreaseSpeed += Time.deltaTime;
	}

	void ControlSpawnSpeed() 
	{
		if (increaseSpeed > 1.6 && increaseSpeed < 1.7) maxTime = 2;
		else if (increaseSpeed > 2.4 && increaseSpeed < 2.5) maxTime = 1;
		else if (increaseSpeed > 5.8 && increaseSpeed < 5.9) maxTime = 0.5f;
		else if (increaseSpeed > 7.2 && increaseSpeed < 7.3) maxTime = 0.4f;
	}


}
