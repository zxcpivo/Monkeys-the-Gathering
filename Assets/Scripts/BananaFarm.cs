using UnityEngine;
using UnityEngine.UI; 
public class BananaFarm : BaseSupportCard
{
    public TurnSystem turnScript;
    public int IncreaseMaxMana;
    public Text statusText;  

    public BananaFarm(string name, int attack, int health, int cost, int increasemaxmana) : base(name, attack, health, cost)
    {
        this.IncreaseMaxMana = increasemaxmana;
    }

    public override void ActivateEffect()
    {
        string effectMessage = $"{CardName} effect activated";

        print(effectMessage);

        if (statusText != null)
        {
            statusText.text = effectMessage; 
        }

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
