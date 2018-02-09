﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityFlockController : MonoBehaviour {

    public Vector3 offset;
    public Vector3 bound;
    public float speed = 100;

    private Vector3 initialPosition;
    private Vector3 nextMovementPoint;

	void Start ()
    {
        initialPosition = transform.position;
        CalculateNextMovementPoint();
	}
	
	void Update ()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(nextMovementPoint - transform.position), 1 * Time.deltaTime);

        if(Vector3.Distance(nextMovementPoint,transform.position)<=10)
        {
            CalculateNextMovementPoint();
        }
	}

    void CalculateNextMovementPoint ()
    {
        float posX = Random.Range(initialPosition.x - bound.x, initialPosition.x + bound.x);
        float posY = Random.Range(initialPosition.y - bound.y, initialPosition.y + bound.y);
        float posZ = Random.Range(initialPosition.z - bound.z, initialPosition.z + bound.z);

        nextMovementPoint = initialPosition + new Vector3(posX, posY, posZ);
    }
}
