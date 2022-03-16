using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float initialHealth = 100f;
    [SerializeField] private float maxHealth = 100f;

    [Header("Mana")]
    [SerializeField] private float initialMana = 5f;
    [SerializeField] private float maxMana = 5f;

    [Header("Settings")]
    [SerializeField] private bool destroyObject;
    [SerializeField] private float dieDelay = 0.5f;
    [Header("Shield")]
    [SerializeField] public float maxShield = 10f;
     public float initialShield = 0f;

    private Character character;
    private CharacterController controller;
    private Collider2D healthcollider2D;
    private SpriteRenderer spriteRenderer;
    private bool isPlayer;

    // Controls the current health of the object    
    public float CurrentHealth { get; set; }

    // Returns the current mana of this character
    public float CurrentMana { get; set; }
    public float CurrentShield ;
   
    public bool playerisDead = false;
    private bool ShieldBroke;
    private float shieldWehave;

    private Animator animator;
    private readonly int dietrigger = Animator.StringToHash("dieProcess");
    public GameObject GameOverUI;

    private void Awake()
    {
        character = GetComponent<Character>();
        controller = GetComponent<CharacterController>();
        healthcollider2D = GetComponent<Collider2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = character.CharacterAnimator;

        CurrentHealth = initialHealth;
        CurrentMana = initialMana;
        CurrentShield = initialShield;
        if (character != null)
        {
            isPlayer = character.CharacterType == Character.CharacterTypes.Player;
        }
        UpdateCharacterHealth();
    }

    
    private void Update()
    {
       /* 
        if (Input.GetKeyDown(KeyCode.L))
         {
             TakeDamage(100);
         }
        */
        if(CurrentHealth <= 0)
        {
            GameOverUI.SetActive(true);
        }
        
    }
    

    // Take the amount of damage we pass in parameters
    public void TakeDamage(int damage)
    {
        if (CurrentHealth <= 0)
        {
            return;
        }
        if (!ShieldBroke && character != null)
        {
            shieldWehave = CurrentShield;
            CurrentShield -= damage;
            //UIManager.Instance.UpdateHealth(CurrentHealth, maxHealth, CurrentShield, maxShield, isPlayer);
            // UpdateCharacterHealth();
            if (CurrentShield <= 0)
            {
              ShieldBroke = true;
              CurrentHealth = CurrentHealth - (damage - shieldWehave);
               UpdateCharacterHealth();
               CurrentShield = 0;
            }
            return;
        }

        CurrentHealth -= damage;
        UpdateCharacterHealth();

        if (CurrentHealth <= 0)
        {
            playerisDead = true;
            //Die animation
            animator.SetTrigger(dietrigger);
            controller.enabled = false;
            healthcollider2D.enabled = false;
            character.enabled = false;
            Invoke("Die", dieDelay);
        }
    }
    public void ConsumeMana(int mana)
    {
        if(CurrentMana <= 0)
        {
            return;
        }
        CurrentMana -= mana;
        UpdateCharacterHealth();

    }

    // Kills the game object
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

    // Revive this game object    
    public void Revive()
    {
        if (character != null)
        {
            healthcollider2D.enabled = true;
            spriteRenderer.enabled = true;

            character.enabled = true;
            controller.enabled = true;
        }

        gameObject.SetActive(true);

        CurrentHealth = initialHealth;
        CurrentMana = initialMana;
        UpdateCharacterHealth();
    }
    public void GainHealth(int amount)
    {
        CurrentHealth = Mathf.Min(CurrentHealth + amount, maxHealth); //Logic if full HP, cannot add anymore
        UpdateCharacterHealth();
    }
    public void GainMana(int amount)
    {
        CurrentMana = CurrentMana + amount;
        UpdateCharacterHealth();
    }
    public void GainShield(int amount)
    {
        CurrentShield = Mathf.Min(CurrentShield + amount, maxHealth);
        ShieldBroke = false;
    }

    // If destroyObject is selected, we destroy this game object
    private void DestroyObject()
    {
        gameObject.SetActive(false);
    }

    private void UpdateCharacterHealth()
    {        
        // Update Player health
        if (character != null)
        {
            UIManager.Instance.UpdateHealth(CurrentHealth, maxHealth, CurrentMana, maxMana, isPlayer);
            
        }
    }   
}
