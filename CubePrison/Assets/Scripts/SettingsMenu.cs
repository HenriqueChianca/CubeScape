using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer mixer;
    Resolution[] resolutiuons;
    public Dropdown resDropdown;

    void Start()
    {
        resolutiuons = Screen.resolutions;
        resDropdown.ClearOptions();
        List<string> options = new List<string>();

        int currentResIndex = 0;
        for (int i = 0; i < resolutiuons.Length; i++)
        {
            String option = resolutiuons[i].width + " x " + resolutiuons[i].height + " " + resolutiuons[i].refreshRateRatio + "hz";
            options.Add(option);
            if (resolutiuons[i].width == Screen.currentResolution.width && resolutiuons[i].height == Screen.currentResolution.height)
            {
                currentResIndex = i;
            }
        }

        resDropdown.AddOptions(options);
        resDropdown.value = currentResIndex;
        resDropdown.RefreshShownValue();
    }

    public void SetResolution(int resIndex)
    {
        Resolution resolution = resolutiuons[resIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetMainVolume(float volume)
    {
        mixer.SetFloat("main", volume);
    }
    public void SetMusicVolume(float volume)
    {
        mixer.SetFloat("music", volume);
    }
    public void SetSfxVolume(float volume)
    {
        mixer.SetFloat("sfx", volume);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}