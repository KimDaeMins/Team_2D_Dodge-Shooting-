using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayer : StateMachineBehaviour
{
    Player _player;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _player = animator.gameObject.transform.parent.GetComponent<Player>();
        _player.HitEffect("Hit", 11);
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _player.HitEffect("Player", 6);
    }
}
