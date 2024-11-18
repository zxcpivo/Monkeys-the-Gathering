using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperMonkey : BaseMilitaryCard
{
    public TurnSystem turnScript;

    public SniperMonkey(string name, int attack, int health, int cost, int decrease) : base(name, attack, health, cost, decrease)
    {

    }
    public override void ActivateEffect()
    {
        print($"{CardName} effect activated");
        if(turnScript.isYourTurn)
            turnScript.YourCurrentMana -= ManaCost;
        else
            turnScript.OpponentCurrentMana -= ManaCost;
    }
}
