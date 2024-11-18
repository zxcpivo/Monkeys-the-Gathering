using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSupportCard : MonoBehaviour
{
    public string CardName;
    public int Attack;
    public int Health;
    public int ManaCost;
    public Sprite CardImage;
    public TurnSystem turnSystem;
    
    public BaseSupportCard(TurnSystem turnScript, string name, int attack, int health, int cost)
    {
        this.turnSystem = turnScript;
        this.CardName = name;
        this.Attack = attack;
        this.Health = health;
        this.ManaCost = cost;
    }

    public abstract void ActivateEffect();
}
