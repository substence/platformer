using UnityEngine;
using System.Collections;

public class JumpAbility : Ability
{
	public float jumpSpeed = 800;
	public int maxJumps = 1;
	private uint _jumpCounter = 0;
	
	private void Landed()
	{
		_jumpCounter = 0;
	}
	
	public bool IsJumping()
	{
		return _jumpCounter > 0;
	}
	
	public bool CanJump()
	{
		return _jumpCounter < maxJumps;
	}
	
	override public bool AttemptActivate()
	{
		return CanJump() && base.AttemptActivate();
	}
	
	override protected void OnActivate()
	{
		_jumpCounter++;
		rigidbody2D.AddForce(new Vector3(0, jumpSpeed, 0));
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if(IsJumping() && col.gameObject.tag == "floor")
		{
			Landed();
		}
	}
}
