using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class CrowAgnet : MonoBehaviour {

    public Transform target;
    private NavMeshAgent agent;

	void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = Random.Range(4, 5);
        agent.SetDestination(target.position);
	}
}
