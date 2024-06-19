using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI textGold;
	public int gold;


	private void OnEnable()
	{
		GameEvents.AddGold += AddGold;
	}
	private void OnDisable()
	{
		GameEvents.AddGold -= AddGold;
	}

	private void Start()
	{
		textGold.text = gold.ToString();
	}
	private void Update()
	{
		textGold.text = gold.ToString();
	}
	void AddGold()
	{
		Debug.Log("Gold");
		gold++;
		textGold.text = gold.ToString();
	}
}
