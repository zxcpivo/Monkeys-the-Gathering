using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMonkey : BasePrimaryCard
{
    public TurnSystem turnScript;

    public IceMonkey(string name, int attack, int health, int cost, int freezeTime) : base(name, attack, health, cost)
    {

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
