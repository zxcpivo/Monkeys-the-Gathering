using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NinjaMonkey : BaseMagicCard
{
    public TurnSystem turnScript;
    public Image HealthDisplayPrefab;
    public Canvas canvas;

    private Image healthDisplayInstance;
    private Text healthText;

    public NinjaMonkey(string name, int attack, int health, int shield, int cost, int decrease) : base(name, attack, health, shield, cost, decrease)
    {

    }

    public override void ActivateEffect()
    {
        print($"{CardName} effect activated");
        if (turnScript.isYourTurn)
            turnScript.YourCurrentMana -= ManaCost;
        else
            turnScript.OpponentCurrentMana -= ManaCost;
    }

    public void SpawnHealthDisplayer(Vector3 position)
    {
        if (HealthDisplayPrefab == null || canvas == null)
        {
            Debug.LogError("HealthDisplayPrefab or Canvas is not assigned.");
            return;
        }
        healthDisplayInstance = Instantiate(HealthDisplayPrefab, position, Quaternion.identity);
        healthDisplayInstance.transform.SetParent(canvas.transform, false);
        healthText = healthDisplayInstance.GetComponentInChildren<Text>();
        if (healthText != null)
        {
            healthText.text = Health.ToString();
        }
        else
        {
            Debug.LogError("HealthDisplayPrefab is missing a Text component.");
        }
    }

    public void UpdateHealthDisplay()
    {
        if (healthText != null)
        {
            healthText.text = Health.ToString();
        }
    }

    public void DestroyHealthDisplayer()
    {
        if (healthDisplayInstance != null)
        {
            Destroy(healthDisplayInstance.gameObject);
        }
    }
}
