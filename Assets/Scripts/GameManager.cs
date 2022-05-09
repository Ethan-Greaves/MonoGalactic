using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager m_gameMangerInstance;
    private static float m_score = 0;
    private static bool m_isVibrationTurnedOn;

    public static GameManager Instance()
    {
        if (m_gameMangerInstance == null)
            m_gameMangerInstance = new GameObject("Game Manager", typeof(GameManager)).GetComponent<GameManager>();

        return m_gameMangerInstance;
    }

    #region INITILISATION

    //Used for initialising variables or game states
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        m_isVibrationTurnedOn = false;
    }
    #endregion

    #region SCORE FUNCTIONALITY

    public float GetScore() { return m_score; }
    public void ResetScore() { m_score = 0; }
    public void AddScore(int scoreToAdd) { m_score += scoreToAdd; }

    public void AddScoreOverTime(float scoreToAdd, float multiplier)
    {
        m_score += scoreToAdd * Time.deltaTime * multiplier;
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
        return m_isVibrationTurnedOn;
    }
    public void SetIsVibrationTurnedOn(bool value)
    {
        m_isVibrationTurnedOn = value;
    }
    #endregion
}
