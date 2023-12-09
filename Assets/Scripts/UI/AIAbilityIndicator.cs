using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAbilityIndicator : MonoBehaviour
{
	[SerializeField]
	private Transform[] Locations;
	
	[SerializeField]
	private DemoStarter Demo;
	
	[SerializeField]
	private int AIIndex;
	
	private int CurrentLocation = 0;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Demo.AIs[AIIndex].nextAbilityIndex != CurrentLocation)
		{
			CurrentLocation = Demo.AIs[AIIndex].nextAbilityIndex;
			transform.SetParent(Locations[CurrentLocation], false);
		}
    }
}
