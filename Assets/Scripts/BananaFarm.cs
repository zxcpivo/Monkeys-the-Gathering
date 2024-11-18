using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaFarm : BaseSupportCard
{
    public int ManaPerTurn = 1;

    public BananaFarm(TurnSystem turnScript, string name, int attack, int health, int cost, int manaPerTurn) : base(turnScript, name, attack, health, cost)
    {
        this.ManaPerTurn = manaPerTurn;
    }

    public override void ActivateEffect()
    {
        if (turnSystem.isYourTurn)
        {
            turnSystem.YourCurrentMana += ManaPerTurn;

            if (turnSystem.YourCurrentMana > turnSystem.maxMana)
            {
                turnSystem.YourCurrentMana = turnSystem.maxMana;
            }
        }
    }
}
