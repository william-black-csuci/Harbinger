using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunCommand : Command
{
    
	
	private DemoStarter Demo;
	
	public RunCommand()
	{
		RegexString = @"^run [a-zA-Z]{3} [1-4] [1-4]$";
		//Demo = Transform.FindWithTag("demo").GetComponent<DemoStarter>();
	}
	
	protected override void Run(Terminal terminal, string input, bool regexPassed)
	{
		if (!regexPassed)
		{
			terminal.Write("Correct Usage: \"run <AI name> <ability num> <target num>\"");
			terminal.Finish();
		}
		else
		{
			//foreach (AICombatant in 
		}
	}
}
