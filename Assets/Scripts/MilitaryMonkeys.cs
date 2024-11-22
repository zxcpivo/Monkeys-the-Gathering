using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public abstract class BaseMilitaryCard : BaseMonkey
{
    
    public int DecreaseDamage;
    public Sprite CardImage;

    public BaseMilitaryCard(string name, int attack, int health, int manaCost, int decrease) : base(name, attack, health, manaCost)
    {
        this.DecreaseDamage = decrease;
    }

    public abstract void ActivateAttack();
}


