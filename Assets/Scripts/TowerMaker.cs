using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerMaker : MonoBehaviour {

    public GameObject towerPrefab;
    public GameObject tower2Prefab;
    public GameObject tower3Prefab;
    public int Gold = 300;
    public Text myGold;

    private static TowerMaker _instance = null;
    public static TowerMaker instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(TowerMaker)) as TowerMaker;
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

      
        myGold.text = ("MyGold : " + Gold).ToString();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;


            if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
            {
                Debug.Log(hitInfo.transform.name);
                switch (hitInfo.transform.tag)
                {
                    case "Wall":
                        if (Gold >= 100)
                        {
                            Gold -= 100;
                            Instantiate(towerPrefab, hitInfo.transform.position + new Vector3(0, 1, 0), towerPrefab.transform.rotation);
                        }
                        break;

                    case "Gr":
                        Debug.Log("그곳에는 타워를 설치할수없습니다.");
                        break;

                    case "Enemy":
                        Debug.Log("선택된 적의 이름은 : " + hitInfo.transform.name);
                        break;
                    case "Tower":
                        Debug.Log("그곳에는 타워를 설치할수없습니다.");
                        if (Gold >= 300)
                        {
                            Gold -= 300;
                            Destroy(hitInfo.transform.gameObject);
                            Instantiate(tower2Prefab, hitInfo.transform.position + new Vector3(0, 0, 0), towerPrefab.transform.rotation);
                        }
                        else
                        {
                            Gold -= 0;
                        }
                        break;

                    case "Tower2":

                        if (Gold >= 500)
                        {

                            Gold -= 500;
                            Destroy(hitInfo.transform.gameObject);
                            Instantiate(tower3Prefab, hitInfo.transform.position + new Vector3(0, 0, 0), towerPrefab.transform.rotation);
                        }
                        else
                        {
                            Gold -= 0;
                        }

                        break;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;


            if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
            {
                Debug.Log(hitInfo.transform.name);
                switch (hitInfo.transform.tag)
                {
                   
                    case "Tower":
                        Gold += 50;
                        Destroy(hitInfo.transform.gameObject);
                        break;
                }
            }
        }

    }

    public void TotalGold()
    {
        Gold += 10;
    
    }

    public void TotalGold2()
    {
        Gold += 15;

    }

    public void TotalGold3()
    {
        Gold += 20;

    }
}
