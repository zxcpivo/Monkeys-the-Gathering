using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaMonkey : BaseMagicCard
{
    public TurnSystem turnScript;

    public NinjaMonkey(string name, int attack, int health, int shield, int cost, int decrease) : base(name, attack, health, shield, cost, decrease)
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
