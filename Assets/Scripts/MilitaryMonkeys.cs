using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public abstract class BaseMilitaryCard : MonoBehaviour
{
    public string CardName;
    public int Attack;
    public int Health;
    public int ManaCost;
    public int DecreaseDamage;
    public Sprite CardImage;
    public TurnSystem turnSystem;

    public BaseMilitaryCard(TurnSystem turnScript, string name, int attack, int health, int cost, int decrease)
    {
        this.turnSystem = turnScript;
        this.CardName = name;
        this.Attack = attack;
        this.Health = health;
        this.ManaCost = cost;
        this.DecreaseDamage = decrease;
    }
    public abstract void ActivateEffect();
}

