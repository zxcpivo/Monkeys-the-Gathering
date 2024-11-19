using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMonkey : BasePrimaryCard
{
    public int FreezeTime;

    public IceMonkey(string name, int attack, int health, int cost, int freezeTime) : base(name, attack, health, cost)
    {
        this.FreezeTime = freezeTime;
    }

    public override void ActivateEffect()
    {

    }
}
