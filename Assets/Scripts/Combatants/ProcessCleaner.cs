using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProcessCleaner : Enemy
{
	public ProcessCleaner(Combat combat, int index) : base(combat, index)
	{
		Name = "Process Cleaner";
		Portrait = Resources.Load<Sprite>("Portraits/process cleaner");
		Abilities.Add(new Clean());
		
		CastingAbility = GetNextAbility(combat, true);
	}
}
