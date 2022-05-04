using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Range(0, 100)]
    [SerializeField] float m_speed;
    [SerializeField] private AudioClip m_projectileSFX;
    private Player m_player;
    Rigidbody m_rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        m_player = FindObjectOfType<Player>();
        PlayProjectileSfx();
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * m_speed * Time.deltaTime);
    }

    private void PlayProjectileSfx()
    {
        SoundManager.m_SoundManagerInstance.PlaySFX(m_projectileSFX);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
    }
}
