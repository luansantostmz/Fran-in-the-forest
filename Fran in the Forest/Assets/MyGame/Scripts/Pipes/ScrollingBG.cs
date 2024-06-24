using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingBG : MonoBehaviour
{
	[SerializeField] private RawImage image;
    [SerializeField] private float speed;
	[SerializeField] private float x;
	[SerializeField] private float y;

	public SpawnPipes pipes;
	public GameControllerDeath GameControllerDeath;
	private void Start()
	{
		GameControllerDeath = FindObjectOfType<GameControllerDeath>();
		pipes = FindObjectOfType<SpawnPipes>();
	}
	private void Update()
	{
		if (!GameControllerDeath.isDie) return;

		image.uvRect = new Rect(image.uvRect.position + new Vector2(x,y) * speed * pipes.increaseSpeed * Time.deltaTime, image.uvRect.size);
	}
}
