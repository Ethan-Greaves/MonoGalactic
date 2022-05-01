// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;
// using UnityEngine.UI;
// using TMPro;
// using UnityEngine.Audio;

// public class MenuManager : MonoBehaviour
// {
//     [SerializeField] TMPro.TMP_Dropdown m_ResolutionDropdown;
//     [SerializeField] Slider m_MusicVolumeSlider;
//     [SerializeField] Slider m_SFXVolumeSlider;
//     [SerializeField] Toggle m_FullscreenToggle;

//     private Resolution[] m_Resolutions;
//     private int m_defaultResolution;


//     private void Awake()
//     {
//         m_defaultResolution = 0;

//         //This ensures that when going back and forth between screens the slider value always stays consistent
//         m_MusicVolumeSlider.value = SoundManager.Instance().GetAudioSourceVolume(SoundManager.Instance().GetMusicAudioSource());
//         m_SFXVolumeSlider.value = SoundManager.Instance().GetAudioSourceVolume(SoundManager.Instance().GetSFXAudioSource());

//         m_FullscreenToggle.isOn = Screen.fullScreen;
//     }

//     public void Start()
//     {
//         AddResolutionsToDropdown();
//         SetDefaultResolution();
//     }

//     private void AddResolutionsToDropdown()
//     {
//         //Save all of the available resolutions when the scene loads up.
//         m_Resolutions = Screen.resolutions;

//         //clear all the preset options in the dropdown so there is a clean slate 
//         m_ResolutionDropdown.ClearOptions();

//         //Create a list of type strings 
//         List<string> resolutionOptions = new List<string>();

//         //Loop through the resolutions array and add the resolutions to the list as strings
//         for (int i = 0; i < m_Resolutions.Length; i++)
//         {
//             string resolutionOption = m_Resolutions[i].width + " x " + m_Resolutions[i].height;
//             resolutionOptions.Add(resolutionOption);

//             //if the resolution index in the array is equal to the default resolution of the monitor
//             if (m_Resolutions[i].width == Screen.currentResolution.width && m_Resolutions[i].height == Screen.currentResolution.height)
//             {
//                 //Our variable will equal that resolution
//                 m_defaultResolution = i;
//             }
//         }

//         //add these string type resolutions to the dropdown
//         m_ResolutionDropdown.AddOptions(resolutionOptions);
//     }

//     private void SetDefaultResolution()
//     {
//         //set the resolution dropdown to select default resolution
//         m_ResolutionDropdown.value = m_defaultResolution;

//         //Display the value on screen
//         m_ResolutionDropdown.RefreshShownValue();
//     }

//     public void SetResolution(int resolutionIndex)
//     {
//         Resolution resolution = m_Resolutions[resolutionIndex];
//         Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
//     }

//     public void AdjustMusicVolume(float musicVol)
//     {
//         SoundManager.Instance().GetMusicAudioSource().volume = musicVol;
//     }

//     public void AdjustSFXVolume(float SFXVol)
//     {
//         SoundManager.Instance().GetSFXAudioSource().volume = SFXVol;
//     }

//     public void SetFullscreen(bool isFullscreen)
//     {
//         Screen.fullScreen = isFullscreen;
//     }
// }


