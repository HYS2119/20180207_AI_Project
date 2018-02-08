using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perspective : Sense {

    public int FieldOfView = 45;
    public int ViewDistance = 100;
    private Transform playerTrans;
    private Vector3 rayDirection;
    protected override void Initialize()
    {
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;

    }
    protected override void UpdateSense()
    {
        elapsedTime += Time.deltaTime;//타이머
        if (elapsedTime >= detectionRate) DetectAspect();
    }
    void DetectAspect ()
    {
        RaycastHit hit;
        rayDirection = playerTrans.position - transform.position;
        if ((Vector3.Angle(rayDirection, transform.forward)) < FieldOfView)//쏘는각도와 바라보는방향의 각도가 필드뷰(45)보다 작을때
        {
            if(Physics.Raycast(transform.position,rayDirection,out hit,ViewDistance))//보이는 만큼의 거릴 쏘면
            {
                Aspect aspect = hit.collider.GetComponent<Aspect>();

                if (aspect!=null)//aspect가안맞았다면
                {
                    if (aspect.aspectName == aspectName)//aspect가 aspectName과 같다면
                    {
                        print("Enemy Detected");
                    }
                }
            }
        }
	}
	
	
	void OnDrawGizmos ()
    {
        if (playerTrans == null) return;
        Debug.DrawLine(transform.position, playerTrans.position, Color.red);
        Vector3 frontRayPoint = transform.position + (transform.forward * ViewDistance);
        Vector3 leftRayPoint = frontRayPoint;
        leftRayPoint.x += FieldOfView * 0.5f;
        Vector3 rightRayPoint = frontRayPoint;
        rightRayPoint.x -= FieldOfView * 0.5f;
        Debug.DrawLine(transform.position, frontRayPoint, Color.green);
        rightRayPoint.x -= FieldOfView * 0.5f;
        Debug.DrawLine(transform.position, leftRayPoint, Color.green);
        rightRayPoint.x -= FieldOfView * 0.5f;
        Debug.DrawLine(transform.position, rightRayPoint, Color.green);

    }
}
