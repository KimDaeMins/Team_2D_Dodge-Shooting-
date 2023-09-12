using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;


public class Monster : Object_Base

{
    protected int _currentHp { get; set; }
    protected Vector2 _moveDirection { get; set; }

    protected Rigidbody2D _rigidbody;


    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _objectType = Define.Object.Monster;
    }

    protected virtual void FixedUpdate()
    {
        Move();
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

    private void CheckDead()
    {
        if (_currentHp <= 0)
            Dead();
    }

    protected void Dead()
    {
        _isDead = true;
        Managers.Resource.Destroy(this.gameObject);
        Managers.Resource.Instantiate("MonsterExplosion",
            new Vector3(_rigidbody.position.x, _rigidbody.position.y, 0));
    }

    private void Move()
    {
        _moveDirection = transform.right * (_speed * Time.deltaTime);
        _rigidbody.velocity = _moveDirection;
    }
}

