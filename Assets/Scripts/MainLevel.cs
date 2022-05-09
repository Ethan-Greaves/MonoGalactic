using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.m_SoundManagerInstance.PlaylevelMusic();
    }
}
