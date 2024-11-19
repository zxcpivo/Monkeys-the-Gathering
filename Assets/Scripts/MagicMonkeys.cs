using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public abstract class BaseMagicCard : MonoBehaviour
{
    public string CardName;
    public int Attack;
    public int Health;
    public int Shield;
    public int ManaCost;
    public int DecreaseDamage;
    public Sprite CardImage;

    public BaseMagicCard(string name, int attack, int health, int shield, int cost, int decrease)
    {
        this.CardName = name;
        this.Attack = attack;
        this.Health = health;
        this.Shield = shield;
        this.ManaCost = cost;
        this.DecreaseDamage = decrease;
    }


    public abstract void ActivateEffect();
}


