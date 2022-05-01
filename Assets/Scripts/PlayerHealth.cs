using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private GameOverHandler m_gameOverHandler;
    public void Crash()
    {
        m_gameOverHandler.EndGame();
        gameObject.SetActive(false);
    }
}
