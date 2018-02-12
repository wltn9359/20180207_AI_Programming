﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [SerializeField]
    private GameObject explosionPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" || other.tag == "Environmet")
        {
            if(explosionPrefab == null)
            {
                return;
            }
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity) as GameObject;
            Destroy(this.gameObject);
        }
    }
}
