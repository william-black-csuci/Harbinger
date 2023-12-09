using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Combatant
{
	public int Index;
	
	protected Enemy(Combat combat, int index) : base(combat)
	{
		Index = index;
		CurrentCombat = combat;
		GetTarget();
	}
	
    protected virtual void GetTarget()
	{
		int highestThreat = CurrentCombat.AIs[0].Threat;
		List<AICombatant> highestThreatCombatant = new List<AICombatant>();
		//CurrentCombat.AIs[0];
		foreach (AICombatant target in CurrentCombat.AIs)
		{
			if (target.Threat > highestThreat)
			{
				highestThreat = target.Threat;
				highestThreatCombatant = new List<AICombatant>();
				highestThreatCombatant.Add(target);
			}
			else if (target.Threat == highestThreat)
			{
				highestThreatCombatant.Add(target);
			}
		}
		
		int randomIndex = Random.Range(0, highestThreatCombatant.Count); // Generate a random index within the list's bounds.
        Targets = new List<Combatant>();
		Targets.Add(highestThreatCombatant[randomIndex]);
	}
	
	protected override Ability GetNextAbility(Combat combat, bool combatStart = false)
	{
		Targets = new List<Combatant>();
		GetTarget();
		return Abilities[0];
	}
}
