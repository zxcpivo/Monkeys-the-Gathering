using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMonkey : BasePrimaryCard
{
    public int FreezeTime;

    public IceMonkey(TurnSystem turnScript, string name, int attack, int health, int cost, int freezeTime) : base(turnScript, name, attack, health, cost)
    {
        this.FreezeTime = freezeTime;
    }


}
