using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : Singleton<GameplayManager>
{
    [SerializeField] Spider spiderPrefab;

    [SerializeField] GameObject goalObject;

    public GameObject GoalObject => goalObject;

    [SerializeField] List<Transform> listSpawnPosition;


    public void SpawnUnits(int unitCount)
    {
        for (int i = 0; i < unitCount; i++)
        {
            StartCoroutine(Spawn(5f));
            int rand = Random.Range(0, listSpawnPosition.Count);
            var spiderObj = PoolObjects.Ins.Spawn(spiderPrefab, listSpawnPosition[rand]);
        }
    }

    private IEnumerator Spawn(float delay)
    {
        yield return new WaitForSeconds(delay);
    }

    public Vector3 GetGoalPosition()
    {
        return goalObject.transform.position;
    }
}
