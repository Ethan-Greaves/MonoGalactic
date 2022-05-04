using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController), typeof(PlayerMovement), typeof(PlayerHealth))]
[RequireComponent(typeof(PlayerShooting))]
public class Player : MonoBehaviour
{
    private PlayerHealth m_PlayerHealth;
    private PlayerShooting m_PlayerShooting;
    private PlayerMovement m_PlayerMovement;
    private PlayerController m_PlayerController;

    private void Awake()
    {
        m_PlayerHealth = GetComponent<PlayerHealth>();
        m_PlayerShooting = GetComponent<PlayerShooting>();
        m_PlayerMovement = GetComponent<PlayerMovement>();
        m_PlayerController = GetComponent<PlayerController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        UnlockBlueShip();
    }

    // Update is called once per frame
    void Update()
    {
        m_PlayerController.CheckJoystickInput();
        m_PlayerMovement.ProcessInput();
        m_PlayerMovement.RotateToFaceVelocity();
        m_PlayerMovement.KeepPlayerOnScreen();
        m_PlayerShooting.ShootOnTimer(m_PlayerController.CheckJoystickInput(), m_PlayerHealth.isShipCrashed);
    }

    private void FixedUpdate()
    {
        m_PlayerMovement.ApplyPhysics();
    }

    private void UnlockBlueShip()
    {
        if (PlayerPrefs.GetInt(Store.newShipUnlockedKey, 0) == 1)
        {
            GetComponentInChildren<Renderer>().material.SetColor("_Color", Color.blue);
        }
    }
}
