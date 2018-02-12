using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class CrowAgnet : MonoBehaviour {

    public Transform target;
    private NavMeshAgent agent;
    public float angetSpeedMin;
    public float angetSpeedMax;

	void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = Random.Range(angetSpeedMin, angetSpeedMax);
        agent.SetDestination(target.position);
	}
}
