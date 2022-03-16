using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadCombat : MonoBehaviour
{
    public GameObject EnterCombatUI;
    public void LoadCombatMode()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Additive);
        EnterCombatUI.SetActive(false);

    }
}
