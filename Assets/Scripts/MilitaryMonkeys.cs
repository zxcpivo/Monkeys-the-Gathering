using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public abstract class BaseMilitaryCard : BaseMonkey
{
    public int ManaCost;
    public int DecreaseDamage;
    public Sprite CardImage;

    public BaseMilitaryCard(string name, int attack, int health, int cost, int decrease) : base(name, attack, health)
    {
        this.ManaCost = cost;
        this.DecreaseDamage = decrease;
    }

    public abstract void ActivateAttack();
}


