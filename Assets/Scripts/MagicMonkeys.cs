using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public abstract class BaseMagicCard : BaseMonkey
{
    public int Shield;
    public int ManaCost;
    public int DecreaseDamage;
    public Sprite CardImage;

    public BaseMagicCard(string name, int attack, int health, int shield, int cost, int decrease) : base(name, attack, health)
    {
        this.Shield = shield;
        this.ManaCost = cost;
        this.DecreaseDamage = decrease;
    }


    public abstract void ActivateEffect();
}


