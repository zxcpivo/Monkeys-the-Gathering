using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaFarm : BaseSupportCard
{
    public TurnSystem turnScript;
    public int ManaPerTurn = 1;

    public BananaFarm(string name, int attack, int health, int cost, int manaPerTurn) : base(name, attack, health, cost)
    {
        this.ManaPerTurn = manaPerTurn;
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
