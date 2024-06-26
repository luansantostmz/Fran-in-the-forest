using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
					 public int points;
	[SerializeField] private TextMeshProUGUI textPoints;

	private void OnEnable()
	{
		GameEvents.AddPoints += AddPoints;
	}
	private void OnDisable()
	{
		GameEvents.AddPoints -= AddPoints;
	}

	private void Start()
	{
		textPoints.text = points.ToString();
	}

	void AddPoints() 
	{
		Debug.Log("AAA");
		points++;
		textPoints.text = points.ToString();
	}
}
