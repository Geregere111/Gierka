using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenuController : MonoBehaviour
{
    private Resolution[] resolutions;

    [SerializeField]
    private Dropdown resolutionDropdown;

    [SerializeField]
    private int mainMenuSceneIndex = 0;

    void Start()
    {
        if (resolutionDropdown == null)
        {
            Debug.LogError("Resolution dropdown is not assigned in the Inspector.");
            return;
        }

        resolutions = Screen.resolutions;

        if (resolutions == null || resolutions.Length == 0)
        {
            Debug.LogError("No screen resolutions found.");
            return;
        }

        resolutionDropdown.ClearOptions();

        var options = resolutions.Select(x => new Dropdown.OptionData($"{x.width} x {x.height}")).ToList();
        resolutionDropdown.AddOptions(options);

        var currentResolutionIndex = Array.FindIndex(resolutions, r => r.width == Screen.currentResolution.width && r.height == Screen.currentResolution.height);
        if (currentResolutionIndex != -1)
        {
            resolutionDropdown.value = currentResolutionIndex;
        }
        else
        {
            Debug.LogWarning("Current screen resolution not found in available resolutions list.");
        }

        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        if (resolutionIndex >= 0 && resolutionIndex < resolutions.Length)
        {
            var resolution = resolutions[resolutionIndex];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
            Debug.Log($"Resolution set to {resolution.width} x {resolution.height}");
        }
        else
        {
            Debug.LogError("Selected resolution index is out of bounds.");
        }
    }

    public void ToggleFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        Debug.Log($"Fullscreen mode set to {isFullscreen}");
    }

    public void ReturnToMainMenu()
    {

        if (mainMenuSceneIndex >= 0 && mainMenuSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(mainMenuSceneIndex);
        }
        else
        {
            Debug.LogError("Main menu scene index is out of range or invalid.");
        }
    }
}
