using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour
{
    public enum MovementState { Still, Random, Following };
    public MovementState state;
    private NavMeshAgent myAgent;
    public float range;

    public Transform centrePoint;

    private Transform playerTransform;


    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; 
        myAgent = GetComponent<NavMeshAgent>();
    }

    // FixedUpdate is called every physics iteration
    void FixedUpdate()
    {
        if (state == MovementState.Random)
        {
            if (myAgent.remainingDistance <= myAgent.stoppingDistance)
            {
                Vector3 point;
                if (RandomPoint(centrePoint.position, range, out point))
                {
                    Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
                    myAgent.SetDestination(point);
                }
            }
        }

        if (state == MovementState.Following)
        {
            myAgent.SetDestination(playerTransform.position);
        }
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }

}
