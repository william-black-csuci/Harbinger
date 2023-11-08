using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;

public abstract class Command
{
    protected string RegexString;
	
	public void Parse(Terminal terminal, string input)
	{
		Run(terminal, input, Test(input));
	}
	
	private bool Test(string input)
	{
		return Regex.IsMatch(input, RegexString);
	}
	
	protected abstract void Run(Terminal terminal, string input, bool regexPassed);
}
