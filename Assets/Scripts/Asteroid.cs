using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
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

    // private void OnBecameInvisible()
    // {
    //     Destroy(gameObject);
    // }

}
