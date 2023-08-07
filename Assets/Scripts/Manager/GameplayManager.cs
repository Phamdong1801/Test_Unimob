using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : Singleton<GameplayManager>
{
    [SerializeField] Spider spiderPrefab;

    [SerializeField] GameObject goalObject;

    public GameObject GoalObject => goalObject;

    [SerializeField] List<Transform> listSpawnPosition;

    Vector3 spawnPosition;


    public void SpawnUnits(int unitCount)
    {
        for (int i = 0; i < unitCount; i++)
        {
            StartCoroutine(Spawn(1f));
        }
    }

    private IEnumerator Spawn(float delay)
    {
        Spider spiderObj = PoolObjects.Ins.Spawn(spiderPrefab, GenerateSpawnPosition());
        yield return new WaitForSeconds(delay);
    }

    private Vector3 GenerateSpawnPosition()
    {
        int rand = Random.Range(0, listSpawnPosition.Count);
        return listSpawnPosition[rand].position;
    }

    public Vector3 GetGoalPosition()
    {
        return goalObject.transform.position;
    }
}
