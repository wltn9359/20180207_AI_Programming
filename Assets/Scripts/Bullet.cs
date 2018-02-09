using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float Speed;

	void Start ()
    {
		
	}
	
	void Update ()
    {

        gameObject.transform.Translate(0, 0, Speed * Time.deltaTime);
        Destroy(gameObject, 5f);

	}
}
