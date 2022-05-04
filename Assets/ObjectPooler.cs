using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public static ObjectPooler m_instance;

    private void Awake() {
        m_instance = this;
    }

    public List<Pool> m_pools;
    public Dictionary<string, Queue<GameObject>> m_poolDictionary;

    // Start is called before the first frame update
    void Start()
    {
        m_poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in m_pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            m_poolDictionary.Add(pool.tag, objectPool);
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
