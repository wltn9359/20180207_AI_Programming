using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBullet : MonoBehaviour {

    public float bulletSpeed;

	void Start ()
    {
        Destroy(gameObject, 2f);
	}
	
	void Update ()
    {
        transform.Translate(0, 0, bulletSpeed * Time.deltaTime);
	}
}
