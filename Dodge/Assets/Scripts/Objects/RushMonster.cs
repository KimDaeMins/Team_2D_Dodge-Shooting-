using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// 전방을 향해 빠르게 돌진하여 플레이어와 충돌시 폭발하며 피해를 주고 사라짐
/// </summary>
public class RushMonster : Monster
{
    private Vector3 _playerPosition;
    private Vector2 _playerDirection;
    private float _lifetime;
    private int _damage;

    protected override void Awake()
    {
        base.Awake();
        _currentHp = 1;
        _damage = 1;
    }

    protected override void MoveDirectionUpdate()
    {
        _moveDirection = transform.up * (_speed * Time.deltaTime);
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            GetDamage(100);
        }
    
        if (other.gameObject.CompareTag("Player"))
        {
            if(other.TryGetComponent<Player>(out Player p))
                p.GetDamage(_damage);
            Dead();
        }
    }

    private void OnEnable()
    {
        _currentHp = 1;
    }
}   