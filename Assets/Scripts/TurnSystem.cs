using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour
{

    public bool isYourTurn;
    public int YourTurn;
    public int OpponentTurn;
    public Text turnText;
    public Text manaText;

    public int maxMana;
    public int currentMana;

    public GameObject[] CardDeck;
    public Transform cardSpawnPoint;

    void Start()
    {
        isYourTurn = true;
        YourTurn = 1;
        OpponentTurn = 0;

        maxMana = 1;
        currentMana = 1;
    }

    void Update()
    {
        if(isYourTurn == true)
        {
            turnText.text = "Your Turn";
        }
        else
        {
            turnText.text = "Opponent Turn";
        }

        manaText.text = currentMana + "/" + maxMana;
        
    }

    public void EndYourTurn()
    {
        isYourTurn = false;
        OpponentTurn += 1;

        DrawCard();
    }

    public void EndOpponentTurn()
    {
        isYourTurn = true;
        YourTurn += 1;

        maxMana += 1;
        currentMana = maxMana;
    }

    public void DrawCard()
    {
        int RandomIndex = Random.Range(0, CardDeck.Length);

        Instantiate(CardDeck[RandomIndex], cardSpawnPoint.position, Quaternion.identity);

    }
}
