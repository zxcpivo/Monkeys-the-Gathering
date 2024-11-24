using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePrimaryCard : BaseMonkey
{
    public Sprite CardImage;

    public BasePrimaryCard(string name, int attack, int health, int manaCost) : base(name, attack, health, manaCost) {}
    public abstract void ActivateEffect();
}

