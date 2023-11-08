using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessCleaner : Enemy
{
	public ProcessCleaner(Combat combat) : base(combat)
	{
		Portrait = Resources.Load("Abilities/Clean.jpg") as Sprite;
		Abilities.Add(new Clean());
		
		CastingAbility = GetNextAbility(combat, true);
	}
}
