using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Monster : Object_Base
{
    public int CurrentHp { get; set; }
    public float MoveSpeed { get; set; }
    public Vector2 MoveDirection { get; set; }

    private Rigidbody2D _rigidbody;
    public Animator animator;

    protected void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    protected void FixedUpdate()
    {
        Move(MoveDirection);
    }


    protected void GetDamage(int damage)
    {
        CurrentHp = 0;
        Destroy(this);
    }

    protected void Move(Vector2 direction)
    {
        direction *= _speed;
        _rigidbody.velocity = direction;
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


