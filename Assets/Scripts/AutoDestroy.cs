﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour {



	void Start ()
    {
        Destroy(gameObject,1.5f);
	}
	
	void Update ()
    {
		
	}
}
