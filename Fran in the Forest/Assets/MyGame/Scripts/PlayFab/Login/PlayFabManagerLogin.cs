using PlayFab.ClientModels;
using PlayFab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayFabManagerLogin : MonoBehaviour
{
	public static PlayFabManagerLogin Instance;
	public GameObject nameWindow;
	public TextMeshProUGUI nameInput;

	private void Awake()
	{
		Instance = this;
	}
	void Start()
	{
		nameWindow.SetActive(false);
		Login();
	}


	#region Login
	void Login()
	{
		var request = new LoginWithCustomIDRequest
		{
			CustomId = SystemInfo.deviceUniqueIdentifier,
			CreateAccount = true,
			InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
			{
				GetPlayerProfile = true
			}
		};
		PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);

	}
	private void OnSuccess(LoginResult result)
	{
		Debug.Log("Successfull login/account create!");

		string name = null;

		if (result.InfoResultPayload.PlayerProfile != null) name = result.InfoResultPayload.PlayerProfile.DisplayName;

		if (name == null) nameWindow.SetActive(true);
		else SceneAsyncLoader.Instance.LoadNewScene("GamePlay");
	}

	private void OnError(PlayFabError error)
	{
		Debug.Log("Error while in/creating account!");
		Debug.Log(error.GenerateErrorReport());
	}

	public void SubmitNameButton()
	{
		var request = new UpdateUserTitleDisplayNameRequest
		{
			DisplayName = nameInput.text,
		};
		PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameUpdate, OnError);
	}

	private void OnDisplayNameUpdate(UpdateUserTitleDisplayNameResult result)
	{
		Debug.Log("Updated display name!");
		SceneAsyncLoader.Instance.LoadNewScene("GamePlay");
	}
	#endregion	
}
