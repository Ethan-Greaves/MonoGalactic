using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Projectile m_projectile;
    private int m_delayBetweenShots = 1;
    private float m_timer;

    // Start is called before the first frame update
    void Start()
    {
        m_timer = m_delayBetweenShots;
    }

    // Update is called once per frame
    void Update()
    {
        m_timer -= Time.deltaTime;
        if (m_timer <= 0)
        {
            Instantiate(m_projectile, gameObject.transform.position, gameObject.transform.rotation);
            m_timer = m_delayBetweenShots;
        }
    }
}
