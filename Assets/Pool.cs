using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool
{
    [SerializeField] private string m_tag;
    [SerializeField] private GameObject m_prefab;
    [SerializeField] private int m_size;

    public string GetTag()
    {
        return m_tag;
    }

    public GameObject GetPrefab()
    {
        return m_prefab;
    }

    public int GetSize()
    {
        return m_size;
    }
}
