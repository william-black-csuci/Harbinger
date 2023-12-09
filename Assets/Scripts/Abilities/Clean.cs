using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clean : Ability
{
	public Clean()
	{
		TickThreshold = 5f;
		Name = "Clean";
	}
	
    protected override void CastTick(Combat combat, Combatant caster, int authority, List<Combatant> targets)
	{
		targets[0].Health -= authority * 15;
		DoneCasting = true;
	}
}
