using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private float m_secondsBetweenAsteroids = 1.5f;
    [SerializeField] private Vector2 m_forceRange;
    [SerializeField] private ObjectPooler m_objectPooler;
    private Camera m_mainCamera;
    private float m_timer;

    void Start()
    {
        m_mainCamera = Camera.main;
    }

    void Update()
    {
        m_timer -= Time.deltaTime;

        if (m_timer <= 0)
        {
            SpawnAsteroid();

            m_timer += m_secondsBetweenAsteroids;
        }
    }

    private void SpawnAsteroid()
    {
        int side = Random.Range(0, 3);
        Vector2 spawnPoint = Vector2.zero;
        Vector2 direction = Vector2.zero;

        switch (side)
        {
            case 0:
                // Left
                spawnPoint.x = 0;
                spawnPoint.y = Random.value;
                direction = new Vector2(1f, Random.Range(-1f, 1f));
                break;
            case 1:
                // Right
                spawnPoint.x = 1;
                spawnPoint.y = Random.value;
                direction = new Vector2(-1f, Random.Range(-1f, 1f));
                break;
            case 2:
                // Top
                spawnPoint.x = Random.value;
                spawnPoint.y = 1;
                direction = new Vector2(Random.Range(-1f, 1f), -1f);
                break;
        }

        Vector3 worldSpawnPoint = m_mainCamera.ViewportToWorldPoint(spawnPoint);
        worldSpawnPoint.z = 0;
        GameObject asteroidInstance = m_objectPooler.SpawnFromPool("Asteroid", worldSpawnPoint, Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)));
        Rigidbody rigidBody = asteroidInstance.GetComponent<Rigidbody>();
        rigidBody.velocity = direction.normalized * Random.Range(m_forceRange.x, m_forceRange.y);
    }
}

