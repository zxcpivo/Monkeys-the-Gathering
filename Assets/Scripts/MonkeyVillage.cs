using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyVillage : BaseSupportCard
{
    public int AttackBoost;
    public TurnSystem turnScript;

    public MonkeyVillage(string name, int attack, int health, int cost, int attackboost) : base(name, attack, health, cost)
    {
        this.AttackBoost = attackboost; 
    }

     public override void ActivateEffect()  
    {
        print($"{CardName} effect activated");
        if (turnScript.isYourTurn)
            turnScript.YourCurrentMana -= ManaCost;
        else
            turnScript.OpponentCurrentMana -= ManaCost;
    }
}
