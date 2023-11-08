using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CastBar : MonoBehaviour
{
	[SerializeField]
	private RectTransform CastMask;
	[SerializeField]
	private int Max;
	[SerializeField]
	private int Min;

	private Vector2 Size;
	public Combatant Character;
	
	void Start()
	{
		Size = CastMask.sizeDelta;
	}
	
    // Update is called once per frame
    void Update()
    {
		if (Character != null)
		{
			Size.y = Mathf.Lerp(Min, Max, Character.TickProgress / Character.TickThreshold);
			CastMask.sizeDelta = Size;
		}
    }
}
