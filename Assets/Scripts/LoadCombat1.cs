using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadCombat1 : MonoBehaviour
{
    public GameObject EnterCombatUI;
    public void LoadCombatMode1()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2, LoadSceneMode.Additive);
        EnterCombatUI.SetActive(false);

    }
}
