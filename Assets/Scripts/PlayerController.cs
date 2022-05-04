using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Joystick m_joystick;

    private void Awake()
    {
        m_joystick = FindObjectOfType<Joystick>();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    public bool CheckJoystickInput()
    {
        float xInput = m_joystick.Horizontal * 1;
        float yInput = m_joystick.Vertical * 1;

        if (xInput == 0 & yInput == 0) return false;
        return true;
    }
}
