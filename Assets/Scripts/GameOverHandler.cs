using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverHandler : MonoBehaviour
{
    public void ReturnToMenu()
    {
        GameManager.Instance().GoToMainMenu();
    }

    public void PlayAgain()
    {
        GameManager.Instance().PlayAgain();
    }
}
