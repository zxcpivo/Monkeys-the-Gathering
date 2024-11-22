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
        
        Image healthDisplay = Instantiate(HealthDisplay, HealthPos, Quaternion.identity); // gleb
        healthDisplay.transform.SetParent(canvas.transform, false); // gleb

        Button attack = Instantiate(attackButton, ButtonPos, Quaternion.identity);
        attack.transform.SetParent(canvas.transform, false);
        attack.onClick.AddListener(() =>
        {
            StartTargetSelection(card);

        });

    }
    public void StartTargetSelection(GameObject attacker)
    {
        currentAttacker = attacker;
        selectingTarget = true;

    }

    public void Attack(GameObject attacker, GameObject defender)
    {
        print($"{attacker.name}");
        BaseMonkey attackerStats = attacker.GetComponent<BaseMonkey>();
        BaseMonkey defenderStats = defender.GetComponent<BaseMonkey>();
        if (defenderStats.Health <= 0){
            Destroy(defender);
        }
        if(attackerStats.ManaCost < turnScript.YourCurrentMana){
            if (turnScript.isYourTurn){
                turnScript.YourCurrentMana -= attackerStats.ManaCost;
                defenderStats.Health -= attackerStats.Attack;
            }
            else
            {
                turnScript.OpponentCurrentMana -= attackerStats.ManaCost;
                defenderStats.Health -= attackerStats.Attack;
            }
        }
        else{
            print("You cannot proceed with this attack");
        }
    }
}