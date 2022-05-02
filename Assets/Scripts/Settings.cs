using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Slider m_MusicVolumeSlider;
    [SerializeField] Slider m_SFXVolumeSlider;
    [SerializeField] Toggle m_FullscreenToggle;


    private void Awake()
    {
        //This ensures that when going back and forth between screens the slider value always stays consistent
        m_MusicVolumeSlider.value = SoundManager.m_SoundManagerInstance.GetAudioSourceVolume(SoundManager.m_SoundManagerInstance.GetMusicAudioSource());
        m_SFXVolumeSlider.value = SoundManager.m_SoundManagerInstance.GetAudioSourceVolume(SoundManager.m_SoundManagerInstance.GetSFXAudioSource());

        m_FullscreenToggle.isOn = Screen.fullScreen;
    }

    public void Start()
    {
        
    }

    public void AdjustMusicVolume(float musicVol)
    {
        SoundManager.m_SoundManagerInstance.GetMusicAudioSource().volume = musicVol;
    }

    public void AdjustSFXVolume(float SFXVol)
    {
        SoundManager.m_SoundManagerInstance.GetSFXAudioSource().volume = SFXVol;
    }
}


