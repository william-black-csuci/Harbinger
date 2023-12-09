using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoStarter : MonoBehaviour
{
    public Combat DemoCombat = new Combat();
	public AICombatant[] AIs = new AICombatant[3];
	public List<Enemy> Enemies = new List<Enemy>();
	
	[SerializeField]
	AIHealthBar AI1Health;
	[SerializeField]
	AIHealthBar AI2Health;
	[SerializeField]
	AIHealthBar AI3Health;
	[SerializeField]
	AIHealthBar E1Health;
	[SerializeField]
	AIHealthBar E2Health;
	[SerializeField]
	AIHealthBar E3Health;
	[SerializeField]
	AIHealthBar E4Health;
	
	[SerializeField]
	private CastBar[] CastBars;
	
	[SerializeField]
	private CPUBar CPUTracker;
	
	private void Start()
	{
		AIs[0] = new Ada(DemoCombat);
		AIs[1] = new Turing(DemoCombat);
		AIs[2] = new Hawking(DemoCombat);
		DemoCombat.AIs = AIs;
		Enemies.Add(new ProcessCleaner(DemoCombat, 0));
		Enemies.Add(new ProcessCleaner(DemoCombat, 1));
		Enemies.Add(new ProcessCleaner(DemoCombat, 2));
		Enemies.Add(new ProcessCleaner(DemoCombat, 3));
		DemoCombat.Enemies = Enemies;
		
		AI1Health.Character = AIs[0];
		AI2Health.Character = AIs[1];
		AI3Health.Character = AIs[2];
		E1Health.Character = Enemies[0];
		E2Health.Character = Enemies[1];
		E3Health.Character = Enemies[2];
		E4Health.Character = Enemies[3];
		
		CastBars[0].Character = AIs[0];
		CastBars[1].Character = AIs[1];
		CastBars[2].Character = AIs[2];
		CastBars[3].Character = Enemies[0];
		CastBars[4].Character = Enemies[1];
		CastBars[5].Character = Enemies[2];
		CastBars[6].Character = Enemies[3];
		
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
