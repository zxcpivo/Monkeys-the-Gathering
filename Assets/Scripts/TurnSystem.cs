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

    public bool YourPos1;
    public bool YourPos2;
    public bool YourPos3;

    public bool OpponentPost1;
    public bool OpponentPost2;
    public bool OpponentPost3;

    public Text turnText;
    public Text manaText;
    public Button playCard;
    public Button locationCard;
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

        YourCardsOnBoard = 0;
        OpponentCardsOnBoard = 0;

        YouDrawCard(YourCardsInHand); // Both Players start with 1 card
        YourCardsInHand = 1;

        OpponentDrawCard(OpponentsCardsInHand);
        OpponentsCardsInHand = 1;
    }

    void Update()
    {
        print($"You have {YourCardsInHand}");
        print($"Opponent has {OpponentsCardsInHand}");
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

        OpponentDrawCard(OpponentsCardsInHand);
        OpponentsCardsInHand += 1;
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


        YouDrawCard(YourCardsInHand);
        YourCardsInHand += 1;
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
                YourPos1 = true;
                YourCardsInHand -= 1;
                Button Pos1Button = Instantiate(locationCard, new Vector3(-170f, -220f, 0f), Quaternion.identity);
                Pos1Button.transform.SetParent(canvas.transform, false);
                Button Pos2Button = Instantiate(locationCard, new Vector3(125f, -220f, 0f), Quaternion.identity);
                Pos2Button.transform.SetParent(canvas.transform, false);
                Button Pos3Button = Instantiate(locationCard, new Vector3(450f, -220f, 0f), Quaternion.identity);
                Pos3Button.transform.SetParent(canvas.transform, false);
                Pos1Button.onClick.AddListener(() =>
                {
                    card.transform.position = new Vector3(-20f, -15.5f, 0f);
                    Destroy(Pos1Button.gameObject);
                    Destroy(Pos2Button.gameObject);
                    Destroy(Pos3Button.gameObject);
                });
                Pos2Button.onClick.AddListener(() =>
                {
                    card.transform.position = new Vector3(16f, -15.5f, 0f);
                    Destroy(Pos1Button.gameObject);
                    Destroy(Pos2Button.gameObject);
                    Destroy(Pos3Button.gameObject);
                });
                Pos3Button.onClick.AddListener(() =>
                {
                    card.transform.position = new Vector3(50f, -15.5f, 0f);
                    Destroy(Pos1Button.gameObject);
                    Destroy(Pos2Button.gameObject);
                    Destroy(Pos3Button.gameObject);
                });
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
                YourPos1 = true;
                YourCardsInHand -= 1;
                Button Pos1Button = Instantiate(locationCard, new Vector3(-170f, -220f, 0f), Quaternion.identity);
                Pos1Button.transform.SetParent(canvas.transform, false);
                Button Pos2Button = Instantiate(locationCard, new Vector3(125f, -220f, 0f), Quaternion.identity);
                Pos2Button.transform.SetParent(canvas.transform, false);
                Button Pos3Button = Instantiate(locationCard, new Vector3(450f, -220f, 0f), Quaternion.identity);
                Pos3Button.transform.SetParent(canvas.transform, false);
                Pos1Button.onClick.AddListener(() =>
                {
                    card.transform.position = new Vector3(-20f, -15.5f, 0f);
                    Destroy(Pos1Button.gameObject);
                    Destroy(Pos2Button.gameObject);
                    Destroy(Pos3Button.gameObject);
                });
                Pos2Button.onClick.AddListener(() =>
                {
                    card.transform.position = new Vector3(16f, -15.5f, 0f);
                    Destroy(Pos1Button.gameObject);
                    Destroy(Pos2Button.gameObject);
                    Destroy(Pos3Button.gameObject);
                });
                Pos3Button.onClick.AddListener(() =>
                {
                    card.transform.position = new Vector3(50f, -15.5f, 0f);
                    Destroy(Pos1Button.gameObject);
                    Destroy(Pos2Button.gameObject);
                    Destroy(Pos3Button.gameObject);
                });
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
                YourPos1 = true;
                YourCardsInHand -= 1;
                Button Pos1Button = Instantiate(locationCard, new Vector3(-170f, -220f, 0f), Quaternion.identity);
                Pos1Button.transform.SetParent(canvas.transform, false);
                Button Pos2Button = Instantiate(locationCard, new Vector3(125f, -220f, 0f), Quaternion.identity);
                Pos2Button.transform.SetParent(canvas.transform, false);
                Button Pos3Button = Instantiate(locationCard, new Vector3(450f, -220f, 0f), Quaternion.identity);
                Pos3Button.transform.SetParent(canvas.transform, false);
                Pos1Button.onClick.AddListener(() =>
                {
                    card.transform.position = new Vector3(-20f, -15.5f, 0f);
                    Destroy(Pos1Button.gameObject);
                    Destroy(Pos2Button.gameObject);
                    Destroy(Pos3Button.gameObject);
                });
                Pos2Button.onClick.AddListener(() =>
                {
                    card.transform.position = new Vector3(16f, -15.5f, 0f);
                    Destroy(Pos1Button.gameObject);
                    Destroy(Pos2Button.gameObject);
                    Destroy(Pos3Button.gameObject);
                });
                Pos3Button.onClick.AddListener(() =>
                {
                    card.transform.position = new Vector3(50f, -15.5f, 0f);
                    Destroy(Pos1Button.gameObject);
                    Destroy(Pos2Button.gameObject);
                    Destroy(Pos3Button.gameObject);
                });
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
                YourPos1 = true;
                OpponentsCardsInHand -= 1;
                Button Pos1Button = Instantiate(locationCard, new Vector3(-170f, 40f, 0f), Quaternion.identity);
                Pos1Button.transform.SetParent(canvas.transform, false);
                Button Pos2Button = Instantiate(locationCard, new Vector3(125f, 40f, 0f), Quaternion.identity);
                Pos2Button.transform.SetParent(canvas.transform, false);
                Button Pos3Button = Instantiate(locationCard, new Vector3(450f, 40f, 0f), Quaternion.identity);
                Pos3Button.transform.SetParent(canvas.transform, false);
                Pos1Button.onClick.AddListener(() =>
                {
                    card.transform.position = new Vector3(-20f, 15.5f, 0f);
                    Destroy(Pos1Button.gameObject);
                    Destroy(Pos2Button.gameObject);
                    Destroy(Pos3Button.gameObject);
                });
                Pos2Button.onClick.AddListener(() =>
                {
                    card.transform.position = new Vector3(16f, 15.5f, 0f);
                    Destroy(Pos1Button.gameObject);
                    Destroy(Pos2Button.gameObject);
                    Destroy(Pos3Button.gameObject);
                });
                Pos3Button.onClick.AddListener(() =>
                {
                    card.transform.position = new Vector3(50f, 15.5f, 0f);
                    Destroy(Pos1Button.gameObject);
                    Destroy(Pos2Button.gameObject);
                    Destroy(Pos3Button.gameObject);
                });
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
                YourPos1 = true;
                OpponentsCardsInHand -= 1;
                Button Pos1Button = Instantiate(locationCard, new Vector3(-170f, 40f, 0f), Quaternion.identity);
                Pos1Button.transform.SetParent(canvas.transform, false);
                Button Pos2Button = Instantiate(locationCard, new Vector3(125f, 40f, 0f), Quaternion.identity);
                Pos2Button.transform.SetParent(canvas.transform, false);
                Button Pos3Button = Instantiate(locationCard, new Vector3(450f, 40f, 0f), Quaternion.identity);
                Pos3Button.transform.SetParent(canvas.transform, false);
                Pos1Button.onClick.AddListener(() =>
                {
                    card.transform.position = new Vector3(-20f, 15.5f, 0f);
                    Destroy(Pos1Button.gameObject);
                    Destroy(Pos2Button.gameObject);
                    Destroy(Pos3Button.gameObject);
                });
                Pos2Button.onClick.AddListener(() =>
                {
                    card.transform.position = new Vector3(16f, 15.5f, 0f);
                    Destroy(Pos1Button.gameObject);
                    Destroy(Pos2Button.gameObject);
                    Destroy(Pos3Button.gameObject);
                });
                Pos3Button.onClick.AddListener(() =>
                {
                    card.transform.position = new Vector3(50f, 15.5f, 0f);
                    Destroy(Pos1Button.gameObject);
                    Destroy(Pos2Button.gameObject);
                    Destroy(Pos3Button.gameObject);
                });
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
                YourPos1 = true;
                OpponentsCardsInHand -= 1;
                Button Pos1Button = Instantiate(locationCard, new Vector3(-170f, 40f, 0f), Quaternion.identity);
                Pos1Button.transform.SetParent(canvas.transform, false);
                Button Pos2Button = Instantiate(locationCard, new Vector3(125f, 40f, 0f), Quaternion.identity);
                Pos2Button.transform.SetParent(canvas.transform, false);
                Button Pos3Button = Instantiate(locationCard, new Vector3(450f, 40f, 0f), Quaternion.identity);
                Pos3Button.transform.SetParent(canvas.transform, false);
                Pos1Button.onClick.AddListener(() =>
                {
                    card.transform.position = new Vector3(-20f, 15.5f, 0f);
                    Destroy(Pos1Button.gameObject);
                    Destroy(Pos2Button.gameObject);
                    Destroy(Pos3Button.gameObject);
                });
                Pos2Button.onClick.AddListener(() =>
                {
                    card.transform.position = new Vector3(16f, 15.5f, 0f);
                    Destroy(Pos1Button.gameObject);
                    Destroy(Pos2Button.gameObject);
                    Destroy(Pos3Button.gameObject);
                });
                Pos3Button.onClick.AddListener(() =>
                {
                    card.transform.position = new Vector3(50f, 15.5f, 0f);
                    Destroy(Pos1Button.gameObject);
                    Destroy(Pos2Button.gameObject);
                    Destroy(Pos3Button.gameObject);
                });
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
