using System;
using UnityEngine;

namespace Objects
{
    public class MonsterExplosion : MonoBehaviour
    {
        private Animator _animator;
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        
        private void Update()
        {
            AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.normalizedTime >= 1.0f)
            {
                Managers.Resource.Destroy(this.gameObject);
            }
        }
    }
}