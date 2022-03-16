using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public CardManager cardMgn;
    public List<Card> deck = new List<Card>();
    public List<Card> discard = new List<Card>();
    
    [SerializeField] public int numberToDraw = 1;
    [SerializeField] bool OnTop = true;
    public void Start()
    {
        Debug.Log("DeckStart");
        for(int i = 0; i < cardMgn.cards.Count; i++)
        {
            deck.Add(cardMgn.cards[i]);
            Debug.Log("DeckAdd");
        }

        Shuffle(deck);
    }
    // public Deck(List<Card> cards)
    // {
    //     this.cards = cards;
    //     discard = new List<Card>();
    // }

    //Shuffle the current deck of cards
    public void Shuffle(List<Card> targetlist)
    {
        for(int i = targetlist.Count - 1; i > 0; --i)
        {
            int j = Random.Range(0, i + 1);
            Card card = targetlist[j];
            targetlist[j] = targetlist[i];
            targetlist[i] = card;
        }
    }
    //Return a list of drawn cards from deck
    public List<Card> Draw(int numberToDraw)
    {
        if(numberToDraw > deck.Count)
        {
            numberToDraw = deck.Count;
        }
        List<Card> drawnCards = new List<Card>();
        for (int i = 0; i < numberToDraw; ++i)
        {
            deck[0].isCardBack = false;
            drawnCards.Add(deck[0]);
            deck.RemoveAt(0);
        }
        return drawnCards;
    }

    //Return a list of drawn cards from discard
    public List<Card> DrawDiscard(int numberToDraw)
    {
        if (numberToDraw  > discard.Count)
        {
            numberToDraw = discard.Count;
        }
        List<Card> drawnCards = new List<Card>();
        for (int i =0;i<numberToDraw;++i)
        {
            drawnCards.Add(discard[0]);
            discard.RemoveAt(0);
        }
        return drawnCards;
    }

    // Put a card back, default is top set bool to false to put it on the bottom
    public void ReturnCard(Card card, bool onTop)
    {
        card.isCardBack = true;
        if (onTop)
        {
           deck.Insert(0, card);
        }
        else
        {
            deck.Add(card);
        }
    }
 
    public void DiscardCard(Card card)
    {
        discard.Insert(0, card);
    }
 
    public void ShuffleDiscard()
    {
        foreach(Card OneCard in discard)
        {
            OneCard.isCardBack = true;
            deck.Add(OneCard);
        }
        discard.Clear();
        Shuffle(deck);
    }
}
