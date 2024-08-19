using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsControllerScript : MonoBehaviour
{

    Resolution[] resolutions;

    public Dropdown resolutionDropdown;

    void Start()
    {

        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();
        resolutionDropdown.options = resolutions.Select(x => new Dropdown.OptionData($"{x.width} x {x.height}")).ToList();
        resolutionDropdown.RefreshShownValue();

    }

    public void SetResolution(int resolutionIndex)
    {
        Debug.Assert(resolutionIndex <= resolutions.Length, "Resolution out of bound");

        var resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void ToggleFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
