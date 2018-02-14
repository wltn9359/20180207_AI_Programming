using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retry : MonoBehaviour {

	void Start ()
    {
		
	}
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(0);
            Time.timeScale = 1;
        }
    }
}
