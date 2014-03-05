using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{	
	public GameObject actor;
	[System.NonSerialized]
	private bool _isLocked;
	
	public void Start()
	{
		if (!actor)
		{
			actor = GameObject.FindGameObjectWithTag("Player");
		}
	}
	
	public bool IsLocked(bool isLocked)
	{
		_isLocked = isLocked;
		return _isLocked; 
	}
	
	void Update ()
	{
		if (actor != null && _isLocked == false)
		{
			HorizontalMovementAbility movement = actor.GetComponent<HorizontalMovementAbility>();
			if (movement != null)
			{
				float horizontalAxis = Input.GetAxis("Horizontal");
				//float verticalAxis = Input.GetAxis("Vertical");
				movement.Move(new Vector3(horizontalAxis, 0, 0));
			}
			Ability[] abilities = actor.GetComponents<Ability>();
			foreach (Ability ability in abilities)
			{
				if (ability.key != null && Input.GetButtonUp(ability.key))
				{
					ability.AttemptActivate();
				}
			}
		}

	}
}
