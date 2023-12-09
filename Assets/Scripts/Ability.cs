using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// an ability for a combatant to cast
public abstract class Ability
{
	// time for the spell to be casted
    public float TickThreshold { get; protected set; }
	protected float CastedTime; // how long the character is unable to do anything after cast bar completes
	protected bool DoneCasting = false;	// bool for determining if spell is both casted and completed
	public int CPU = 0;
	public string Name;
	
	// runs once per frame when cast bar is full (until false is returned)
	public bool Cast(Combat combat, Combatant caster, int authority, List<Combatant> targets)
	{
		// if casting is complete, finish
		if (DoneCasting)
		{
			DoneCasting = false;
			return false;
		}
		else
		{
			// tick the ability's effects
			CastTick(combat, caster, authority, targets);
			return true;
		}
	}
	
	// tick the ability's effects
	protected abstract void CastTick(Combat combat, Combatant caster, int authority, List<Combatant> targets);
	
	protected void FinishCast()
	{
		DoneCasting = true;
	}
}
