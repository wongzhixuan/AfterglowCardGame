using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class MouseClick : MonoBehaviour
{
    public GameObject player;
    public GameObject unableUseUI;
    public GameManager gameManager;
    public int slotIndex;
    public BattleSystem battle;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void discardThisCard()
    {
        if (battle.state != BattleState.PLAYERTURN)
        {
            return;
        }
        gameManager.handCards.RemoveAt(4 - slotIndex);
        // thiscard.GetComponent<CardDisplay>().isClicked = true;
        gameManager.discardCards(gameManager.HandSlots[slotIndex]);
        StartCoroutine(battle.PlayerAction());
        // thiscard.GetComponent<CardDisplay>().isClicked = false;

    }
    public void activateThisCard()
    {
        if (battle.state != BattleState.PLAYERTURN)
        {
            return;
        }
        if (gameManager.HandSlots[slotIndex].GetComponent<CardDisplay>().card.manaCost <= player.GetComponent<Health>().CurrentMana)
        {
            gameManager.handCards.RemoveAt(4 - slotIndex);
            gameManager.applySkill(gameManager.HandSlots[slotIndex]);
            StartCoroutine(battle.PlayerAttack());
        }
        else
        {
            unableUseUI.SetActive(true);
        }
        // thiscard.GetComponent<CardDisplay>().isClicked = true;

    }
}
