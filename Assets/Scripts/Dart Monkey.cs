using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DartMonkey : BasePrimaryCard
{
    public TurnSystem turnScript;
    public int ManaBonus = 1;

    public DartMonkey(string name, int attack, int health, int cost, int manaBonus) : base(name, attack, health, cost)
    {
        this.ManaBonus = manaBonus;
    }

    public override void ActivateEffect()
    {
        print($"{CardName} effect activated");
        if (turnScript.isYourTurn)
            turnScript.YourCurrentMana += ManaBonus;
        else
            turnScript.OpponentCurrentMana += ManaBonus;
    }
}
