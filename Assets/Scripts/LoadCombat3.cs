using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadCombat3 : MonoBehaviour
{
    public GameObject EnterCombatUI;
    public void LoadCombatMode()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4, LoadSceneMode.Additive);
        EnterCombatUI.SetActive(false);

    }
}
