using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;
using UnityEngine.UI;
using TMPro;

public class PlayFabManager : MonoBehaviour
{

	public static PlayFabManager Instance;


	private void Awake()
	{
		Instance = this;
	}
	void Start()
    {
        Login();
	}

	#region Login
    void Login() 
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);

    }
	private void OnSuccess(LoginResult result)
	{
        Debug.Log("Successfull login/account create!");
	}

	private void OnError(PlayFabError error)
	{
		Debug.Log("Error while in/creating account!");
        Debug.Log(error.GenerateErrorReport());
	}
	#endregion
	#region Send Leaderboard
	public void SendLeaderboardScore(int score) 
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate> 
            {
                new StatisticUpdate 
                {
                    StatisticName = "Score", Value = score                   
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdateScore, OnErrorSendScoreTaps);
	}
	void OnLeaderboardUpdateScore(UpdatePlayerStatisticsResult result)
	{
		Debug.Log("Succesfull leaderboard score sent");
	}
	public void SendLeaderboardTaps(int taps)
	{
		var request = new UpdatePlayerStatisticsRequest
		{
			Statistics = new List<StatisticUpdate>
			{
				new StatisticUpdate
				{
					StatisticName = "Taps", Value = taps
				}
			}
		};
		PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardTapsUpdate, OnErrorSendScoreTaps);
	}

	void OnLeaderboardTapsUpdate(UpdatePlayerStatisticsResult result)
	{
		Debug.Log("Succesfull leaderboard taps sent");
	}
	private void OnErrorSendScoreTaps(PlayFabError error)
	{
		Debug.Log("Error while Taps/Score account!");
		Debug.Log(error.GenerateErrorReport());
	}
	#endregion
	#region Get Leaderboard
	public  void GetLeaderboardScore(Action<GetLeaderboardResult> resultCallBack) 
	{
		var request = new GetLeaderboardRequest
		{
			StatisticName = "Score",
			StartPosition = 1,
			MaxResultsCount = 10
		};
		PlayFabClientAPI.GetLeaderboard(request, resultCallBack, OnErrorGetScoreTaps);
	}	

	private void OnErrorGetScoreTaps(PlayFabError error)
	{
		Debug.Log("Error get score tap");
		Debug.Log(error.GenerateErrorReport());
	}
	#endregion

}
