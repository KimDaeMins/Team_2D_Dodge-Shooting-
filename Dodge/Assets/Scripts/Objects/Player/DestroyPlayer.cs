using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyPlayer : StateMachineBehaviour
{
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Managers.Scene.LoadScene(Define.Scene.Logo);
        animator.gameObject.transform.parent.GetComponent<Player>().DestroyPlayer();
    }


}
