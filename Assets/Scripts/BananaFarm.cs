using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaFarm : BaseSupportCard
{
    public TurnSystem turnScript;
    public int IncreaseMaxMana;

    public BananaFarm(string name, int attack, int health, int cost, int increasemaxmana) : base(name, attack, health, cost)
    {
        this.IncreaseMaxMana = increasemaxmana;
    }

    public override void ActivateEffect()
    {
        print($"{CardName} effect activated");
        if (turnScript.isYourTurn)
        {
            turnScript.yourMaxMana += IncreaseMaxMana;
            turnScript.YourCurrentMana = turnScript.yourMaxMana;
            turnScript.YourCurrentMana -= ManaCost;
        }
        else
        {
            turnScript.OpponentCurrentMana -= ManaCost;
        }
    }
}
