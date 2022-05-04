using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager m_GameMangerInstance;
    private Player m_Player;
    private static float m_iScore = 0;
    private bool m_isVibrationTurnedOn;

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
        m_isVibrationTurnedOn = false;

        if (m_Player != null)
            m_Player = GameObject.FindWithTag("Player").GetComponent<Player>();
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
        return m_isVibrationTurnedOn;
    }
    public void SetIsVibrationTurnedOn(bool value)
    {
        m_isVibrationTurnedOn = value;
    }
    #endregion
}
