using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class BattleSystem : MonoBehaviour
{
    public TurnSystem turnScript;
    public Button attackButton;
    public Canvas canvas;

    public GameObject currentAttacker;
    private bool selectingTarget = false;

    void Update()
    {
        if (selectingTarget && Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if (hit.collider != null)
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
        defenderStats.Health -= attackerStats.Attack;

    }
}
