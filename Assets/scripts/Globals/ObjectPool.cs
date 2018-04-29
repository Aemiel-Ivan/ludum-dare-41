using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

    private static ObjectPool instance;
    public static ObjectPool Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ObjectPool>();
            }

            return instance;
        }
    }

    private Dictionary<string, List<GameObject>> pool;

    void Awake()
    {
        pool = new Dictionary<string, List<GameObject>>();
    }

	public void Register(GameObject prefab)
    {
        if (!pool.ContainsKey(prefab.name))
        {
            pool.Add(prefab.name, new List<GameObject>());
        }
    }

    public GameObject GetObject (GameObject prefab)
    {
        return GetObject(prefab, transform);
    }

    public GameObject GetObject (GameObject prefab, Transform parent)
    {
        Register(prefab);
        List<GameObject> objects = pool[prefab.name];

        foreach (GameObject item in objects)
        {
            if (!item.activeInHierarchy)
            {
                item.SetActive(true);
                return item;
            }
        }

        GameObject newObject = Instantiate(prefab, transform);
        objects.Add(newObject);
        return newObject;
    }

    public void Clear()
    {
        foreach (KeyValuePair<string, List<GameObject>> list in pool)
        {
            foreach (GameObject item in list.Value)
            {
                if (item.activeInHierarchy)
                {
                    ReleaseObject(item);
                }
            }
        }
    }

    public void ReleaseObject (GameObject item)
    {
        item.SetActive(false);
    }
}
