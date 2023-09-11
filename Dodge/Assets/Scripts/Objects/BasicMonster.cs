using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BasicMonster : Monster
{
    protected void Awake()
    {
        base.Awake();
        CurrentHp = 1;
        MoveSpeed = 1;
        MoveDirection = new Vector2(-1, -1);
    }

    protected void FixedUpdate()
    {
        Move(MoveDirection);
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            GetDamage(100);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this);
        }
    }
}
