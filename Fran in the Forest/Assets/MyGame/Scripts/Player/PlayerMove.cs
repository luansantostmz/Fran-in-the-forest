using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{	
	[SerializeField] private float jumpForce;

	PointsManager pointsManager;
	GameControllerDeath gameControllerDeath;
	Rigidbody2D rb;

	private void Start()
	{
		gameControllerDeath = FindObjectOfType<GameControllerDeath>();
		pointsManager = FindAnyObjectByType<PointsManager>();

		rb = GetComponent<Rigidbody2D>();
	}
	public void SetJump(InputAction.CallbackContext value)
	{
		if (!gameControllerDeath.isDie) return;

		Debug.Log("Pulou");
		rb.velocity = Vector2.up * jumpForce;		
	}
}
