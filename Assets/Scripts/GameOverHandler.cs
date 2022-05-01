using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private GameObject m_gameOverDisplay;
    [SerializeField] private AsteroidSpawner m_asteroidSpawner;
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private ScoreSystem scoreSystem;


    public void ReturnToMenu()
    {
        GameManager.Instance().GoToMainMenu();
    }

    public void PlayAgain()
    {
        GameManager.Instance().PlayAgain();
    }

    public void EndGame()
    {
        m_asteroidSpawner.enabled = false;

        int finalScore = scoreSystem.EndTimer();
        gameOverText.text = $"Your Score: {finalScore}";

        m_gameOverDisplay.gameObject.SetActive(true);
    }
}
