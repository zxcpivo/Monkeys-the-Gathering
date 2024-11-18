using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartMonkey : BasePrimaryCard
{
    public TurnSystem turnScript;

    public DartMonkey(string name, int attack, int health, int cost) : base(name, attack, health, cost) {}

    public override void ActivateEffect()
    {
        print($"{CardName} effect activated");
        if (turnScript.isYourTurn)
            turnScript.YourCurrentMana -= ManaCost;
        else
            turnScript.OpponentCurrentMana -= ManaCost;
    }
}
