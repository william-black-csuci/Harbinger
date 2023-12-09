using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// a player controlled combatant with shielding skills
public class Turing : AICombatant
{
	private const int BASE_SHIELD = 300;
	
    public Turing(Combat combat) : base(combat)
	{
		Name = "TUR";
		Portrait = Resources.Load<Sprite>("Portraits/ai2");
		
		for (int i = 0; i < 4; i++)
		{
			Abilities.Add(new Brute());
		}
		// set up shielding skill
		CastingComplete.AddListener(ShieldAlly);
		Authority = 2;
		
		CastingAbility = GetNextAbility(combat, true);
	}
	
	// when a cast finishes, shield ally targets
	private void ShieldAlly()
	{
		foreach (Combatant target in Targets)
		{
			if (target.Shield < BASE_SHIELD * Power)
			{
				target.Shield += BASE_SHIELD * Power;
			}
		}
	}
}
