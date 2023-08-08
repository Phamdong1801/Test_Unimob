using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : Singleton<GameplayManager>
{
    [SerializeField] Spider spiderPrefab;

    [SerializeField] GameObject goalObject;

    [SerializeField] List<Transform> listSpawnPosition;

    public void SpawnUnits(int unitCount)
    {
        StartCoroutine(IESpanwn(unitCount));
    }

    IEnumerator IESpanwn(int unitCount)
    {
        for (int i = 0; i < unitCount; i++)
        {
            yield return Spawn(0.05f);
        }
    }
    private IEnumerator Spawn(float delay)
    {
        Spider spiderObj = PoolObjects.Ins.Spawn(spiderPrefab, GenerateSpawnPosition());
        spiderObj.SetDefaulPosition(GenerateSpawnPosition());
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
