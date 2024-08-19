using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    [SerializeField]
    private int settingsSceneIndex = 1;

    public void StartGame()
    {
        Debug.Log("Loading game scene ...");
    }

    public void OpenSettings()
    {

        if (settingsSceneIndex >= 0 && settingsSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            Debug.Log("Loading settings scene with index: " + settingsSceneIndex);
            SceneManager.LoadScene(settingsSceneIndex);
        }
        else
        {
            Debug.LogError("Settings scene index is out of range or invalid.");
        }
    }

    public void CloseWindow()
    {

        Debug.Log("Quitting application...");
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

}
