using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTrigger : MonoBehaviour {

    public GameObject effect;
    public int hP=100;
    public int Score;
  



    void Start()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "EnemyGoal")
        {           
            Debug.Log("목적지 도착");
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Bullet")
        {
            hP -= 50;
          
      
            if (hP <= 0)
            {
                EnemyManager.instance.totalScore();
                TowerMaker.instance.TotalGold();
                ScoreManager.instance.total();
                hP = 0;
                Instantiate(effect, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }

        if (col.gameObject.tag == "Bullet2")
        {
            hP -= 50;


            if (hP <= 0)
            {
                EnemyManager.instance.totalScore();
                TowerMaker.instance.TotalGold2();
                ScoreManager.instance.total();
                hP = 0;
                Instantiate(effect, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
        if (col.gameObject.tag == "Bullet3")
        {
            hP -= 50;


            if (hP <= 0)
            {
                EnemyManager.instance.totalScore();
                TowerMaker.instance.TotalGold3();
                ScoreManager.instance.total();
                hP = 0;
                Instantiate(effect, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}
