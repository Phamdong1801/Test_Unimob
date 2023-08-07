using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class RecylableObject : MonoBehaviour
{
    [SerializeField] bool isAutoRecyle;

    [SerializeField] float timeAutoRecyle;

    string poolName;

    public bool IsInPool { get; set; }

    public string PoolName
    {
        get
        {
            if (string.IsNullOrEmpty(poolName)) return name;
            return poolName;
        }
    }

    public virtual void OnSpawn()
    {
        if (isAutoRecyle)
        {
            StartCoroutine(IERecyle());
        }
    }

    public void SetPoolName(string originalName)
    {
        poolName = originalName;
    }
    IEnumerator IERecyle()
    {
        yield return new WaitForSeconds(timeAutoRecyle);
        Recyle();
    }
    public virtual void Recyle()
    {
        PoolObjects.Ins.Destroy(this);
    }
}