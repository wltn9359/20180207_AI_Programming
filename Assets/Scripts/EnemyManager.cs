using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public float CoolTime;
    public float DelayTime;
    public GameObject Tank;
    public Transform Spawn;
    public int enemyCount;
    public GameObject Tank2;
    public GameObject Tank3;
    public GameObject Tank4;
    public int total;

    private static EnemyManager _instance = null;
    public static EnemyManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(EnemyManager)) as EnemyManager;
                if (_instance == null)
                {
                    Debug.Log("ERROR");
                }
            }
            return _instance;
        }
    }


    void Update ()
    {
        CoolTime += Time.deltaTime;

        if (total >= 3000)
        {
            if (CoolTime > DelayTime)
            {
                CoolTime = 0;
                enemyCount++;
                GameObject EnemyTank = Instantiate(Tank4) as GameObject;
                EnemyTank.name = "Enemy_" + enemyCount;
                EnemyTank.transform.position = Spawn.position;
                EnemyTank.GetComponent<CrowAgnet>().target = GameObject.FindGameObjectWithTag("EnemyGoal").transform;
            }
        }

        if (total >= 1500)
        {
            if (CoolTime > DelayTime)
            {
                CoolTime = 0;
                enemyCount++;
                GameObject EnemyTank = Instantiate(Tank3) as GameObject;
                EnemyTank.name = "Enemy_" + enemyCount;
                EnemyTank.transform.position = Spawn.position;
                EnemyTank.GetComponent<CrowAgnet>().target = GameObject.FindGameObjectWithTag("EnemyGoal").transform;
            }
        }

        if (total>=1000)
        {
            if (CoolTime > DelayTime)
            {
                CoolTime = 0;
                enemyCount++;
                GameObject EnemyTank = Instantiate(Tank2) as GameObject;
                EnemyTank.name = "Enemy_" + enemyCount;
                EnemyTank.transform.position = Spawn.position;
                EnemyTank.GetComponent<CrowAgnet>().target = GameObject.FindGameObjectWithTag("EnemyGoal").transform;
            }
        }
        if (total < 1000)
        {
            if (CoolTime > DelayTime)
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
    public void totalScore()
    {
        total += 10;
    }

}