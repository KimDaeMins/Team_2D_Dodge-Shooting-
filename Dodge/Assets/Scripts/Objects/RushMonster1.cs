using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// 전방을 향해 빠르게 돌진하여 플레이어와 충돌시 폭발하며 피해를 주고 사라짐
/// </summary>
public class RushMonster1 : Monster
{
    private Vector3 _playerPosition;
    private Vector2 _playerDirection;

    protected override void Awake()
    {
        base.Awake();
        _damage = 1;
    }

    protected override void Dead()
    {
        _isDead = true;
        Managers.Resource.Destroy(this.gameObject);
        Managers.Resource.Instantiate("MonsterExplosion" ,
            new Vector3(_rigidbody.position.x , _rigidbody.position.y , 0));
        Managers.Sound.Play("MonsterDie" , Define.Sound.Effect , 1);
    }
    protected override void OnEnable()
    {
        base.OnEnable();
    }
}   