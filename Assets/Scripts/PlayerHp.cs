using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour {

    public GameObject playerHp;
    public int hp = 100;
    public GameObject game;


    void Start ()
    {
		
	}
	
	void Update ()
    {
        


		if(hp<=0)
        {
            game.SetActive(true);
            Time.timeScale=0;
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            hp -= 10;
            playerHp.transform.localScale = new Vector3(hp * 0.01f, 1, 1);
        }
    }
}
