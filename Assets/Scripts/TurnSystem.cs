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
    public int YourCardsOnBoard;
    public int OpponentCardsOnBoard;

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
        YourCardsOnBoard = 0;
        OpponentCardsOnBoard = 0;
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
            GameObject card = Instantiate(CardDeck[RandomIndex], cardSpawnPoint.position, Quaternion.identity);

            Vector3 buttonOffset = new Vector3(-81f, -500f, 0f);
            Button button = Instantiate(playCard, buttonOffset, Quaternion.identity);
            button.transform.SetParent(canvas.transform, false);

            button.onClick.AddListener(() =>
            {
                card.transform.position = new Vector3(-20f, -15.5f, 0f);
                YourCardsInHand -= 1;
                Destroy(button.gameObject);
            });
        }
        else if (InHand == 1)
        {
            cardSpawnPoint.position = new Vector3(15f, -47f, 0f);
            GameObject card = Instantiate(CardDeck[RandomIndex], cardSpawnPoint.position, Quaternion.identity);

            Vector3 buttonOffset = new Vector3(127f, -500f, 0f);
            Button button = Instantiate(playCard, buttonOffset, Quaternion.identity);
            button.transform.SetParent(canvas.transform, false);

            button.onClick.AddListener(() =>
            {
                card.transform.position = new Vector3(10f, -15.5f, 0f);
                YourCardsInHand -= 1;
                Destroy(button.gameObject);
            });
        }
        else if (InHand == 2)
        {
            cardSpawnPoint.position = new Vector3(40f, -47f, 0f);
            GameObject card = Instantiate(CardDeck[RandomIndex], cardSpawnPoint.position, Quaternion.identity);

            Vector3 buttonOffset = new Vector3(340f, -500f, 0f);
            Button button = Instantiate(playCard, buttonOffset, Quaternion.identity);
            button.transform.SetParent(canvas.transform, false);

            button.onClick.AddListener(() =>
            {
                card.transform.position = new Vector3(40f, -15.5f, 0f);
                YourCardsInHand -= 1;
                Destroy(button.gameObject);
            });
        }
        else
        {
            print("You cant draw anymore cards");
        }

    }

    public void OpponentDrawCard(int InHand)
    {
        int RandomIndex = UnityEngine.Random.Range(0, CardDeck.Length);
        if (InHand == 0)
        {
            cardSpawnPoint.position = new Vector3(-10f, 47f, 0f);
            GameObject card = Instantiate(CardDeck[RandomIndex], cardSpawnPoint.position, Quaternion.identity);

            Vector3 buttonOffset = new Vector3(-81f, 288f, 0f);
            Button button = Instantiate(playCard, buttonOffset, Quaternion.identity);
            button.transform.SetParent(canvas.transform, false);

            button.onClick.AddListener(() =>
            {
                card.transform.position = new Vector3(-20f, 15.5f, 0f);
                YourCardsOnBoard += 1;
                OpponentsCardsInHand -= 1;
                Destroy(button.gameObject);
            });
        }
        else if (InHand == 1)
        {
            cardSpawnPoint.position = new Vector3(15f, 47f, 0f);
            GameObject card = Instantiate(CardDeck[RandomIndex], cardSpawnPoint.position, Quaternion.identity);

            Vector3 buttonOffset = new Vector3(127f, 288f, 0f);
            Button button = Instantiate(playCard, buttonOffset, Quaternion.identity);
            button.transform.SetParent(canvas.transform, false);

            button.onClick.AddListener(() =>
            {
                card.transform.position = new Vector3(10f, 15.5f, 0f);
                OpponentsCardsInHand -= 1;
                Destroy(button.gameObject);
            });
        }
        else if (InHand == 2)
        {
            cardSpawnPoint.position = new Vector3(40f, 47f, 0f);
            GameObject card = Instantiate(CardDeck[RandomIndex], cardSpawnPoint.position, Quaternion.identity);

            Vector3 buttonOffset = new Vector3(340f, 288f, 0f);
            Button button = Instantiate(playCard, buttonOffset, Quaternion.identity);
            button.transform.SetParent(canvas.transform, false);

            button.onClick.AddListener(() =>
            {
                card.transform.position = new Vector3(40f, 15.5f, 0f);
                OpponentsCardsInHand -= 1;
                Destroy(button.gameObject);
            });
        }
        else
        {
            print("You cant draw anymore cards");
        }

    }

    public void PlaceCard(GameObject card)
    {

    }
}
