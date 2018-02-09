﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Target1 : MonoBehaviour {

    private NavMeshAgent[] navAgents;
    public Transform targetMarker;

	void Start ()
    {
        navAgents = FindObjectsOfType(typeof(NavMeshAgent)) as NavMeshAgent[];
	}

    void UpdateTargets(Vector3 targetPosition)
    {
        foreach (NavMeshAgent agent in navAgents)
        {
            agent.destination = targetPosition;
        }
    }
	
	void Update ()
    {
        int button = 0;

        if(Input.GetMouseButtonDown(button))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitinfo;

            if(Physics.Raycast(ray.origin, ray.direction, out hitinfo))
            {
                Vector3 targetPosition = hitinfo.point;
                UpdateTargets(targetPosition);
                targetMarker.position = targetPosition + new Vector3(0, 5, 0);
            }
        }
	}
}
