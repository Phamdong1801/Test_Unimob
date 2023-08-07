using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spider : RecylableObject
{
    [SerializeField] NavMeshAgent agent;

    const string tagGoal = "Goal";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(tagGoal))
        {
            Recyle();
        }
    }

    public override void OnSpawn()
    {
        base.OnSpawn();

        agent.SetDestination(GameplayManager.Ins.GetGoalPosition());
    }

}
