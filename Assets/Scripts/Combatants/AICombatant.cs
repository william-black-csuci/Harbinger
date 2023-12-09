using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// player "controlled" combatant
public abstract class AICombatant : Combatant
{	
	// max of a resource used by player combatants
	public const int MAX_THREAT = 4;
	public int Power { get; protected set; }
	public int nextAbilityIndex = 0;
	public int nextTarget = 0;
	
	// resource
	private int _threat;
	public int Threat
	{
		get {return _threat;}
		
		// maintain within limits
		set
		{
			if (value < 0)
			{
				_threat = 0;
			}
			else if (value > MAX_THREAT)
			{
				_threat = MAX_THREAT;
			}
			else
			{
				_threat = value;
			}
		}
	}
	
	// constructor
	protected AICombatant(Combat combat) : base(combat)
	{
		// start threat at 0
		Threat = 0;
	}
	
	// select ability to use
	protected override Ability GetNextAbility(Combat combat, bool combatStart = false)
	{
		//Targets = new List<Combatant>();
		//Targets.Add(CurrentCombat.Enemies[nextTarget]);
		return Abilities[nextAbilityIndex];
	}
	
	// prepare for combat
	public override void StartCombat(Combat combat)
	{
		// reset threat
		Threat = 0;
		
		Targets = combat.Enemies.ConvertAll(Enemy => (Combatant)Enemy);;
		
		// parent method
		base.StartCombat(combat);
	}
}
