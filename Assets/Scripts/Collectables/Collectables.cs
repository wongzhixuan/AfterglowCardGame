using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private bool canDestroyItem = true;

    protected Character character;
    protected GameObject objectCollided;
    protected SpriteRenderer spriteRenderer;
    protected Collider2D collectablecollider2D;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collectablecollider2D = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        objectCollided = other.gameObject;
        if (IsPickable())
        {
            Pick();
            PlayEffects();

            if (canDestroyItem)
            {
                Destroy(gameObject);
            }
            else
            {
                spriteRenderer.enabled = false;
                collectablecollider2D.enabled = false;
            }
        }
    }

    protected virtual bool IsPickable()
    {
        character = objectCollided.GetComponent<Character>();
        if (character == null)
        {
            return false;
        }

        return character.CharacterType == Character.CharacterTypes.Player;
    }

    protected virtual void Pick()
    {
        // ---
    }

    protected virtual void PlayEffects()
    {
        // -------        
    }
}
