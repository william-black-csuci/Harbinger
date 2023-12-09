using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// a character participating in a combat
public abstract class Combatant
{
	public float TickProgress = 0f;	// progress towards casting an ability
	public float TickThreshold = 0f;	// time to cast the current ability
	public Sprite Portrait;
	public List<Ability> Abilities = new List<Ability>();	// list of abilities this combatant has access to
	protected Combat CurrentCombat;		// info about the current combat
	protected Ability CastingAbility;	// the ability currently being casted
	protected UnityEvent CastingComplete = new UnityEvent();	// event that triggers when an ability finishes being casted
	public List<Combatant> Targets = new List<Combatant>();
	public bool Casting { get; private set; } = false;
	public int Shield = 0;
	public int Stability = 1;
	public int Efficiency = 1;
	public int Authority = 1;
	private int _health;
	public string Name;
	public int Health // health of the combatant
	{ 
		get
		{
			return _health;
		}
		
		// prevent from being less than 0 or more than maximum health
		set
		{
			if (value < Health && Shield > 0)
			{
				Shield -= value;
				if (Shield >= 0)
				{
					return;
				}
				else
				{
					value = -Shield;
				}
			}
			
			if (value < 0)
			{
				_health = 0;
			}
			else if (value > MaxHealth)
			{
				_health = MaxHealth;
			}
			else
			{
				_health = value;
			}
		}
	}
	// maximum health possible for this combatant
	public int MaxHealth { get; protected set; }
	
	// constructor
	protected Combatant(Combat combat)
	{
		// store the current combat
		CurrentCombat = combat;
		
		// set health
		MaxHealth = 100*Stability;
		Health = MaxHealth;
		
		//TickThreshold = CastingAbility.TickThreshold;
		
		// set current ability to use
		//CastingAbility = GetNextAbility(combat, true);
	}
	
	// get ability to cast
	protected abstract Ability GetNextAbility(Combat combat, bool combatStart = false);
	
	protected virtual void PrepareAbility(bool combatStart = false)
	{
		CastingAbility = GetNextAbility(CurrentCombat, combatStart);
		TickThreshold = CastingAbility.TickThreshold;
	}
	
	int CPUCache;
	
	// called once per frame
	public virtual void Tick()
	{
		if (TickProgress == 0f)
		{
			CastingAbility = GetNextAbility(CurrentCombat);	// start next ability
			TickThreshold = CastingAbility.TickThreshold;	// set the cast bar length accordingly
			
			if (CurrentCombat.CPU + CastingAbility.CPU > CurrentCombat.MaxCPU)
			{
				return;
			}
			else
			{
				CPUCache = CastingAbility.CPU;
				CurrentCombat.CPU += CastingAbility.CPU;
			}
		}
		// increase the casting timer
		TickProgress += Time.deltaTime;
		
		// if the cast bar is full
		if (TickProgress >= TickThreshold)
		{
			// prevent bar from overflowing
			TickProgress = TickThreshold;
			
			// try to cast (or continue effects of) current ability
			Casting = CastingAbility.Cast(CurrentCombat, this, Authority, Targets);
			if (!Casting)
			{
				// if finished casting effects:
				TickProgress = 0f;	// reset cast bar
				CurrentCombat.CPU -= CPUCache;
				CastingComplete.Invoke();	// invoke event for casting complete
			}
		}
	}
	
	// prepare for combat
	public virtual void StartCombat(Combat combat)
	{
		// set the current combat
		CurrentCombat = combat;
		// get the first ability
		PrepareAbility(true);
	}
}
