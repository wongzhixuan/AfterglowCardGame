using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMana : Collectables
{

    [SerializeField] private int manaToAdd = 1;
    [SerializeField] private ParticleSystem manaEffect;

    protected override void Pick()
    {
        AddMana(character);
    }

    protected override void PlayEffects()
    {
        Instantiate(manaEffect, transform.position, Quaternion.identity);
    }

    public void AddMana(Character characterHealth)
    {
        characterHealth.GetComponent<Health>().GainMana(manaToAdd);
    }

}
