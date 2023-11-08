using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUBar : MonoBehaviour
{
	[SerializeField]
	private GameObject[] Available;
	[SerializeField]
	private GameObject[] Used;
	
	public Combat CurrentCombat;
	private Vector2 CPUUsage = new Vector2();
	private Vector2 NewCPUUsage = new Vector2();
	
    // Start is called before the first frame update
    void Start()
    {
        CPUUsage.x = CurrentCombat.CPU;
		CPUUsage.y = CurrentCombat.MaxCPU;
    }

    // Update is called once per frame
    void Update()
    {
		if (CurrentCombat == null)
		{
			return;
		}
		
		NewCPUUsage.x = CurrentCombat.CPU;
		NewCPUUsage.y = CurrentCombat.MaxCPU;
		
		if (NewCPUUsage != CPUUsage)
		{
			CPUUsage = NewCPUUsage;
			
			for (int i = 0; i < 9; i++)
			{
				if (i == CPUUsage.x - 1)
				{
					Used[i].SetActive(true);
				}
				else
				{
					Used[i].SetActive(false);
				}
				
				if (i == CPUUsage.y - 1)
				{
					Available[i].SetActive(true);
				}
				else
				{
					Available[i].SetActive(false);
				}
			}
		}
    }
}
