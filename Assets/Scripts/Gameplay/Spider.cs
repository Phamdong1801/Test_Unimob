using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spider : RecylableObject
{
    [SerializeField] NavMeshAgent agent;

    [SerializeField] float speedSpiderMove = 3f;

    public Vector3 defaultPosition;

    const string tagGoal = "Goal";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(tagGoal))
        {
            OnHitGoal();
        }
    }

    private void OnHitGoal()
    {
        Recyle();
        transform.position = defaultPosition;
        agent.speed = 0;
        agent.enabled = false;
    }

    public override void OnSpawn()
    {
        StartCoroutine(ResetSpeed());
        base.OnSpawn();
        agent.enabled = true;
        agent.SetDestination(GameplayManager.Ins.GetGoalPosition());
    }

    IEnumerator ResetSpeed()
    {
        agent.speed = speedSpiderMove;
        yield return new WaitForSeconds(0.15f);
    }

    public override void Recyle()
    {
        gameObject.transform.position = GameplayManager.Ins.GetGoalPosition();
        base.Recyle();
    }
}
