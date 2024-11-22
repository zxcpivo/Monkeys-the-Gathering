using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMonkey : MonoBehaviour
{
    public string CardName;
    public int Attack;
    public int Health;

    public int ManaCost;

    public BaseMonkey(string name, int attack, int health, int manaCost)
    {
        this.CardName = name;
        this.Attack = attack;
        this.Health = health;
        this.ManaCost = manaCost;
    }
}
