using BaseTemplate.Behaviours;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

public class PoolManager : MonoSingleton<PoolManager>
{
    [SerializeField] List<Pool> gameobjectPools;

    public Dictionary<string, ObjectPool<GameObject>> gameobjectPoolDictionary;

    Stack<GameObject> poolsGO = new Stack<GameObject>();

    public void Init()
    {
        gameobjectPoolDictionary = new Dictionary<string, ObjectPool<GameObject>>();

        foreach (var pool in gameobjectPools)
        {
            poolsGO.Clear();

            var _pool = new ObjectPool<GameObject>(() =>
            {
                return Instantiate(pool.prefab, transform);
            }, poolObj =>
            {
                poolObj.SetActive(true);
            },
            poolObj =>
            {
                poolObj.transform.SetParent(transform);
                poolObj.SetActive(false);
            },
            poolObj =>
            {
                Destroy(poolObj);
            },
            false, pool.size, pool.size);

            for (int i = 0; i < pool.size; i++)
            {
                poolsGO.Push(_pool.Get());
            }

            for (int i = 0; i < pool.size; i++)
            {
                _pool.Release(poolsGO.Pop());
            }

            gameobjectPoolDictionary.Add(pool.tag, _pool);
        }

    }
}

[System.Serializable]
public class Pool
{
    public string tag;
    public GameObject prefab;
    public int size;
}

