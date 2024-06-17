using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{	
	[SerializeField] private float jumpForce;

	public PointsManager pointsManager;
	public GameControllerDeath gameControllerDeath;
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
		
		rb.velocity = Vector2.up * jumpForce;

		if (value.phase == InputActionPhase.Started)
		{
			pointsManager.taps++;
		}
	}
}
