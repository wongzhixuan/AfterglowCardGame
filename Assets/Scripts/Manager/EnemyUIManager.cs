using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
public class EnemyUIManager : Singleton<EnemyUIManager>
{
    [Header("Settings")]
    [SerializeField] private Image healthBar;
    [SerializeField] private Image manaBar;
    [SerializeField] private TextMeshProUGUI currentHealthTMP;
    [SerializeField] private TextMeshProUGUI currentManaTMP;

    // Start is called before the first frame update
    private float enemyCurrentHealth;
    private float enemyMaxHealth;
    private float enemyMaxMana;
    private float enemyCurrentMana;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InternalUpdate();
    }
    public void UpdateEnemyHealth(float currentHealth, float maxHealth, float currentMana, float maxMana)
    {
        enemyCurrentHealth = currentHealth;
        enemyMaxHealth = maxHealth;
        enemyCurrentMana = currentMana;
        enemyMaxMana = maxMana;
        
    }
    private void InternalUpdate()
    {
            healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, enemyCurrentHealth /  enemyMaxHealth, 10f * Time.deltaTime);
            currentHealthTMP.text =  enemyCurrentHealth.ToString() + "/" +  enemyMaxHealth.ToString();

            manaBar.fillAmount = Mathf.Lerp(manaBar.fillAmount,  enemyCurrentMana /  enemyMaxMana, 10f * Time.deltaTime);
            currentManaTMP.text =  enemyCurrentMana.ToString() + "/" +  enemyMaxMana.ToString();

        // Update Ammo
        //currentAmmoTMP.text = playerCurrentAmmo + " / " + playerMaxAmmo;

        //Update Coins
        
    }
}
