using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyVillage : BaseSupportCard
{
    public int AttackBoost;
    public TurnSystem turnScript;

    // Constructor remains the same
    public MonkeyVillage(string name, int attack, int health, int cost, int attackboost) : base(name, attack, health, cost)
    {
        this.AttackBoost = attackboost;
    }

    public override void ActivateEffect()  
    {
        print($"{CardName} effect activated");
        if (turnScript.isYourTurn)
            turnScript.YourCurrentMana -= ManaCost;
        else
            turnScript.OpponentCurrentMana -= ManaCost;
            
        BoostMonkeyAttack();
    }

    private void BoostMonkeyAttack()
    {
        foreach (var card in turnScript.CardDeck)
        {
            BaseMonkey baseMonkey = card.GetComponent<BaseMonkey>();
            if (baseMonkey != null) 
            {
                baseMonkey.Attack += AttackBoost;
                print($"{baseMonkey.CardName}'s attack increased by {AttackBoost}!");
            }
        }
    }
}
