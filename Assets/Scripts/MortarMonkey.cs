using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarMonkey : BaseMilitaryCard
{

    public MortarMonkey(TurnSystem turnScript, string name, int attack, int health, int cost, int decrease) : base(turnScript, name, attack, health, cost, decrease)
    {

    }

    public override void ActivateEffect()
    {
        print($"{CardName} effect activated");
    }
}