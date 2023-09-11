using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChaseBulletMonster : Monster
{
    protected override void Awake()
    {
        base.Awake();
        _currentHp = 1;
        FireCoolTime = 1f;
        IsFireAble = true;
        _speed = Random.Range(1, 10);
        _moveDirection = new Vector2(Random.Range(-1, 2), 0);
    }

    protected void Update()
    {
        // _fireDirection
        Fire();
        MoveDirectionUpdate();
    }

    private void MoveDirectionUpdate()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        
        transform.position = Camera.main.ViewportToWorldPoint(pos);
        if (pos.x < 0f || pos.x > 1f || pos.y < 0f || pos.y > 1f)
            _moveDirection = new Vector2(_moveDirection.x * (-1), 0);
    }
    
    protected void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("충돌");
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            GetDamage(100);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            GetDamage(100);
        }
    }
    
    public override void Fire()
    {
        if (IsFireAble)
        {
            Managers.Resource.Instantiate("MonsterGudiedBullet", _rigidbody.position);
            
            StartCoroutine("FireUpdate", FireCoolTime);
            IsFireAble = false;
            Debug.Log("총쏨");
        }
        else
        {
            Debug.Log("CoolTime");
        }
    }
    
}
