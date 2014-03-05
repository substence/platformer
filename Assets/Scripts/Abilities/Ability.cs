using UnityEngine;
using System.Collections;

public abstract class Ability : MonoBehaviour
{
	public string key;
	public float rechargeDuration = 5.0f;
	protected float _lastActivatedTime;

	public void Start()
	{
		_lastActivatedTime = -rechargeDuration;
	}
	
	public bool IsRecharging()
	{
		return Time.time < (_lastActivatedTime + rechargeDuration);
	}
	
	public float GetRechargeTimeRemaining()
	{
		return rechargeDuration - (Time.time - _lastActivatedTime);
	}
	
	public virtual bool AttemptActivate()
	{
		if (IsRecharging())
		{
			return false;
		}
		Activate();
		return true;
	}
	
	public void Activate()
	{
		OnActivate();
		_lastActivatedTime = Time.time;
	}
	
	protected abstract void OnActivate();
}
