using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCoin : Collectables
{
    [SerializeField] private int coinsToAdd = 20;
    [SerializeField] private ParticleSystem coinBonus;

    protected override void PlayEffects()
    {
        Instantiate(coinBonus, transform.position, Quaternion.identity);
    }
    protected override void Pick()
    {
        AddCoins();
    }

    private void AddCoins()
    {
        CoinManager.Instance.AddCoins(coinsToAdd);
    }

}
