﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockController : MonoBehaviour {

    public float minVelocity = 1;
    public float maxVelocity = 8;
    public int flockSize = 20;
    public float centerWeight = 1;
    public float velocityWeight = 1;
    public float separationWeight = 1;
    public float followWeight = 1;
    public float randomizeWeight = 1;

    public Flock prefab;
    public Transform target;

    internal Vector3 flockCenter;
    internal Vector3 flockVelocity;
    private Rigidbody rigidbody;
    public ArrayList flockList = new ArrayList();



    void Start ()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();

        for (int i = 0; i < flockSize; i++)
        {
            Flock flock = Instantiate(prefab, transform.position, transform.rotation) as Flock;
            flock.transform.parent = transform;
            flock.controller = this;
            flockList.Add(flock);
        }

	}
	
	void Update ()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();


        Vector3 center = Vector3.zero;
        Vector3 velocity = Vector3.zero;
        foreach (Flock flock in flockList)
        {
            center += flock.transform.localPosition;
            velocity += flock.GetComponent<Rigidbody>().velocity;
        }

        flockCenter = center / flockSize;
        flockVelocity = velocity / flockSize;

    }
}
