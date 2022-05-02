using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private float scoreMultiplier;

    private bool shouldCount = true;
    public float score;

    void Update()
    {
        if (!shouldCount) { return; }

        GameManager.Instance().AddScoreOverTime(1, scoreMultiplier);
        Debug.Log(score);
    }

    private void LateUpdate()
    {
        scoreText.text = Mathf.FloorToInt(GameManager.Instance().GetScore()).ToString();
    }

    public int EndTimer()
    {
        shouldCount = false;

        scoreText.text = string.Empty;

        return Mathf.FloorToInt(score);
    }

    public void startTimer()
    {
        shouldCount = true;
    }

    public void AddScore(float toAdd)
    {
        score += toAdd * scoreMultiplier;
    }
}

