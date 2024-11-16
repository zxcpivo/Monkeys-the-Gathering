using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawcards : MonoBehaviour
{
    public GameObject Card1;
    public GameObject Card2;
    public GameObject Card3;
    public GameObject PlayerArea;
    public GameObject OpponentArea;

    void Start()
    {
        
    }

    public void OnClick()
    {
        GameObject playerCard = Instantiate(Card1, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
