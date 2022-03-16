using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class cardBack : MonoBehaviour
{

    public GameObject cardback;
    Card card;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (card.isCardBack == true)
        {
            cardback.SetActive(true);
        }
        else
        {
            cardback.SetActive(false);
        }


    }
}
