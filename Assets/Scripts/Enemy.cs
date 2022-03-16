using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("EnemyHealth")]
    [SerializeField] private float initialHealth = 100f;
    [SerializeField] private float maxHealth = 100f;

    [Header("Mana")]
    [SerializeField] private float initialMana = 5f;
    [SerializeField] private float maxMana = 5f;

    [Header("Settings")]
    [SerializeField] private bool destroyObject;
    [SerializeField] private float dieDelay = 0.5f;
    private SpriteRenderer spriteRenderer;
    private Character character;
    private Animator animator;

    // Controls the current health of the object    
    public float EnemyCurrentHealth { get; set; }

    // Returns the current mana of this character
    public float EnemyCurrentMana { get; set; }

    private readonly int dietrigger = Animator.StringToHash("enemyDie");
    public bool isDead = false;
     public GameObject LevelCompleteUI;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<Character>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = character.CharacterAnimator;
        EnemyCurrentHealth = initialHealth;
        EnemyCurrentMana = initialMana;
        UpdateEnemyHealth();
    }

    // Update is called once per frame
    void Update()
    {
        if(EnemyCurrentHealth <= 0)
        {
             LevelCompleteUI.SetActive(true);
        }
    }
    public void enemyTakeDamange(int damage)
    {
        if (EnemyCurrentHealth <= 0)
        {
            isDead = true;
            return ;
        }

        EnemyCurrentHealth -= damage;
        UpdateEnemyHealth();

        if (EnemyCurrentHealth <= 0)
        {
            //Die animation
            isDead = true;
            animator.SetTrigger(dietrigger);
            // controller.enabled = false;
            // healthcollider2D.enabled = false;
            character.enabled = false;
            Invoke("Die", dieDelay);
            
        }
    }
    private void Die()
    {
        if (character != null)
        {
            //destroy gameobject
            spriteRenderer.enabled = false;
            
        }

        if (destroyObject)
        {
            DestroyObject();
        }
    }
    public void EnemyGainHealth(int amount)
    {
        EnemyCurrentHealth = Mathf.Min(EnemyCurrentHealth + amount, maxHealth); //Logic if full HP, cannot add anymore
        UpdateEnemyHealth();
    }
    public void EnemyGainMana(int amount)
    {
        EnemyCurrentMana = EnemyCurrentMana + amount;
        UpdateEnemyHealth();
    }

    private void UpdateEnemyHealth()
    {
        EnemyUIManager.Instance.UpdateEnemyHealth(EnemyCurrentHealth, maxHealth, EnemyCurrentMana, maxMana);
    }
    // If destroyObject is selected, we destroy this game object
    private void DestroyObject()
    {
        gameObject.SetActive(false);
    }

}
