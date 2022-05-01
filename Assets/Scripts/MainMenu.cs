using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private void Start()
    {
        SoundManager.m_SoundManagerInstance.PlayMainMenuMusic();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        SoundManager.m_SoundManagerInstance.StopMusic();
    }
}
