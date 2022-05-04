using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private GameOverHandler m_gameOverHandler;

    public bool m_isShipCrashed { get; private set; }

    private void Start()
    {
        m_isShipCrashed = false;
    }
    public void Crash()
    {
        m_isShipCrashed = true;

        if (GameManager.Instance().GetIsVibrationTurnedOn())
        {
            Handheld.Vibrate();
        }

        m_gameOverHandler.EndGame();
        gameObject.SetActive(false);
    }
}
