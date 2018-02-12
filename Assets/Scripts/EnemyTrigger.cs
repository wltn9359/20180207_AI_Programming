using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "EnemyGoal")
        {
            Debug.Log("목적지 도착");
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
