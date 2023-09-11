using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BasicMonster : Monster
{
    protected override void Awake()
    {
        base.Awake();
        _currentHp = 1;
        moveSpeed = 1;
        _moveDirection = new Vector2(-1, -1);
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
