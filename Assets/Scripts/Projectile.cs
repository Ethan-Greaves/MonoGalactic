using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Range(0, 100)]
    [SerializeField] float speed;
    [SerializeField] int damage = 25;
    [SerializeField] private AudioClip m_projectileSFX;

    private Player m_player;

    Rigidbody rb;

    //Getters
    public int GetDamage() { return damage; }

    // Start is called before the first frame update
    void Start()
    {
        m_player = FindObjectOfType<Player>();
        FireProjectile();
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void FireProjectile()
    {
        SoundManager.m_SoundManagerInstance.PlaySFX(m_projectileSFX);

        // rb = GetComponent<Rigidbody>();
        // rb.velocity = m_player.gameObject.transform.forward * (speed * Time.deltaTime);
        //rb.AddForce(m_player.gameObject.transform.forward * speed);
        // rb.velocity = m_player.transform.rotation * (speed * Time.deltaTime);
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
