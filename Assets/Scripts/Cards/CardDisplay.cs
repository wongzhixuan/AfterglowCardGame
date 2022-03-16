using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Card card;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;

    public Image artworkImage;
    
    public TextMeshProUGUI manaText;
    public TextMeshProUGUI attackText;
    public TextMeshProUGUI hpText;

    public TextMeshProUGUI CardClassText;
    public bool showCardBack = false;
    public GameObject cardback;
    public bool isClicked = false;


    // Start is called before the first frame update
    void Start()
    {
        nameText.text = card.name;
        descriptionText.text = card.description;

        artworkImage.sprite = card.artwork;

        manaText.text = card.manaCost.ToString();
        attackText.text = card.attack.ToString();
        hpText.text = card.hp.ToString();

        CardClassText.text = card.cardClass.ToString();
        showCardBack = card.isCardBack;
        
    }

    // Update is called once per frame
    void Update()
    {
        nameText.text = card.name;
        descriptionText.text = card.description;

        artworkImage.sprite = card.artwork;

        manaText.text = card.manaCost.ToString();
        attackText.text = card.attack.ToString();
        hpText.text = card.hp.ToString();

        CardClassText.text = card.cardClass.ToString();
        if (showCardBack == true)
        {
            cardback.SetActive(true);
        }
        else
        {
            cardback.SetActive(false);
        }

        
    }

}
