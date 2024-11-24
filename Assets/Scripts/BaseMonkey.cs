using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseMonkey : MonoBehaviour
{
    public string CardName;
    public int Attack;
    public int Health;

    public int ManaCost;
    public Image HealthDisplay;
    public Text HealthTextInstance;
    public Button AttackButton;

    public BaseMonkey(string name, int attack, int health, int manaCost)
    {
        this.CardName = name;
        this.Attack = attack;
        this.Health = health;
        this.ManaCost = manaCost;
    }
}
