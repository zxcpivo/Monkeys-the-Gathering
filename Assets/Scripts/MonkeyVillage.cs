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

        // Subtract the Mana cost
        if (turnScript.isYourTurn)
        {
            turnScript.YourCurrentMana -= ManaCost;
        }
        else
        {
            turnScript.OpponentCurrentMana -= ManaCost;
        }

        // Boost the attack based on the card's position on the screen
        BoostMonkeyAttackBasedOnPosition();
    }

    private void BoostMonkeyAttackBasedOnPosition()
    {
        // Get the screen position of the MonkeyVillage card
        Vector3 cardScreenPos = Camera.main.WorldToScreenPoint(transform.position);

        // Determine if the card is in the top or bottom half of the screen
        bool isInTopHalf = cardScreenPos.y > Screen.height / 2;

        // Define the positions for boosting based on top/bottom half
        Vector3[] targetPositions;
        if (isInTopHalf)
        {
            // Top half positions
            targetPositions = new Vector3[]
            {
                new Vector3(-10f, 47f, 0f),
                new Vector3(15f, 47f, 0f),
                new Vector3(40f, 47f, 0f)
            };
        }
        else
        {
            // Bottom half positions
            targetPositions = new Vector3[]
            {
                new Vector3(-10f, -47f, 0f),
                new Vector3(15f, -47f, 0f),
                new Vector3(40f, -47f, 0f)
            };
        }

        // Boost the attack of monkeys at the target positions
        foreach (var card in turnScript.CardDeck)
        {
            BaseMonkey baseMonkey = card.GetComponent<BaseMonkey>();
            BaseSupportCard baseSupportCard = card.GetComponent<BaseSupportCard>();

            // Ensure that we only boost BaseMonkey objects and not support cards
            if (baseMonkey != null && baseSupportCard == null)
            {
                // Get the position of the current monkey card in world space
                Vector3 monkeyPosition = card.transform.position;

                // Check if the current monkey's position matches any of the target positions
                foreach (var targetPosition in targetPositions)
                {
                    if (monkeyPosition == targetPosition)
                    {
                        baseMonkey.Attack += AttackBoost;
                        print($"{baseMonkey.CardName}'s attack increased by {AttackBoost}!");
                    }
                }
            }
        }
    }
}
