using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePrimaryCard : BaseMonkey
{

    public int ManaCost;
    public Sprite CardImage;

    public BasePrimaryCard(string name, int attack, int health, int cost) : base(name, attack, health)
    {
        this.ManaCost = cost;
    }

    public abstract void ActivateEffect();
}

