using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TankAi : MonoBehaviour {

    private GameObject player;
    private Animator animator;
    private Ray ray;
    private RaycastHit hit;//맞은 것
    private float maxDistanceToCheck = 6.0f;//감지거리
    private float currentDistance;//현재거리
    private Vector3 checkDirection;//채크해야하는 좌표값
    public Transform pointA;
    public Transform pointB;
    public NavMeshAgent navMeshAgent;
    private int currentTarget;//설정타겟
    private float distanceFromTarget;//타겟과의 거리
    private Transform[] waypoints = null;//배열
    private void Awake()//스타드보다 먼저 초기화할때사용
    {
        player = GameObject.FindWithTag("Player");//플레이어가 누군지 찾는다
        animator = gameObject.GetComponent<Animator>();//애니메이터를 가져와서 캐싱하겠다
        pointA = GameObject.Find("p1").transform;//p1을만들겠다
        pointB = GameObject.Find("p2").transform;//p2를 만들겠다
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        waypoints = new Transform[2]
        {
            pointA,
            pointB

        };
        
        currentTarget = 0;//초기화
        navMeshAgent.SetDestination(waypoints[currentTarget].position);//웨이포인트에 currentTarget을받는다
    }
    private void FixedUpdate()
    {
        currentDistance = Vector3.Distance(player.transform.position, transform.position);
        animator.SetFloat("distanceFromPlayer", currentDistance);
        checkDirection = player.transform.position - transform.position;
        ray = new Ray(transform.position, checkDirection);
        if (Physics.Raycast(ray, out hit, maxDistanceToCheck))//만약 플레이어가 ray를 맞으면
        {
            if (hit.collider.gameObject == player)
            {
                animator.SetBool("isPlayerVisible", true);//
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
        distanceFromTarget =
            Vector3.Distance(waypoints[currentTarget].position,//
            transform.position);
        animator.SetFloat("distanceFromWaypoint", distanceFromTarget);
    }
    public void SetNextPoint()
    {
        switch (currentTarget)
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
