using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Projectile m_projectile;
    private PlayerController m_playerController;
    private int m_delayBetweenShots = 1;
    private float m_timer;

    // Start is called before the first frame update
    void Start()
    {
        m_timer = m_delayBetweenShots;
        m_playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        m_timer -= Time.deltaTime;
        if (m_timer <= 0)
        {
            ShootProjectile();
            m_timer = m_delayBetweenShots;
        }
    }

    private void ShootProjectile()
    {
        if (!m_playerController.CheckJoystickInput())
        {
            Instantiate(m_projectile, gameObject.transform.position, gameObject.transform.rotation);
        }
    }
}
