using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brute : Ability
{
	public Brute()
	{
		CPU = 1;
		TickThreshold = 7f;
	}
	
    protected override void CastTick(Combat combat, Combatant caster, int authority, List<Combatant> targets)
	{
		targets[0].Health -= authority * 20;
		DoneCasting = true;
		if (caster is AICombatant)
		{
			((AICombatant)caster).Threat -= 1;
		}
	}
}

