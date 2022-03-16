using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentBase : MonoBehaviour
{
    [Header("Sprite")]
    [SerializeField] private Sprite damagedSprite;


    [Header("Settings")]
    [SerializeField] private bool giveReward;

    private SpriteRenderer spriteRenderer;
    private JarReward jarReward;
    private Collider2D componentcollider2D;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        jarReward = GetComponent<JarReward>();
        componentcollider2D = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (giveReward)
        {
            spriteRenderer.sprite = damagedSprite;
        }
        else
        {
            spriteRenderer.sprite = damagedSprite;
            componentcollider2D.enabled = false;   
            jarReward.GiveReward();             
        }
    }

}
