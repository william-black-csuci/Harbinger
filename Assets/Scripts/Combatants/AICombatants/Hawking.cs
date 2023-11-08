using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// a player controlled combatant with a self heal skill
public class Hawking : AICombatant
{
	// healing amounts mapped to threat level
	private readonly int[] HealingAmounts = {10, 50, 100, 200, 400};
	
    public Hawking(Combat combat) : base(combat)
	{
		for (int i = 0; i < 4; i++)
		{
			Abilities.Add(new Brute());
		}
		
		Stability = 2;
		// set up self healing skill
		CastingComplete.AddListener(Heal);
		CastingAbility = GetNextAbility(combat, true);
	}
	
	// when a cast finishes, heal self based on threat level
	private void Heal()
	{
		Health += HealingAmounts[Threat] * Power;
	}
}
