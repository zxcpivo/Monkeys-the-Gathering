using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public abstract class BaseMagicCard : BaseMonkey
{
    public int Shield;
    public int DecreaseDamage;
    public Sprite CardImage;

    public BaseMagicCard(string name, int attack, int health, int shield, int manaCost, int decrease) : base(name, attack, health, manaCost)
    {
        this.Shield = shield;
        this.DecreaseDamage = decrease;
    }


    public abstract void ActivateEffect();
}


