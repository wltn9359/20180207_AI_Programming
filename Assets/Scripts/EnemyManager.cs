using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public float CoolTime;
    public float DelayTime;
    public GameObject Tank;
    public Transform Spawn;
    public int enemyCount;


    void Update ()
    {

        CoolTime += Time.deltaTime;
        if(CoolTime>DelayTime)
        {
            CoolTime = 0;
            enemyCount++;
            GameObject EnemyTank = Instantiate(Tank) as GameObject;
            EnemyTank.name = "Enemy_" + enemyCount;
            EnemyTank.transform.position = Spawn.position;
            EnemyTank.GetComponent<CrowAgnet>().target = GameObject.FindGameObjectWithTag("EnemyGoal").transform;
        }

	}
}
