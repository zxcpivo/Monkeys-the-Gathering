using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour
{
    public bool isYourTurn;
    public int YourCardsInHand;
    public int OpponentsCardsInHand;
    public int YourTurn;
    public int OpponentTurn;
    public Text turnText;
    public Text manaText;

    public int maxMana;
    public int YourCurrentMana;
    public int OpponentCurrentMana;

    public GameObject[] CardDeck;
    public Transform cardSpawnPoint;

    public void Awake()
    {
        isYourTurn = true;
        YourTurn = 1;
        OpponentTurn = 0;

        maxMana = 1;
        YourCurrentMana = 1;
        OpponentCurrentMana = 1;
        YourCardsInHand = 0;
        OpponentsCardsInHand = 0;
    }

    void Update()
    {
        if (isYourTurn == true)
        {
            turnText.text = "Your Turn";
            manaText.text = YourCurrentMana + "/" + maxMana;
            print(maxMana);
        }
        else
        {
            turnText.text = "Opponent Turn";
            manaText.text = OpponentCurrentMana + "/" + maxMana;
            print(maxMana);
        }


    }

    public void EndYourTurn()
    {
        if (!isYourTurn) 
        {
            Console.WriteLine("cant end your turn because its the opponents turn");
            return;
        }

        isYourTurn = false;
        OpponentTurn += 1;

        OpponentCurrentMana = maxMana;

        YouDrawCard(YourCardsInHand);
        YourCardsInHand += 1;
    }

    public void EndOpponentTurn()
    {
        if (isYourTurn)
        {
            Console.WriteLine(" opponent cant end the turn because its your turn");
            return;
        }

        isYourTurn = true;
        YourTurn += 1;

        maxMana += 1;
        YourCurrentMana = maxMana;

        OpponentDrawCard(OpponentsCardsInHand);
        OpponentsCardsInHand += 1;
    }

    public void YouDrawCard(int InHand)
    {
        int RandomIndex = UnityEngine.Random.Range(0, CardDeck.Length);
        if (InHand == 0)
        {
            cardSpawnPoint.position = new Vector3(-0.5f, -4f, 0f);
        }
        else if (InHand == 1)
        {
            cardSpawnPoint.position = new Vector3(1f, -4f, 0f);
        }
        else if (InHand == 2)
        {
            cardSpawnPoint.position = new Vector3(2.5f, -4f, 0f);
        }
        else if (InHand == 3)
        {
            cardSpawnPoint.position = new Vector3(4f, -4f, 0f);
        }
        Instantiate(CardDeck[RandomIndex], cardSpawnPoint.position, Quaternion.identity);

    }

    public void OpponentDrawCard(int InHand)
    {
        int RandomIndex = UnityEngine.Random.Range(0, CardDeck.Length);
        if (InHand == 0)
        {
            cardSpawnPoint.position = new Vector3(-0.5f, 3.5f, 0f);
        }
        else if (InHand == 1)
        {
            cardSpawnPoint.position = new Vector3(1f, 3.5f, 0f);
        }
        else if (InHand == 2)
        {
            cardSpawnPoint.position = new Vector3(2.5f, 3.5f, 0f);
        }
        else if (InHand == 3)
        {
            cardSpawnPoint.position = new Vector3(4f, 3.5f, 0f);
        }
        Instantiate(CardDeck[RandomIndex], cardSpawnPoint.position, Quaternion.identity);

    }
}
