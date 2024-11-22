using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSupportCard : BaseMonkey
{
    
    public Sprite CardImage;
    
    public BaseSupportCard(string name, int attack, int health, int manaCost) : base(name, attack, health, manaCost)
    {

    }

    public abstract void ActivateEffect();
}
