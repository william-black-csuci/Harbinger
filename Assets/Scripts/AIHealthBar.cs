using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AIHealthBar : MonoBehaviour
{
	[SerializeField]
	private RectTransform HealthMask;
	[SerializeField]
	private int Max;
	[SerializeField]
	private int Min;
	[SerializeField]
	private TMP_Text HealthText;

	private Vector2 Size;
	public Combatant Character;
	
	void Start()
	{
		Size = HealthMask.sizeDelta;
	}
	
    // Update is called once per frame
    void Update()
    {
		if (Character != null)
		{
			Size.y = Mathf.Lerp(Min, Max, (float)Character.Health / (float)Character.MaxHealth);
			HealthMask.sizeDelta = Size;
			
			if (HealthText != null)
			{
				HealthText.text = Character.Health.ToString() + "/" + Character.MaxHealth.ToString();
			}
		}
    }
}
