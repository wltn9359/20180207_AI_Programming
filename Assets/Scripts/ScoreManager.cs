using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour 
    {

    public Text myScore;
    public int Score;

    private static ScoreManager _instance = null;
    public static ScoreManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(ScoreManager)) as ScoreManager;
                if (_instance == null)
                {
                    Debug.Log("ERROR");
                }
            }
            return _instance;
        }
     
    }

	void Start ()
    {
     
    }
	
	
	void Update ()
    {
     

	}

  public void total()
    {
        Score += 10;
        myScore.text = ("MyScore : " + Score).ToString();
    }

}
