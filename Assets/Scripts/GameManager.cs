using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager m_GameMangerInstance;
    private SceneHandler m_SceneHandler;
    private Player m_Player;
    private static bool m_bIsPaused;
    private static int m_iScore = 0;


    private int m_energy;

    public static GameManager Instance()
    {
        if (m_GameMangerInstance == null)
            m_GameMangerInstance = new GameObject("Game Manager", typeof(GameManager)).GetComponent<GameManager>();

        return m_GameMangerInstance;
    }

    #region INITILISATION

    //Used for initialising variables or game states
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        m_bIsPaused = false;
        m_SceneHandler = Resources.Load<SceneHandler>("SceneManager");

        if (m_Player != null)
            m_Player = GameObject.FindWithTag("Player").GetComponent<Player>();

        //if (m_MainLevelMusic != null)

        // m_energy = 5;
        // m_energyRechargeDuration = 1;
    }
    #endregion

    #region ENERGY SYSTEM FUNCTIONALITY
    // public void LoadEnergy()
    // {
    //     m_energy = PlayerPrefs.GetInt(m_energyKey, m_maxEnergy);
    //     if (m_energy == 0)
    //     {
    //         m_energy = 5;

    //         string energyReadyString = PlayerPrefs.GetString(m_energyReadyKey, string.Empty);

    //         if (energyReadyString == string.Empty) { return; }

    //         DateTime energyReady = DateTime.Parse(energyReadyString);

    //         if (DateTime.Now > energyReady)
    //         {
    //             m_energy = m_maxEnergy;
    //             PlayerPrefs.SetInt(m_energyKey, m_energy);
    //         }

    //     }
    // }

    // public void RemoveEnergy()
    // {
    //     if (m_energy < 1) { return; }

    //     m_energy--;

    //     PlayerPrefs.SetInt(m_energyKey, m_energy);

    //     if (m_energy == 0)
    //     {
    //         DateTime energyReady = DateTime.Now.AddMinutes(m_energyRechargeDuration);
    //         PlayerPrefs.SetString(m_energyReadyKey, energyReady.ToString());
    //     }

    // }

    // public int GetEnergy()
    // {
    //     return m_energy;
    // }
    #endregion

    #region PAUSE FUNCTIONALITY
    public void PauseGame()
    {
        if (m_bIsPaused)
            ResumeGame();
        else
            RunPauseFunctionality();
    }

    private void RunPauseFunctionality()
    {
        Time.timeScale = 0f;
        m_SceneHandler.LoadSceneByNameAdditive("Pause Menu");
        m_bIsPaused = true;
        // SoundManager.Instance().PauseMusic();
    }

    public void ResumeGame()
    {
        if (m_SceneHandler.IsCurrentScene("Main Level"))
            m_SceneHandler.RemoveScene("Pause Menu");

        Time.timeScale = 1f;
        m_bIsPaused = false;

        // SoundManager.Instance().ResumeMusic();
    }

    public void SetIsPaused(bool set)
    {
        m_bIsPaused = set;
    }

    #endregion

    #region SCORE FUNCTIONALITY

    public int GetScore() { return m_iScore; }
    public void ResetScore() { m_iScore = 0; }
    public void AddScore(int scoreToAdd) { m_iScore += scoreToAdd; }
    #endregion

    #region GAME STATE FUNCTIONALITY
    public void PlayAgain()
    {
        m_SceneHandler.LoadSceneByNameSingle("MainLevel");
        // SoundManager.Instance().StopMusic();
    }
    public void LevelComplete()
    {
        m_SceneHandler.LoadSceneByNameSingle("Level Complete");
        // SoundManager.Instance().StopMusic();
    }

    public void GoToMainMenu()
    {
        m_SceneHandler.LoadSceneByNameSingle("Menu");
    }
    #endregion
}
