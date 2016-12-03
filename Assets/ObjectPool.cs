using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    List<PooledObject> availableObjects = new List<PooledObject>();

    PooledObject prefab;
    public PooledObject GetObject()
    {
        PooledObject obj;

        int lastAvailableIdx = availableObjects.Count - 1;

        if (lastAvailableIdx >= 0)
        {
            obj = availableObjects[lastAvailableIdx];
            availableObjects.RemoveAt(lastAvailableIdx);
            obj.gameObject.SetActive(true);
        }
        else
        {
            obj = Instantiate<PooledObject>(prefab);
            obj.transform.SetParent(transform, false);
            obj.Pool = this;
        }

        return obj;
    }

    public void AddObject(PooledObject obj)
    {
        obj.gameObject.SetActive(false);
        availableObjects.Add(obj);
    }

    public static ObjectPool GetPool(PooledObject prefab)
    {
        GameObject obj = new GameObject(prefab.name + " Pool");
        DontDestroyOnLoad(obj);
        ObjectPool pool = obj.AddComponent<ObjectPool>();
        pool.prefab = prefab;
        return pool;
    }

}
