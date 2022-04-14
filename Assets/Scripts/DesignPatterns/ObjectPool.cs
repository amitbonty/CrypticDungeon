using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoSingleton<ObjectPool>
{
    Dictionary<string, Queue<GameObject>> _poolDict;
    [SerializeField]
    private List<Pool> pools;
    private void Start()
    {
        _poolDict = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objPool.Enqueue(obj);
            }
            _poolDict.Add(pool.name, objPool);
        }
    }
    public GameObject GetPooledObject(string name, Vector3 position, Quaternion rotation)
    {
        if (!_poolDict.ContainsKey(name))
        {
            return null;
        }
        GameObject obj = _poolDict[name].Dequeue();
        obj.SetActive(true);
        obj.transform.position = position;
        obj.transform.rotation = rotation;
        _poolDict[name].Enqueue(obj);
        return obj;
    }
}
[System.Serializable]
public class Pool
{
    public string name;
    public int size;
    public GameObject prefab;
}