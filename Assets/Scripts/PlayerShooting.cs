using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Projectile m_projectile;
    private float m_delayBetweenShots = 0.5f;
    private float m_timer;


    // Start is called before the first frame update
    void Start()
    {
        m_timer = m_delayBetweenShots;
    }

    public void ShootOnTimer(bool checkJoystickInput, bool isShipCrashed)
    {
        m_timer -= Time.deltaTime;
        if (m_timer <= 0)
        {
            ShootProjectile(checkJoystickInput, isShipCrashed);
            m_timer = m_delayBetweenShots;
        }
    }

    private void ShootProjectile(bool checkJoystickInput, bool isShipCrashed)
    {
        if (!checkJoystickInput && !isShipCrashed)
        {
            Instantiate(m_projectile, gameObject.transform.position, gameObject.transform.rotation);
        }
    }
}
