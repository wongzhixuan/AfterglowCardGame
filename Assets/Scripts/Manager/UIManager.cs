using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [Header("Settings")]
    [SerializeField] private Image healthBar;
    [SerializeField] private Image manaBar;
    [SerializeField] private TextMeshProUGUI currentHealthTMP;
    [SerializeField] private TextMeshProUGUI currentManaTMP;

    [Header("Text")] 
    [SerializeField] private TextMeshProUGUI coinsTMP;


    /*
        [Header("Weapon")]
        [SerializeField] private TextMeshProUGUI currentAmmoTMP;
        [SerializeField] private Image weaponImage;
    */

    private float playerCurrentHealth;
    private float playerMaxHealth;
    private float playerMaxMana;
    private float playerCurrentMana;
    private bool isPlayer;



    //private int playerCurrentAmmo;
    //private int playerMaxAmmo;

    private void Update()
    {
        InternalUpdate();
    }

    public void UpdateHealth(float currentHealth, float maxHealth, float currentMana, float maxMana, bool isThisMyPlayer)
    {
        playerCurrentHealth = currentHealth;
        playerMaxHealth = maxHealth;
        playerCurrentMana = currentMana;
        playerMaxMana = maxMana;
        isPlayer = isThisMyPlayer;
    }
    /*
    public void UpdateWeaponSprite(Sprite weaponSprite)
    {
        weaponImage.sprite = weaponSprite;
        weaponImage.SetNativeSize();
    }

    public void UpdateAmmo(int currentAmmo, int maxAmmo)
    {
        playerCurrentAmmo = currentAmmo;
        playerMaxAmmo = maxAmmo;
    }
    */

    private void InternalUpdate()
    {
        if (isPlayer)
        {
            healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, playerCurrentHealth / playerMaxHealth, 10f * Time.deltaTime);
            currentHealthTMP.text = playerCurrentHealth.ToString() + "/" + playerMaxHealth.ToString();

            manaBar.fillAmount = Mathf.Lerp(manaBar.fillAmount, playerCurrentMana / playerMaxMana, 10f * Time.deltaTime);
            currentManaTMP.text = playerCurrentMana.ToString() + "/" + playerMaxMana.ToString();
        }
        
        // Update Ammo
        //currentAmmoTMP.text = playerCurrentAmmo + " / " + playerMaxAmmo;

        //Update Coins
        coinsTMP.text = CoinManager.Instance.Coins.ToString();
        
    }

}
