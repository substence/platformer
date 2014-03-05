using UnityEngine;
using System.Collections;

public class HorizontalMovementAbility : Ability
{
	public float movementSpeed = 10;
		
	public void Move(Vector2 direction)
	{
		rigidbody2D.AddForce(direction * movementSpeed);
	}

	override protected void OnActivate()
	{
	}
}
