using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank : MonoBehaviour {

    public Transform targetTransform;
    private float movementSpeed, rotSpeed;

	void Start ()
    {
        movementSpeed = 10;
        rotSpeed = 2;
        targetTransform = GameObject.Find("Target").transform; // 타켓의 위치를 찾는다
	}
	
	void Update ()
    {
		if(Vector3.Distance(transform.position,targetTransform.position)<5) //타켓을 직은 거리가 5보다 적을 경우 리턴
        {
            return;
        }

        Vector3 tarPos = targetTransform.position;
        tarPos.y = transform.position.y;
        Vector3 dirRot = tarPos - transform.position; 

        Quaternion tarRot = Quaternion.LookRotation(dirRot);
        transform.rotation = Quaternion.Slerp(transform.rotation, tarRot, rotSpeed * Time.deltaTime); 
        transform.Translate(new Vector3(0,0, movementSpeed * Time.deltaTime));

	}
}
