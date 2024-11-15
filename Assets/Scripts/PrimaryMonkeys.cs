using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMonkeyCard : MonoBehaviour
{
    public string CardName;
    public int Attack;
    public int Health;
    public Sprite CardImage;

    public abstract void ActivateEffect();
}

public class DartMonkey : BaseMonkeyCard
{
    private void Awake()
    {
        CardName = "Dart Monkey";
        Attack = 1;
        Health = 2;
    }
    public override void ActivateEffect()
    {
        Debug.Log("dart monkey effect activated");
    }
}

public class IceMonkey : BaseMonkeyCard
{
    private void Awake()
    {
        CardName = "Ice Monkey";
        Attack = 1;
        Health = 2;
    }

    public override void ActivateEffect() 
    {
        Debug.Log("ice monkey effect activated");
    }
}


