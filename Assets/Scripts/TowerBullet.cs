using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBullet : MonoBehaviour {

    public float bulletSpeed;
    public Transform target;

    void Start ()
    {
        
	}
	
	void Update ()
    {
        if (target != null)
        {
            transform.LookAt(target);
            transform.Translate(0, 0, bulletSpeed * Time.deltaTime);
        }

        else
        {
            Destroy(gameObject);
        }
    }


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Gr")
        {
            Destroy(gameObject);
        }
    }
}
