using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayer : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.transform.parent.GetComponent<Player>().HitEffect("Hit", 11);
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.transform.parent.GetComponent<Player>().HitEffect("Player", 6);
    }
}
