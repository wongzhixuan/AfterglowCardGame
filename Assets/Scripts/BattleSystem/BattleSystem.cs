using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum BattleState{ START, PLAYERTURN, ENEMYTURN, WON, LOST}
public class BattleSystem : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public Transform playerBattleStation;
    public Transform enemyBattleStation;
    public GameManager gameManager;
    public int slotIndex;
    Unit playerunit;
    Unit enemyunit;
    public TextMeshProUGUI dialoguetext;
    public GameObject LevelCompleteUI;
    public GameObject GameOverUI;
    public int manaToGainEachTurn = 2;
    private bool isDead;

    public BattleState state;
    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }
    IEnumerator SetupBattle()
    {

        GameObject playerGo = Instantiate(player, playerBattleStation);
        playerunit = playerGo.GetComponent<Unit>();
        GameObject enemyGo = Instantiate(enemy, enemyBattleStation);
        enemyunit = enemyGo.GetComponent<Unit>();
        dialoguetext.text = "A wild " + enemyunit.Unitname + " approaches...";
        
        yield return new WaitForSeconds(2f);
        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    void PlayerTurn()
    {
        player.GetComponent<Health>().GainMana(manaToGainEachTurn);
        gameManager.drawcardeEachTurn();
        dialoguetext.text = "Please choose your action:";
        
    }
    public IEnumerator PlayerAttack()
    {
        
        dialoguetext.text = "The card is activated";
        yield return new WaitForSeconds(2f);
        if(enemy.GetComponent<Enemy>().isDead == true)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }
    public IEnumerator PlayerAction()
    {
        dialoguetext.text = "Your action is successful";
        yield return new WaitForSeconds(2f);
         if(enemy.GetComponent<Enemy>().isDead == true)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }

    }

    IEnumerator EnemyTurn()
    {
        dialoguetext.text = enemyunit.Unitname + " attacks!";
        yield return new WaitForSeconds(1f);
        player.GetComponent<Health>().TakeDamage(enemyunit.damage);
        FindObjectOfType<AudioManager>().Play("spike");
        enemy.GetComponent<Animator>().SetTrigger("Attack");
        player.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Hurt");
        
        yield return new WaitForSeconds(1f);
        if(player.GetComponent<Health>().playerisDead == true)
        {
            state = BattleState.LOST ;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN ;
            PlayerTurn();
        }
    }

    public void EndBattle()
    {
        if(state == BattleState.WON)
        {
            dialoguetext.text = "You WON the Battle!";
            FindObjectOfType<AudioManager>().Play("winning");
            LevelCompleteUI.SetActive(true);
            

        }
        else if(state == BattleState.LOST)
        {
            dialoguetext.text = "You are defeated.";
            FindObjectOfType<AudioManager>().Play("die");
            GameOverUI.SetActive(true);
            

        }
    }

}
