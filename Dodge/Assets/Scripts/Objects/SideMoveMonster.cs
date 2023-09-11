using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SideMoveMonster : Monster
{
    protected override void Awake()
    {
        base.Awake();
        _currentHp = 1;
        FireCoolTime = 1f;
        IsFireAble = true;
        _moveDirection = new Vector2(Random.Range(-1, 2), 0);
        // _target = Util.GetOrAddComponent<GameObject>(Player);
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
    
}
