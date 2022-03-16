using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadCombat4 : MonoBehaviour
{
    public GameObject EnterCombatUI;
    public void LoadCombatMode()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5, LoadSceneMode.Additive);
        EnterCombatUI.SetActive(false);

    }
}
