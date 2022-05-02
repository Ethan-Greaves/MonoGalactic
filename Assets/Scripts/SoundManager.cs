using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager m_SoundManagerInstance;
    private AudioSource m_MusicAudioSource;
    private AudioSource m_SFXAudioSource;
    private AudioClip m_MainMenuMusic;
    private AudioClip m_MainLevelMusic;

    #region GETTERS
    public AudioSource GetMusicAudioSource() { return m_MusicAudioSource; }
    public AudioSource GetSFXAudioSource() { return m_SFXAudioSource; }

    public float GetAudioSourceVolume(AudioSource audioSource) { return audioSource.volume; }


    #endregion

    #region INITILISATION
    //Used for initialising variables or game states
    private void Awake()
    {
        if (m_SoundManagerInstance != null && m_SoundManagerInstance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            m_SoundManagerInstance = this;
            DontDestroyOnLoad(this.gameObject);
            m_MusicAudioSource = this.gameObject.AddComponent<AudioSource>();
            m_SFXAudioSource = this.gameObject.AddComponent<AudioSource>();

            //Make sure music always loops
            m_MusicAudioSource.loop = true;

            m_MainMenuMusic = Resources.Load<AudioClip>("Music/music");
            m_MainLevelMusic = Resources.Load<AudioClip>("Music/levelMusic");
        }
    }

    #endregion

    #region MUSIC
    public void PlayMainMenuMusic()
    {
        m_MusicAudioSource.clip = m_MainMenuMusic;
        m_MusicAudioSource.Play();
    }

    public void PlaylevelMusic()
    {
        m_MusicAudioSource.clip = m_MainLevelMusic;
        m_MusicAudioSource.Play();
    }

    public void StopMusic() { m_MusicAudioSource.Stop(); }
    public void PauseMusic() { m_MusicAudioSource.Pause(); }
    public void ResumeMusic() { m_MusicAudioSource.UnPause(); }

    #endregion

    #region SOUND EFFECTS
    public void PlaySFX(AudioClip SFXClip)
    {
        m_SFXAudioSource.PlayOneShot(SFXClip);
    }
    public void PlaySFX(AudioClip SFXClip, float volume)
    {
        m_SFXAudioSource.Stop();
        m_SFXAudioSource.PlayOneShot(SFXClip, volume);
    }

    public void PlayRandomSFX(AudioClip[] SFXClips)
    {
        m_SFXAudioSource.PlayOneShot(SFXClips[Random.Range(0, SFXClips.Length - 1)]);
    }


    public void StopSFX()
    {
        m_SFXAudioSource.Stop();
    }

    #endregion

}

