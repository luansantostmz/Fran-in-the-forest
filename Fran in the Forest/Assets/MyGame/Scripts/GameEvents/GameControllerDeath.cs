using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameControllerDeath : MonoBehaviour
{
	public bool isDie = false;

	public GameObject screenDeath;

	PlayFabManager playFabManager;
	PointsManager pointsManager;	

	private void OnEnable()
	{
		GameEvents.PauseToDie += ActionNormal;
	}
	private void OnDisable()
	{		
		GameEvents.PauseToDie -= ActionNormal;
	}

	private void Start()
	{
		playFabManager = FindObjectOfType<PlayFabManager>();
		pointsManager = FindObjectOfType<PointsManager>();

		screenDeath.SetActive(false);
	}
	public void ActionNormal()
	{
		isDie = false;
		screenDeath.SetActive(true);

		playFabManager.SendLeaderboardScore(pointsManager.points);
	}
}
