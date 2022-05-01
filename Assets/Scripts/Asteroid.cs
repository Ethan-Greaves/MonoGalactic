using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private ScoreSystem m_scoreSystem;
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
            m_scoreSystem.AddScore(5);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }


    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
