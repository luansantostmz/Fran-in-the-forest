using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;

public class LeaderboardUIManager : MonoBehaviour
{
	public GameObject playerPrefab;
	public Transform playersParent;

	private void OnEnable()
	{
		PlayFabManager.Instance.GetLeaderboardScore(OnLeaderboardGetScore);
	}

	private void OnLeaderboardGetScore(GetLeaderboardResult result)
	{
		foreach (var item in result.Leaderboard)
		{
			GameObject newPlayer = Instantiate(playerPrefab, playersParent);
			TextMeshProUGUI[] texts = newPlayer.GetComponentsInChildren<TextMeshProUGUI>();
			texts[0].text = (item.Position + 1).ToString();
			texts[1].text = item.DisplayName;
			texts[2].text = item.StatValue.ToString();

			Debug.Log(string.Format("Place: {0} / ID:{1} / Score:{2}", item.Position, item.PlayFabId, item.StatValue));
		}
	}
}
