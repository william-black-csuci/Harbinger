using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// a player controlled combatant that reduces targets' cast timers when attacking
public class Ada : AICombatant
{	
	private const float SETBACK_TIME = 2f;

    public Ada(Combat combat) : base(combat)
	{
		Name = "ADA";
		Portrait = Resources.Load<Sprite>("Portraits/ai1");
		
		for (int i = 0; i < 4; i++)
		{
			Abilities.Add(new Brute());
		}
		// set up set back skill
		CastingComplete.AddListener(SetBack);
		Efficiency = 2;
		
		CastingAbility = GetNextAbility(combat, true);
	}
	
	// when a cast finishes, reduce the targets' cast timers by a fixed amount
	private void SetBack()
	{
		foreach(Combatant target in Targets)
		{
			if (!target.Casting)
			{
				target.TickProgress -= SETBACK_TIME;
			}
		}
	}
}
