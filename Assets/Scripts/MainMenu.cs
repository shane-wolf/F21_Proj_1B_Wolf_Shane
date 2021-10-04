using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ViewAboutScene()
    {
        SceneManager.LoadSceneAsync("MenuOptionAboutScene");
    }

    public void ViewSettingsScene()
    {
        SceneManager.LoadSceneAsync("MenuOptionSettingsScene");
    }

    public void ViewRollCharacterScene()
    {
        SceneManager.LoadSceneAsync("MenuOptionRollCharacterScene");
    }

    public void ViewPlayScene()
    {
        if ((Character.Instance != null) && (Character.Instance.jsonCharacterString.Length > 0))
        {
            Debug.Log("jsonCharacterString:" + Character.Instance.jsonCharacterString);
            Debug.Log("Character.Instance.text:" + Character.Instance.characterNameInputField.text);
            SceneManager.LoadSceneAsync("MenuOptionPlayScene");
        }
    }

    public void Exit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
