using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using System.Threading.Tasks;
using Unity.VisualScripting;

public class LeaderboardUIManager : MonoBehaviour
{

	public GameObject playerPrefab;
	public Transform playersParent;

	

	async void OnEnable() 
	{
		var leaderboardResult = await PlayFabManager.Instance.GetLeaderboardScore();
		OnLeaderboardGetScore(leaderboardResult);
		Debug.Log("*******" +leaderboardResult);
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
	private Task WaitForPlayFabManager()
	{
		return Task.Run(() =>
		{
			// Aguarda até que a instância do PlayFabManager esteja carregada
			while (PlayFabManager.Instance == null)
			{
				Task.Delay(100).Wait(); // espera 100ms antes de verificar novamente
			}
		});
	}
}
