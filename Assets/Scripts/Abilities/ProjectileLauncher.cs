using UnityEngine;
using System.Collections;

public class ProjectileLauncher : Ability
{
	public Transform spawnPoint;
	public GameObject projectile;
	public float launchForce;
	protected GameObject instancedProjectile;
	
	override protected void OnActivate()
	{
		Transform weaponTransform = transform; //a weapon should theroeticaly have it's own position, but for now lets just use our owners position
		
		instancedProjectile = Instantiate(projectile, spawnPoint.position, weaponTransform.rotation) as GameObject;
		instancedProjectile.rigidbody.AddForce(transform.TransformDirection(Vector3.forward)* launchForce);
		
		//CollisionNotifier notifier = instancedProjectile.AddComponent<CollisionNotifier>();
		//notifier.notifiee = this;
	}	
	
    void OnCollisionEnter(Collision collision)
	{
		if (collision != null &&
			collision.rigidbody && 
			collision.rigidbody != rigidbody && 
			collision.rigidbody != instancedProjectile.rigidbody)
		{
			Debug.Log(collision.rigidbody);
			Destroy(instancedProjectile);
		}
		//other.rigidbody.AddForce(transform.TransformDirection(Vector3.forward) * force);
	}
}
