using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarMonkey : BaseMilitaryCard
{

    public MortarMonkey(string name, int attack, int health, int cost, int decrease) : base(name, attack, health, cost, decrease)
    {

    }

    public override void ActivateEffect()
    {
        print($"{CardName} effect activated");
    }
}