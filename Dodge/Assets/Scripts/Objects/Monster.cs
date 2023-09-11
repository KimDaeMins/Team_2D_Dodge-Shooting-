using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Monster : Object_Base
{
    protected int _currentHp { get; set; }
    protected float moveSpeed { get; set; }
    protected Vector2 _moveDirection { get; set; }

    private Rigidbody2D _rigidbody;
    private Animator _animator;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    protected virtual void FixedUpdate()
    {
        Move(_moveDirection);
    }

    protected virtual void LateUpdate()
    {
        CheckDead();
    }

    public void GetDamage(int damage)
    {
        _currentHp -= damage;
    }

    public void RecoverHp(int heal)
    {
        _currentHp += heal;
    }

    protected void CheckDead()
    {
        if (_currentHp <= 0)
        {
            _isDead = true;
            Managers.Resource.Destroy(this.gameObject);
            Managers.Resource.Instantiate("MonsterExplosion.prefab");
        }
    }

    private void Move(Vector2 direction)
    {
        direction *= _speed;
        _rigidbody.velocity = direction;
    }

    // protected void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.gameObject.CompareTag("PlayerBullet"))
    //     {
    //         GetDamage(100);
    //     }
    //
    //     if (other.gameObject.CompareTag("Player"))
    //     {
    //         Destroy(this);
    //     }
    // }
}


