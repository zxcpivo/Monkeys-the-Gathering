using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineerMonkey : BaseSupportCard
{
    public GameObject TurretCardPrefab;

    public EngineerMonkey(TurnSystem turnScript, string name, int attack, int health, int cost, GameObject turretPrefab) : base(turnScript, name, attack, health, cost)
    {
        this.TurretCardPrefab = turretPrefab;
    }

    // Update is called once per frame
     public override void ActivateEffect()
    {
        
    }
}
