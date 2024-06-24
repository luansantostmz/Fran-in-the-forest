using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneAsyncLoader : MonoBehaviour
{
	public static SceneAsyncLoader Instance;


	public Slider progressBar;
	public float minimumLoadingTime = 1f;


	private void Awake()
	{		
		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
		}
		else
		{
			Instance = this;			
		}
	}

	
	public void LoadNewScene(string sceneName)
	{
		StartCoroutine(LoadSceneAsync(sceneName));
	}
	
	private IEnumerator LoadSceneAsync(string sceneName)
	{
		float startTime = Time.time;
		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
		
		asyncLoad.allowSceneActivation = false;
		
		while (!asyncLoad.isDone)
		{
			//progressBar.value = asyncLoad.progress;		

			if (asyncLoad.progress >= 0.9f)
			{
				progressBar.value = 1.0f; 
				
				if (Time.time - startTime >= minimumLoadingTime)
				{					
					asyncLoad.allowSceneActivation = true;
				}
			}

			yield return null;
		}
	}
}
