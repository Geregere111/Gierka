using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager.UI;
using UnityEditor.SearchService;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{

    public void StartGame(){
        Debug.Log("Loading next scene...");
    }

    public void OpenSettings(){
        Debug.Log("Loading settings menu...");
    }

    public void CloseWindow(){
        Application.Quit();
    }

}
