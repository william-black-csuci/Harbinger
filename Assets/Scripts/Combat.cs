using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// holds information relavent to a combat
public class Combat
{
	public AICombatant[] AIs = new AICombatant[3];
	public List<Enemy> Enemies = new List<Enemy>();
	public int CPU = 0;
	public int MaxCPU = 2;
}
