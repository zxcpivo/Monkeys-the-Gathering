using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyVillage : BaseSupportCard
{
    public int AttackBoost;
    public TurnSystem turnScript;

    public MonkeyVillage(string name, int attack, int health, int cost, int attackboost) : base(name, attack, health, cost)
    {
        this.AttackBoost = attackboost;
    }

    public override void ActivateEffect()
    {
        print($"{CardName} effect activated");

        if (turnScript.isYourTurn)
        {
            turnScript.YourCurrentMana -= ManaCost;
        }
        else
        {
            turnScript.OpponentCurrentMana -= ManaCost;
        }

        BoostMonkeyAttackBasedOnPosition();
    }

    private void BoostMonkeyAttackBasedOnPosition()
    {
        Vector3 cardScreenPos = Camera.main.WorldToScreenPoint(transform.position);

        bool isInTopHalf = cardScreenPos.y > Screen.height / 2;

        Vector3[] targetPositions;
        if (isInTopHalf)
        {
            targetPositions = new Vector3[]
            {
                new Vector3(-10f, 47f, 0f),
                new Vector3(15f, 47f, 0f),
                new Vector3(40f, 47f, 0f)
            };
        }
        else
        {
            targetPositions = new Vector3[]
            {
                new Vector3(-10f, -47f, 0f),
                new Vector3(15f, -47f, 0f),
                new Vector3(40f, -47f, 0f)
            };
        }

        float tolerance = 0.1f; 

        foreach (var card in turnScript.CardDeck)
        {
            BaseMonkey baseMonkey = card.GetComponent<BaseMonkey>();
            BaseSupportCard baseSupportCard = card.GetComponent<BaseSupportCard>();

            if (baseMonkey != null && baseSupportCard == null)
            {
                Vector3 monkeyPosition = card.transform.position;

                foreach (var targetPosition in targetPositions)
                {
                    if (Vector3.Distance(monkeyPosition, targetPosition) <= tolerance)
                    {
                        baseMonkey.Attack += AttackBoost;
                        print($"{baseMonkey.CardName}'s attack increased by {AttackBoost}!");
                        break; 
                    }
                }
            }
        }
    }
}
