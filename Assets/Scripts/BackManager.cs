using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackManager : MonoBehaviour
{
    public void BackAction()
    {
        SceneManager.LoadSceneAsync("MainMenuScene");
    }
}
