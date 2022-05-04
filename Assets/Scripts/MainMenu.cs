using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text m_energyText;
    [SerializeField] private int m_maxEnergy;
    [SerializeField] private float m_energyRechargeDuration;
    [SerializeField] private AndroidNotificationHandler m_androidNotificationHandler;


    private int m_energy;

    private const string m_EnergyKey = "Energy";
    private const string m_EnergyReadyKey = "EnergyReady";

    private void Start()
    {
        SoundManager.m_SoundManagerInstance.PlayMainMenuMusic();

        m_energy = PlayerPrefs.GetInt(m_EnergyKey, m_maxEnergy);

        if (m_energy == 0)
        {
            string energyReadyString = PlayerPrefs.GetString(m_EnergyReadyKey, string.Empty);

            if (energyReadyString == string.Empty) { return; }

            DateTime energyReady = DateTime.Parse(energyReadyString);

            if (DateTime.Now > energyReady)
            {
                m_energy = m_maxEnergy;
                PlayerPrefs.SetInt(m_EnergyKey, m_energy);
            }
        }

        m_energyText.text = $"Tap To Start ({m_energy})";

    }

    public void StartGame()
    {
        // GameManager.Instance().RemoveEnergy();
        if (m_energy < 1) { return; }

        m_energy--;

        PlayerPrefs.SetInt(m_EnergyKey, m_energy);

        if (m_energy == 0)
        {
            DateTime energyReady = DateTime.Now.AddMinutes(m_energyRechargeDuration);
            PlayerPrefs.SetString(m_EnergyReadyKey, energyReady.ToString());

#if UNITY_ANDROID
            m_androidNotificationHandler.ScheduleNotification(energyReady);
#endif

        }

        SoundManager.m_SoundManagerInstance.StopMusic();
        SceneManager.LoadScene(1);
    }

    public void GoToSettings()
    {
        SceneManager.LoadScene(2);
    }
}
