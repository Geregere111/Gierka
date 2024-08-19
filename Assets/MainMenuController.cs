using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    public void StartGame(){
        Debug.Log("Loading next scene...");
    }

    public void OpenSettings(){
        SceneManager.LoadScene(1);
    }

    public void CloseWindow(){
        Application.Quit();
    }

}
