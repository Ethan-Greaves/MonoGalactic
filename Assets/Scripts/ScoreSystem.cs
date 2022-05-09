using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TMP_Text m_scoreText;
    [SerializeField] private float m_scoreMultiplier;
    private bool m_shouldCount = true;
    public float m_score;

    void Update()
    {
        if (!m_shouldCount) { return; }
        GameManager.Instance().AddScoreOverTime(1, m_scoreMultiplier);
    }

    private void LateUpdate()
    {
        m_scoreText.text = Mathf.FloorToInt(GameManager.Instance().GetScore()).ToString();
    }

    public int EndTimer()
    {
        m_shouldCount = false;

        m_scoreText.text = string.Empty;

        return Mathf.FloorToInt(GameManager.Instance().GetScore());
    }

    public void startTimer()
    {
        m_shouldCount = true;
    }

    public void AddScore(float toAdd)
    {
        m_score += toAdd * m_scoreMultiplier;
    }
}

