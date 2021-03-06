using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private GameObject m_gameOverDisplay;
    [SerializeField] private AsteroidSpawner m_asteroidSpawner;
    [SerializeField] private TMP_Text m_gameOverText;
    [SerializeField] private ScoreSystem m_scoreSystem;
    [SerializeField] private GameObject m_player;
    [SerializeField] private Button m_continueButton;

    public void ReturnToMenu()
    {
        GameManager.Instance().ResetScore();
        SoundManager.m_SoundManagerInstance.StopMusic();
        GameManager.Instance().GoToMainMenu();
    }

    public void PlayAgain()
    {
        GameManager.Instance().PlayAgain();
    }

    public void EndGame()
    {
        m_asteroidSpawner.enabled = false;
        int finalScore = m_scoreSystem.EndTimer();
        m_gameOverText.text = $"Your Score: {finalScore}";
        m_gameOverDisplay.gameObject.SetActive(true);
    }

    public void ContinueButton()
    {
        AdManager.m_AdMangerInstance.ShowAd(this);
        m_continueButton.interactable = false;
    }


    public void ContinueGame()
    {
        m_player.transform.position = Vector3.zero;
        m_player.gameObject.SetActive(true);
        m_player.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        m_player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        m_scoreSystem.startTimer();
        m_asteroidSpawner.enabled = true;
        m_gameOverDisplay.gameObject.SetActive(false);
        SoundManager.m_SoundManagerInstance.PlaylevelMusic();
    }
}
