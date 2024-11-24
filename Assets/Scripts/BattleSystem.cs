using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class BattleSystem : MonoBehaviour
{
    public TurnSystem turnScript;
    public Button attackButton;
    public Image HealthDisplay;
    public Canvas canvas;
    public BaseMonkey HealthChecker;
    public Text healthText; // gleb


    public GameObject currentAttacker;
    public bool selectingTarget = false;

    void Update()
    {
        if (selectingTarget && Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if (hit.collider != null) // detects hit with box collider
            {
                GameObject target = hit.collider.gameObject;
                if (target != null)
                {
                    Attack(currentAttacker, target);
                    selectingTarget = false;
                }
            }
        }
    }

    public void SpawnAttackButton(Vector3 ButtonPos, GameObject card)
    {
        Vector3 HealthPos = new Vector3(ButtonPos.x - 90, ButtonPos.y + 100, ButtonPos.z); // gleb       
        BaseMonkey cardStats = card.GetComponent<BaseMonkey>(); // gleb

        

        healthText.text = $"{cardStats.Health}";
        Text healthTextInstance = Instantiate(healthText, HealthPos, Quaternion.identity);
        healthTextInstance.transform.SetParent(canvas.transform, false);
        cardStats.HealthTextInstance = healthTextInstance;

        Image healthDisplay = Instantiate(HealthDisplay, HealthPos, Quaternion.identity); // gleb
        healthDisplay.transform.SetParent(canvas.transform, false); // gleb
        cardStats.HealthDisplay = healthDisplay;

        Button attack = Instantiate(attackButton, ButtonPos, Quaternion.identity);
        attack.transform.SetParent(canvas.transform, false);
        cardStats.AttackButton = attack;
        attack.onClick.AddListener(() =>
        {
            StartTargetSelection(card, attack, healthTextInstance, healthDisplay);

        });
        



    }

    public void StartTargetSelection(GameObject attacker, Button attackButton, Text healthTextDisplay, Image HealthDisplay)
    {
        
        currentAttacker = attacker;
        selectingTarget = true;

    }

    public void Attack(GameObject attacker, GameObject defender)
    {
        print($"{attacker.name}");
        BaseMonkey attackerStats = attacker.GetComponent<BaseMonkey>();
        BaseMonkey defenderStats = defender.GetComponent<BaseMonkey>();

        if (attacker.name == "Banana Farm (1)(Clone)")
            turnScript.yourMaxMana += 1;

        if (attacker.name == "Monkey Village (1)(Clone)")
            defenderStats.Attack += 1;

        if (turnScript.isYourTurn && defenderStats.ManaCost <= turnScript.YourCurrentMana)
        {
            turnScript.YourCurrentMana -= attackerStats.ManaCost;
            defenderStats.Health -= attackerStats.Attack;
            turnScript.EndYourTurn();
        }
        else if(turnScript.isYourTurn == false && defenderStats.ManaCost <= turnScript.OpponentCurrentMana)
        {
            turnScript.OpponentCurrentMana -= attackerStats.ManaCost;
            defenderStats.Health -= attackerStats.Attack;
            turnScript.EndOpponentTurn();
            
        }
        else
        {
            print("Not Enough Mana");
        }

        if (defenderStats.Health <= 0)
        {
            if (defenderStats.HealthDisplay != null)
                Destroy(defenderStats.HealthDisplay?.gameObject);
            if (defenderStats.HealthTextInstance != null)
                Destroy(defenderStats.HealthTextInstance?.gameObject);
            if (defenderStats.AttackButton != null)
                Destroy(defenderStats.AttackButton?.gameObject);

            Destroy(defender);
        }
        else
        {
            if (defenderStats.HealthDisplay != null)
            {
                Text healthText = defenderStats.HealthDisplay.GetComponentInChildren<Text>();
                if (healthText != null)
                {
                    healthText.text = defenderStats.Health.ToString();
                }
                
            }
            
        }
    }
}
