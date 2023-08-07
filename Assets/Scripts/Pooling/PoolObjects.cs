using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObjects : Singleton<PoolObjects>
{
    Dictionary<string, Queue<RecylableObject>> instantiatedObjects = new Dictionary<string, Queue<RecylableObject>>();

    public T Spawn<T>(T prefab) where T : RecylableObject
    {
        return GetNewObject(prefab) as T;
    }

    public T Spawn<T>(T prefab, Transform parent) where T : RecylableObject
    {
        var obj = GetNewObject(prefab);
        if (parent) obj.transform.SetParent(parent);
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localEulerAngles = Vector3.zero;
        return obj as T;
    }

    public T Spawn<T>(T prefab, Vector3 position) where T : RecylableObject
    {
        var obj = GetNewObject(prefab);
        obj.transform.position = position;
        return obj as T;
    }


    public T Spawn<T>(T prefab, Vector3 position, Quaternion rotation) where T : RecylableObject
    {
        var obj = GetNewObject(prefab);
        obj.transform.position = position;
        obj.transform.rotation = rotation;
        return obj as T;
    }

    RecylableObject GetNewObject(RecylableObject prefab)
    {
        RecylableObject newObj = Dequeue(prefab.PoolName);
        if (!newObj)
        {
            newObj = Instantiate(prefab);
            newObj.SetPoolName(prefab.PoolName);
        }
        newObj.gameObject.SetActive(true);
        newObj.IsInPool = false;
        newObj.OnSpawn();
        return newObj;
    }

    public void Destroy(RecylableObject obj)
    {
        if (obj.IsInPool) return;
        obj.IsInPool = true;
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(transform);
        Enqueue(obj);
    }

    RecylableObject Dequeue(string poolName)
    {
        if (instantiatedObjects.ContainsKey(poolName) && instantiatedObjects[poolName].Count > 0)
        {
            return instantiatedObjects[poolName].Dequeue();
        }
        return null;
    }

    void Enqueue(RecylableObject obj)
    {
        var id = obj.PoolName;
        if (!instantiatedObjects.ContainsKey(id))
        {
            instantiatedObjects[id] = new Queue<RecylableObject>();
        }
        instantiatedObjects[id].Enqueue(obj);
    }
}

public static class PoolExtension
{
    public static void Recyle<T>(this List<T> objects) where T : RecylableObject
    {
        foreach (var item in objects)
        {
            item.Recyle();
        }
        objects.Clear();
    }
}