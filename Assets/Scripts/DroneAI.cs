using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using System.Runtime.InteropServices;

public class DroneAI : MonoBehaviour
{
    NavMeshAgent agent;

    // Patrolling
    public List<Transform> waypoints;
    int waypointIndex;
    Vector3 target;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, target) < 1)
        {
            IterateWPIndex();
            UpdateDestination();
        }
    }

    void UpdateDestination()
    {
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);
    }

    void IterateWPIndex()
    {
        waypointIndex++;
        if (waypointIndex == waypoints.Count)
        {
            waypointIndex = 0;
        }
    }
}
