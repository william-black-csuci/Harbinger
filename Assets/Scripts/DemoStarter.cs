using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoStarter : MonoBehaviour
{
    public Combat DemoCombat = new Combat();
	private AICombatant[] AIs = new AICombatant[3];
	private List<Enemy> Enemies = new List<Enemy>();
	
	[SerializeField]
	AIHealthBar AI1Health;
	[SerializeField]
	AIHealthBar AI2Health;
	[SerializeField]
	AIHealthBar AI3Health;
	[SerializeField]
	AIHealthBar E1Health;
	
	[SerializeField]
	private CastBar[] CastBars;
	
	[SerializeField]
	private CPUBar CPUTracker;
	
	private void Start()
	{
		AIs[0] = new Hawking(DemoCombat);
		AIs[1] = new Ada(DemoCombat);
		AIs[2] = new Turing(DemoCombat);
		DemoCombat.AIs = AIs;
		Enemies.Add(new ProcessCleaner(DemoCombat));
		DemoCombat.Enemies = Enemies;
		
		AI1Health.Character = AIs[0];
		AI2Health.Character = AIs[1];
		AI3Health.Character = AIs[2];
		E1Health.Character = Enemies[0];
		
		CastBars[0].Character = AIs[0];
		CastBars[1].Character = AIs[1];
		CastBars[2].Character = AIs[2];
		CastBars[3].Character = Enemies[0];
		
		CPUTracker.CurrentCombat = DemoCombat;
		
		foreach (Combatant character in AIs)
		{
			character.StartCombat(DemoCombat);
		}
		foreach (Combatant character in Enemies)
		{
			character.StartCombat(DemoCombat);
		}
	}
	
	private void Update()
	{
		foreach(Combatant character in AIs)
		{
			character.Tick();
		}
		
		foreach(Combatant character in Enemies)
		{
			character.Tick();
		}
	}
}
