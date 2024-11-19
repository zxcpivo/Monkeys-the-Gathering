using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardMonkey : BaseMagicCard
{
    public TurnSystem turnScript;

    public WizardMonkey(string name, int attack, int health, int shield, int cost, int decrease) : base(name, attack, health, shield, cost, decrease)
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
