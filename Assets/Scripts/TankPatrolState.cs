using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPatrolState : StateMachineBehaviour {

	


	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateinfo,int layerindex)
    {
        TankAi tankAi = animator.gameObject.GetComponent<TankAi>();
        tankAi.SetNextPoint();
	}

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
       // base.OnStateUpdate(animator, stateinfo,layerindex);
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
       // base.OnStateExit(animator, stateinfo,layerindex);
    }
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
       // base.OnStateMove(animator, stateinfo,layerindex);
    }
    override public void OnStateIK(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
       // base.OnStatelk(animator, stateinfo,layerindex);
    }
    


}
