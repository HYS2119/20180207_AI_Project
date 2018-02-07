using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public Transform targetMarker;

	
	
	void Update ()
    {
        int button = 0;
        if (Input.GetMouseButtonDown(button))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//카메라에서ray를 위치로
            RaycastHit hitInfo;
            if(Physics.Raycast(ray.origin,ray.direction,out hitInfo))//ray의방향에 부딛히면 히트애드를
            {
                Vector3 targetPosition = hitInfo.point;//히트포지션으로
                targetMarker.position = targetPosition;
            }
        }	
	}
}
