using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TankAI : MonoBehaviour {

    private GameObject player;
    private Animator animator;
    private Ray ray;
    private RaycastHit hit;
    private float maxDistanceToCheck = 6;  //최대 사거리를 체크하고자 설정
    private float currentDistance; // 현재 거리를 표기하고자 설정
    private Vector3 checkDirection; //좌표값을 체크하고자 설정

    public Transform pointA;
    public Transform pointB;
    public NavMeshAgent navMeshAgent; // NavMeshAgent를 사용하기 위해선 using UnityEngine.AI; 미리 입력해둬야함

    private int currentTarget; //타켓을 인트로 설정
    private float distanceFromTarget; //타켓과의 거리
    private Transform[] waypoints = null; 

    private void Awake()
    {
        player = GameObject.FindWithTag("Player"); //플레이어를 플레이어 태그로 찾을수있도록 함
        animator = gameObject.GetComponent<Animator>(); //애니메이터를 해당 게임오브젝트에 담음
        pointA = GameObject.Find("p1").transform; 
        pointB = GameObject.Find("p2").transform;
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>(); //navMeshAgent에 NavMeshAgent로 담음

        waypoints = new Transform[2]
        {
            pointA,
            pointB
        };

        //waypoints = new Transform[2];  위와 같은 동작을 할수있는 코드
        //waypoints[0] = pointA;
        //waypoints[1] = pointB;

        currentTarget = 0; // 초기화
        navMeshAgent.SetDestination(waypoints[currentTarget].position); //navMeshAgent에 SetDestination로 좌표값을 업데이트 해줌
    }

    private void FixedUpdate()
    {
        currentDistance = Vector3.Distance(player.transform.position, transform.position); //Vector3.Distance는 A,B의 거리를 float으로 변환 시켜줌 , 
        animator.SetFloat("distanceFromPlayer", currentDistance);
        checkDirection = player.transform.position - transform.position; // 플레이어의 위치와 오브젝트의 위치의 값을빼서 방향값을 정함
        ray = new Ray(transform.position, checkDirection); 
        if(Physics.Raycast(ray, out hit, maxDistanceToCheck)) //Raycast가 쏘고있는 Ray만큼에 hit할경우 
        {
            if(hit.collider.gameObject == player)
            {
                animator.SetBool("isPlayerVisible", true); // 공격 상황
            }

            else
            {
                animator.SetBool("isPlayerVisible", false);
            }
        }

        else
        {
            animator.SetBool("isPlayerVisible", false);
        }

        distanceFromTarget = Vector3.Distance(waypoints[currentTarget].position, transform.position); 
        animator.SetFloat("distanceFromWaypoint", distanceFromTarget);
    }

    public void SetNextPoint()
    {
        switch(currentTarget)
        {
            case 0:
                currentTarget = 1;
                break;

            case 1:
                currentTarget = 0;
                break;
        }
        navMeshAgent.SetDestination(waypoints[currentTarget].position);
    }

}