using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public CardManager cardManager;
    public Deck deckManager;
    public GameObject[] HandSlots;
    public GameObject[] DeckSlots;
    public GameObject[] DiscardSlots;
    
    public GameObject player;
    public GameObject enemy;
    public List<Card> handCards = new List<Card>();
    private int InitialNumOfCards = 3;
    public int CardstoDraw = 1;
    public GameObject UnableToDraw;
    private bool turnCardBack = false;
    public BattleSystem battle;
    public GameObject[] shieldSlots;


    // Start is called before the first frame update
    void Awake()
    {
       
    }
    private void displayCards(GameObject[] gameObjects, List<Card> cardList, bool turnCardBack)
    {
        int i = gameObjects.Length - 1;
        int cardsLeft = cardList.Count;
        int cardIndex = 0;
        while( i >= 0)
        {
            if(cardsLeft > 0)
            {
             gameObjects[i].gameObject.SetActive(true);
             gameObjects[i].GetComponent<CardDisplay>().card = cardList[cardIndex];
             cardIndex++;
             cardsLeft--;
             if(turnCardBack == true)
             {
                gameObjects[i].GetComponent<CardDisplay>().showCardBack = true;
             }
            }
            else
            {
                gameObjects[i].gameObject.SetActive(false);
            }
            i--;
        }
       
    }

   public void drawCards()
    {
        if (battle.state != BattleState.PLAYERTURN)
        {
            return;
        }
        List<Card> drawnCards = new List<Card>();
        if (handCards.Count <= 0)
        {
            drawnCards = deckManager.Draw(InitialNumOfCards);
            for(int i = 0; i < drawnCards.Count; i++)
            {
                handCards.Add(drawnCards[i]);
            }
        }
        else if (handCards.Count >= HandSlots.Length )
        {
            UnableToDraw.SetActive(true);
        }
        else
        {
            drawnCards = deckManager.Draw(CardstoDraw);
            for(int i = 0; i < drawnCards.Count; i++)
            {
                handCards.Add(drawnCards[i]);
            }
            StartCoroutine(battle.PlayerAction());
        }

    }
    public void drawcardeEachTurn()
    {
        if (battle.state != BattleState.PLAYERTURN)
        {
            return;
        }
        if(deckManager.deck.Count <= 0 && handCards.Count <=0 &&  enemy.GetComponent<Enemy>().EnemyCurrentHealth>0)
        {
            battle.state = BattleState.LOST;
            battle.EndBattle();
        }
 
        List<Card> drawnCards = new List<Card>();
        if (handCards.Count <= 0)
        {
            drawnCards = deckManager.Draw(InitialNumOfCards);
            for(int i = 0; i < drawnCards.Count; i++)
            {
                handCards.Add(drawnCards[i]);
            }
        }
        else if (handCards.Count >= HandSlots.Length )
        {
            UnableToDraw.SetActive(true);
        }
        else
        {
            drawnCards = deckManager.Draw(CardstoDraw);
            for(int i = 0; i < drawnCards.Count; i++)
            {
                handCards.Add(drawnCards[i]);
            }
        }
    }

    public void discardCards(GameObject Thisgameobject)
    {
        if(Thisgameobject.GetComponent<CardDisplay>().card != null)
        {
            deckManager.DiscardCard(Thisgameobject.GetComponent<CardDisplay>().card);
            
        }
        
    }
    public void applySkill(GameObject Thisgameobject)
    {
        if(Thisgameobject.GetComponent<CardDisplay>().card != null)
        {
            player.GetComponent<Health>().ConsumeMana(Thisgameobject.GetComponent<CardDisplay>().card.manaCost);
            
            if(Thisgameobject.GetComponent<CardDisplay>().card.hp != 0)
            {
                player.GetComponent<Health>().GainHealth(Thisgameobject.GetComponent<CardDisplay>().card.hp);
            }
            if(Thisgameobject.GetComponent<CardDisplay>().card.attack > 0)
            {
                player.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Attack");
                FindObjectOfType<AudioManager>().Play("spike");
                enemy.GetComponent<Animator>().SetTrigger("Hurt");
                enemy.GetComponent<Enemy>().enemyTakeDamange(Thisgameobject.GetComponent<CardDisplay>().card.attack);
            }
            if(Thisgameobject.GetComponent<CardDisplay>().card.shield > 0)
            {
                player.GetComponent<Health>().GainShield(Thisgameobject.GetComponent<CardDisplay>().card.shield);
            }
            deckManager.DiscardCard(Thisgameobject.GetComponent<CardDisplay>().card);

        }
    }
    public void displayShield()
    {
        float shieldleft;
        shieldleft = player.GetComponent<Health>().CurrentShield;
        
        for( int i = 0; i < shieldSlots.Length; i++)
        {
            if(shieldleft > 0)
            {
             shieldSlots[i].gameObject.SetActive(true);
             shieldleft--;
            }
            else
            {
                shieldSlots[i].gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        displayCards(DeckSlots, deckManager.deck,true);
        displayCards(HandSlots, handCards,false);
        displayCards(DiscardSlots, deckManager.discard,true); 
        displayShield();
        
        //check player action
    }
}
