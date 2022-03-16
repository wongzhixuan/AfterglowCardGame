using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CardUIManager : CardDisplay
{
    public CardManager cardManager;
    public GameObject[] cardSlots;

    public int page = 0;
    public TextMeshProUGUI pageText;

    //For serach function
    [SerializeField] private bool isSearch;
    [SerializeField] private int totalNum;
    [SerializeField] private int currentSearchMana;

    [SerializeField] private bool issearchmana;
    [SerializeField] private bool issearchclass;
    [SerializeField] private string currentSearchClass;
    private void Start()
    {
        // Debug.Log(cardManager.cards.Count);

        DisplayCards(page);
        UpdatePageUI();
    }

    private void Update()
    {
        if (!isSearch)
        {
            totalNum = 0;
        }
    }

    private void UpdatePageUI()
    {
        if (!isSearch)
        {
            pageText.text = (page + 1) + "/" + (Mathf.Ceil(cardSlots.Length / 10) + 1).ToString();
        }
        else
        {
            pageText.text = (page + 1) + "/" + (Mathf.Ceil(totalNum / 10) + 1).ToString();
        }
        //pageText.text = (page + 1).ToString();

    }
    public void InitialCardsTab()
    {
        page = 0;
        isSearch = false;
        DisplayCards(page);

        issearchclass = false;
        issearchmana = false;
        UpdatePageUI();
    }

    // public void SearchByMana(int _mana)
    // {
    //     totalNum = 0;
    //     isSearch = true;
    //     for (int i = 0; i < cardManager.cards.Count; i++)
    //     {
    //         if (_mana < 8)
    //         {
    //             if (cardManager.cards[i].manaCost == _mana)
    //             {
    //                 totalNum ++;
    //                 cardSlots[i].gameObject.SetActive(true);
    //                 cardSlots[i].GetComponent<CardDisplay>().card = cardManager.cards[i];
    //             }
    //             else
    //             {
    //                 cardSlots[i].gameObject.SetActive(false);
    //             }

    //         }
    //         else
    //         {
    //             if (cardManager.cards[i].manaCost >= _mana)
    //             {
    //                 totalNum ++;
    //                 cardSlots[i].gameObject.SetActive(true);
    //                 cardSlots[i].GetComponent<CardDisplay>().card = cardManager.cards[i];
    //             }
    //             else
    //             {
    //                 cardSlots[i].gameObject.SetActive(false);
    //             }

    //         }


    //      }

    // }

    public void SearchByMana(int _mana)
    {
        issearchclass = false;
        issearchmana = true;
        totalNum = 0;
        isSearch = true;
        page = 0;
        currentSearchMana = _mana;

        List<Card> cards = new List<Card>();
        cards = ReturnCard(_mana);

        DisplayCardWhenTab(cards);
        UpdatePageUI();

    }
    private void DisplayCardWhenTab(List<Card> _cards)
    {
        for (int i = 0; i < cardSlots.Length; i++)
        {
            cardSlots[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < _cards.Count; i++)
        {
            if (i >= page * 10 && i < (page + 1) * 10)
            {
                totalNum++;
                cardSlots[i].gameObject.SetActive(true);
                cardSlots[i].GetComponent<CardDisplay>().card = _cards[i];

            }
            else
            {
                cardSlots[i].gameObject.SetActive(false);
            }

        }  
    }
    public List<Card> ReturnCard(int _mana)
    {
        List<Card> cards = new List<Card>();
        for (int i = 0; i < cardManager.cards.Count; i++)
        {
            Card card;
            if (_mana < 8)
            {
                if (cardManager.cards[i].manaCost == _mana)
                {
                    card = cardManager.cards[i];
                    cards.Add(card);
                }
            }
            else
            {
                if (cardManager.cards[i].manaCost >= _mana)
                {
                    card = cardManager.cards[i];
                    cards.Add(card);
                }
            }
        }
        return cards;
    }

    public List<Card> ReturnCard(string _cardClass)
    {
        List<Card> cards = new List<Card>();
        for (int i = 0; i < cardManager.cards.Count; i++)
        {
            Card card;
            if (cardManager.cards[i].cardClass.ToString() == _cardClass)
            {
                card = cardManager.cards[i];
                cards.Add(card);
            }
        }
        return cards;
    }
    public void SearchByClass(string _cardClass)
    {
        issearchclass = true;
        issearchmana = false;
        isSearch = true;
        totalNum = 0;
        page = 0;
        currentSearchClass = _cardClass;
        List<Card> cards = new List<Card>();
        cards = ReturnCard(_cardClass);

        DisplayCardWhenTab(cards);
        UpdatePageUI();
    }

    private void DisplayCards(int _page)
    {
        for (int i = 0; i < cardManager.cards.Count; i++)
        {
            if (i >= _page * 10 && i < (_page + 1) * 10)
            {
                cardSlots[i].gameObject.SetActive(true);
                cardSlots[i].GetComponent<CardDisplay>().card = cardManager.cards[i];

            }
            else
            {
                cardSlots[i].gameObject.SetActive(false);
            }
        }

    }

    public void TurnNextPage()
    {
        if (!isSearch)
        {
            if (page >= Mathf.Floor((cardManager.cards.Count - 1) / 10))
            {
                page = 0;
            }
            else
            {
                page++;
            }
            DisplayCards(page);
            UpdatePageUI();
        }
        else
        {
            if (issearchmana)
            {
                if (page >= (Mathf.FloorToInt(totalNum / 10)))
                {
                    page = 0;
                }
                else
                {
                    page++;
                }
                DisplayBySearchMana();
                UpdatePageUI();
            }
            if (issearchclass)
            {
                if (page >= (Mathf.FloorToInt(totalNum / 10)))
                {
                    page = 0;
                }
                else
                {
                    page++;
                }
                DisplayBySearchClass();
                UpdatePageUI();
            }
        }

    }

    public void TurnPrevPage()
    {
        if (!isSearch)
        {
            if (page <= 0)
            {
                page = Mathf.FloorToInt((cardManager.cards.Count - 1) / 10);
            }
            else
            {
                page--;
            }
            DisplayCards(page);
            UpdatePageUI();
        }
        else
        {
            if (issearchmana)
            {
                if (page <= 0)
                {
                    page = (Mathf.FloorToInt(totalNum / 10));
                }
                else
                {
                    page--;
                }
                DisplayBySearchMana();
                UpdatePageUI();
            }
            if (issearchclass)
            {
                if (page <= 0)
                {
                    page = (Mathf.FloorToInt(totalNum / 10));
                }
                else
                {
                    page--;
                }
                DisplayBySearchClass();
                UpdatePageUI();
            }
        }


    }
    private void TurnPage()
    {
        // if (!isSearch)
        // {
        //     if (nxtpg == true)
        //     {
        //         //next page
        //         if (page >= Mathf.Floor((cardManager.cards.Count - 1) / 10))
        //         {
        //             page = 0;

        //         }
        //         else
        //         {
        //             page++;
        //         }
        //         Debug.Log(page);
        //         DisplayCards();
        //         nxtpg = false;
        //     }
        //     if (prevpg == true)
        //     {
        //         //previous page

        //         prevpg = false;

        //     }

        // }
        // else
        // {
        //     if (issearchmana)
        //     {
        //         if (nxtpg == true)
        //         {
        //             if (page >= (Mathf.FloorToInt(totalNum / 10)))
        //             {
        //                 page = 0;
        //             }
        //             else
        //             {
        //                 page++;
        //             }
        //             DisplayBySearchMana();
        //             nxtpg = false;
        //         }
        //         if (prevpg == true)
        //         {
        //             if (page <= 0)
        //             {
        //                 page = (Mathf.FloorToInt(totalNum / 10));
        //             }
        //             else
        //             {
        //                 page--;
        //             }
        //             DisplayBySearchMana();
        //             prevpg = false;
        //         }

        //     }
        //     if (issearchclass)
        //     {
        //         if (nxtpg == true)
        //         {
        //             if (page >= (Mathf.FloorToInt(totalNum / 10)))
        //             {
        //                 page = 0;
        //             }
        //             else
        //             {
        //                 page++;
        //             }
        //             DisplayBySearchClass();
        //             nxtpg = false;
        //         }
        //         if (prevpg == true)
        //         {
        //             if (page <= 0)
        //             {
        //                 page = (Mathf.FloorToInt(totalNum / 10));
        //             }
        //             else
        //             {
        //                 page--;
        //             }
        //             DisplayBySearchClass();
        //             prevpg = false;
        //         }

        //     }

        // }
    }

    private void DisplayBySearchMana()
    {
        issearchclass = false;
        issearchmana = true;
        List<Card> cards = new List<Card>();
        cards = ReturnCard(currentSearchMana);

        for (int i = 0; i < cardSlots.Length; i++)
        {
            cardSlots[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < cards.Count; i++)
        {
            if (i >= page * 10 && i < (page + 1) * 10)
            {
                cardSlots[i].gameObject.SetActive(true);
                cardSlots[i].GetComponent<CardDisplay>().card = cards[i];
            }
            else
            {
                cardSlots[i].gameObject.SetActive(false);
            }


        }
    }
    private void DisplayBySearchClass()
    {
        issearchclass = true;
        issearchmana = false;
        List<Card> cards = new List<Card>();
        cards = ReturnCard(currentSearchClass);

        for (int i = 0; i < cardSlots.Length; i++)
        {
            cardSlots[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < cards.Count; i++)
        {
            if (i >= page * 10 && i < (page + 1) * 10)
            {
                cardSlots[i].gameObject.SetActive(true);
                cardSlots[i].GetComponent<CardDisplay>().card = cards[i];
            }
            else
            {
                cardSlots[i].gameObject.SetActive(false);
            }

        }
    }


}
