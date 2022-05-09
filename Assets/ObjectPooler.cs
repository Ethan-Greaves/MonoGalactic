using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] private List<Pool> m_pools;
    [SerializeField] private Dictionary<string, Queue<GameObject>> m_poolDictionary;

    private void Awake()
    {
        m_poolDictionary = new Dictionary<string, Queue<GameObject>>();
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (Pool pool in m_pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.GetSize(); i++)
            {
                GameObject obj = Instantiate(pool.GetPrefab());
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            m_poolDictionary.Add(pool.GetTag(), objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!m_poolDictionary.ContainsKey(tag))
        {
            Debug.Log($"Pool with tag {tag} doesnt exist");
            return null;
        }

        GameObject objectToSpawn = m_poolDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        m_poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}
