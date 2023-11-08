using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Combatant
{
	protected Enemy(Combat combat) : base(combat)
	{
		CurrentCombat = combat;
		Targets.Add(GetTarget());
	}
	
	protected Sprite Portrait;
	
    protected virtual Combatant GetTarget()
	{
		int highestThreat = CurrentCombat.AIs[0].Threat;
		AICombatant highestThreatCombatant = CurrentCombat.AIs[0];
		foreach (AICombatant target in CurrentCombat.AIs)
		{
			if (target.Threat > highestThreat)
			{
				highestThreat = target.Threat;
				highestThreatCombatant = target;
			}
		}
		
		return highestThreatCombatant;
	}
	
	protected override Ability GetNextAbility(Combat combat, bool combatStart = false)
	{
		Targets = new List<Combatant>();
		Targets.Add(GetTarget());
		return Abilities[0];
	}
}
