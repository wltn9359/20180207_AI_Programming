﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public Transform targetMarker;

	void Update ()
    {
        int button = 0;
        if (Input.GetMouseButtonDown(button))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
            RaycastHit hitInfo;
            if(Physics.Raycast(ray.origin, ray.direction, out hitInfo))
            {
                Vector3 targetposition = hitInfo.point;
                targetMarker.position = targetposition;
            }
        }
	}

}
