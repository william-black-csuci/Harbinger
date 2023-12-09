using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;

public class RunCommand : Command
{
    
	
	private DemoStarter Demo;
	
	public RunCommand()
	{
		RegexString = @"^run [a-zA-Z]{3} [1-4] [1-4]$";
		Demo = GameObject.FindWithTag("demo").GetComponent<DemoStarter>();
	}
	
	protected override void Run(Terminal terminal, string input, bool regexPassed)
	{
		if (!regexPassed)
		{
			terminal.Write("Correct Usage: \"run <AI name> <ability num> <target num>\"");
			terminal.Finish();
			return;
		}
		else
		{
			string name = input.Split(' ')[1].ToUpper();
			string tName;
			//Debug.Log(input.Split(' ')[2]);
			int tIndex = Convert.ToInt32(input.Split(' ')[3]) - 1;
			
			if (Demo.Enemies.Count < tIndex + 1 || Demo.Enemies[tIndex].Health <= 0)
			{
				terminal.Write(String.Format("Target {0} not found.", tIndex + 1));
				terminal.Finish();
				return;
			}
			else 
			{
				tName = Demo.Enemies[tIndex].Name;
			}
			
			string ability;
			int aIndex = Convert.ToInt32(input.Split(' ')[2]) - 1;
			
			foreach(AICombatant ai in Demo.AIs)
			{
				if (ai.Name == name)
				{
					if (ai.Abilities.Count < aIndex + 1)
					{
						terminal.Write(String.Format("Ability {0} not found.", aIndex + 1));
						terminal.Finish();
						return;
					}
					
					ability = ai.Abilities[aIndex].Name;
					
					ai.nextAbilityIndex = aIndex;
					//ai.nextTarget = tIndex;
					terminal.Write(String.Format("{0} now targeting {1}({2}) with {3}({4}).", ai.Name, tName, tIndex + 1, ability, aIndex + 1));
					terminal.Finish();
					return;
				}
			}
			terminal.Write(String.Format("{0} not found.", name));
			terminal.Finish();
		}
	}
}
