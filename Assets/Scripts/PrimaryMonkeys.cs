using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePrimaryCard : MonoBehaviour
{
    public string CardName;
    public int Attack;
    public int Health;
    public int ManaCost;
    public Sprite CardImage;
    public TurnSystem turnSystem;

    public BasePrimaryCard(TurnSystem turnScript, string name, int attack, int health, int cost)
    {
        this.turnSystem = turnScript;
        this.CardName = name;
        this.Attack = attack;
        this.Health = health;
        this.ManaCost = cost;
    }

    public abstract void ActivateEffect();
}

