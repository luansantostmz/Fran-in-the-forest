using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
	public List<Collider2D> collidersList = new List<Collider2D>();
	private void OnTriggerEnter2D(Collider2D col)
	{
		if (collidersList.Contains(col)) return;
		collidersList.Add(col);

		if (col.CompareTag("Spike"))
		{			
			GameEvents.PauseToDie?.Invoke();
		}
		if (col.CompareTag("AddPoints"))
		{			
			GameEvents.AddPoints?.Invoke();
		}
	}
	
}
