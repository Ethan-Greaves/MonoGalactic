using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Projectile m_projectile;

    private PlayerController m_playerController;
    private PlayerHealth m_playerHealth;
    private int m_delayBetweenShots = 1;
    private float m_timer;



    // Start is called before the first frame update
    void Start()
    {
        m_timer = m_delayBetweenShots;
        m_playerController = GetComponent<PlayerController>();
        m_playerHealth = GetComponent<PlayerHealth>();
    }

    // Update is called once per framee
    void Update()
    {
        m_timer -= Time.deltaTime;
        if (m_timer <= 0)
        {
            ShootProjectile();
            m_timer = m_delayBetweenShots;
        }

        Debug.Log(m_playerHealth.isShipCrashed);
    }

    private void ShootProjectile()
    {
        if (!m_playerController.CheckJoystickInput() && !m_playerHealth.isShipCrashed)
        {
            Instantiate(m_projectile, gameObject.transform.position, gameObject.transform.rotation);
        }
    }
}
