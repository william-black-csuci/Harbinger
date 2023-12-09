using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TargetDisplay : MonoBehaviour
{
	[SerializeField]
	private Image TargetImage;
	[SerializeField]
	private bool Enemy;
	[SerializeField]
	private int combatantIndex;
	[SerializeField]
	private DemoStarter Demo;
	[SerializeField]
	TMP_Text Label;
	
	private Combatant Caster;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Caster == null)
		{
			if (Enemy)
			{
				Caster = Demo.Enemies[combatantIndex];
			}
			else
			{
				Caster = Demo.AIs[combatantIndex];
			}
		}
		
		if (Caster.Targets.Count > 0)
		{
			Debug.Log(Caster.Targets[0].Name);
			TargetImage.sprite = Caster.Targets[0].Portrait;
			Debug.Log(Caster.Targets[0].Portrait);
		}
		
		if (Label != null)
		{
			string name = Caster.Targets[0].Name;
			foreach (Enemy enemy in Demo.Enemies)
			{
				if (enemy.Name == name)
				{
					Label.text = (enemy.Index + 1).ToString();
					break;
				}
			}
		}
    }
}
