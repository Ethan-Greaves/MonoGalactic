using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager m_GameMangerInstance;
    private SceneNavigation m_SceneNavigation;
    private Player m_Player;
    private static bool m_bIsPaused;
    private static float m_iScore = 0;

    private bool isVibrationTurnedOn;

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
        isVibrationTurnedOn = false;
        // m_SceneNavigation = Resources.Load<SceneNavigation>("SceneManager");

        if (m_Player != null)
            m_Player = GameObject.FindWithTag("Player").GetComponent<Player>();


    }
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
        m_SceneNavigation.LoadSceneByNameAdditive("Pause Menu");
        m_bIsPaused = true;
        // SoundManager.Instance().PauseMusic();
    }

    public void ResumeGame()
    {
        if (m_SceneNavigation.IsCurrentScene("Main Level"))
            m_SceneNavigation.RemoveScene("Pause Menu");

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

    public float GetScore() { return m_iScore; }
    public void ResetScore() { m_iScore = 0; }
    public void AddScore(int scoreToAdd) { m_iScore += scoreToAdd; }

    public void AddScoreOverTime(float scoreToAdd, float multiplier)
    {
        m_iScore += scoreToAdd * Time.deltaTime * multiplier;
    }
    #endregion

    #region GAME STATE FUNCTIONALITY
    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    #endregion

    #region VIBRATION

    public bool GetIsVibrationTurnedOn()
    {
        return isVibrationTurnedOn;
    }
    public void SetIsVibrationTurnedOn(bool value)
    {
        isVibrationTurnedOn = value;
    }

    #endregion
}
