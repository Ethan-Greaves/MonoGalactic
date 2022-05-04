using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    private float m_xSpin;
    private float m_ySpin;
    private float m_zSpin;
    [SerializeField] private float m_minRotation;
    [SerializeField] private float m_maxRotation;
    [SerializeField] private float m_rotationSpeed;

    private void Awake()
    {
        m_minRotation = 90;
        m_maxRotation = 360;
        m_xSpin = Random.Range(m_minRotation, m_maxRotation);
        m_ySpin = Random.Range(m_minRotation, m_maxRotation);
        m_zSpin = Random.Range(m_minRotation, m_maxRotation);
    }

    private void Update()
    {
        transform.rotation = Quaternion.Euler
            (m_xSpin += m_rotationSpeed * Time.deltaTime, 
             m_ySpin += m_rotationSpeed * Time.deltaTime, 
             m_zSpin += m_rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth == null) { return; }

            playerHealth.Crash();
        }
        else if (other.gameObject.tag == "Projectile")
        {
            GameManager.Instance().AddScore(50);
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
