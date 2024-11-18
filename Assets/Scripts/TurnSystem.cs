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
    public Button playCard;
    public Canvas canvas;

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
        }
        else
        {
            turnText.text = "Opponent Turn";
            manaText.text = OpponentCurrentMana + "/" + maxMana;
        }


    }

    public void EndYourTurn()
    {
        if (!isYourTurn) 
        {
            print("cant end your turn because its the opponents turn");
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
            print(" opponent cant end the turn because its your turn");
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
            cardSpawnPoint.position = new Vector3(-10f, -47f, 0f);
        }
        else if (InHand == 1)
        {
            cardSpawnPoint.position = new Vector3(15f, -47f, 0f);
        }
        else if (InHand == 2)
        {
            cardSpawnPoint.position = new Vector3(40f, -47f, 0f);
        }
        else
        {
            print("You cant draw anymore cards");
        }
        GameObject card = Instantiate(CardDeck[RandomIndex], cardSpawnPoint.position, Quaternion.identity);

        Vector3 buttonOffset = new Vector3(800f, 130f, 0f);
        Button button = Instantiate(playCard, buttonOffset, Quaternion.identity);

        button.transform.SetParent(canvas.transform, false);

    }

    public void OpponentDrawCard(int InHand)
    {
        int RandomIndex = UnityEngine.Random.Range(0, CardDeck.Length);
        if (InHand == 0)
        {
            cardSpawnPoint.position = new Vector3(-10f, 47f, 0f);
        }
        else if (InHand == 1)
        {
            cardSpawnPoint.position = new Vector3(15f, 47f, 0f);
        }
        else if (InHand == 2)
        {
            cardSpawnPoint.position = new Vector3(40f, 47f, 0f);
        }
        else
        {
            print("You cant draw anymore cards");
        }

        GameObject card = Instantiate(CardDeck[RandomIndex], cardSpawnPoint.position, Quaternion.identity);

    }
}
