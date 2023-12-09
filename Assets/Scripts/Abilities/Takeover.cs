using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Takeover : Ability
{
	private AICombatant Caster;
	
	public new int CPU
	{
		get
		{
			if (Caster == null)
			{
				foreach (AICombatant ai in GameObject.FindWithTag("demo").GetComponent<DemoStarter>().AIs)
				{
					if (ai.Name == "HWK")
					{
						Caster = ai;
						break;
					}
				}
			}
			
			if (Caster.Threat == 0)
			{
				return 0;
			}
			else if (Caster.Threat < 3)
			{
				return 1;
			}
			else if (Caster.Threat < 5)
			{
				return 2;
			}
			else
			{
				return 3;
			}
		}
		
		private set {;}
	}
	
    public Takeover()
	{
		TickThreshold = 10f;
		Name = "Takeover";
	}
	
    protected override void CastTick(Combat combat, Combatant caster, int authority, List<Combatant> targets)
	{
		targets[0].Health -= authority * 10 * CPU;
		DoneCasting = true;
	}
}
