﻿using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;


public class Monster : Object_Base

{
    [SerializeField] protected int _maxHp;
    protected int _currentHp { get; set; }
    protected Vector2 _moveDirection { get; set; }
    protected int _damage { get; set; }
    protected Rigidbody2D _rigidbody;
    protected Animator _animator;
    UI_Monster_HpBar _hpBar;
    protected virtual void Awake()
    {
        _currentHp = _maxHp;
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = this.transform.GetChild(0).GetComponent<Animator>();
        _objectType = Define.Object.Monster;
        //Managers.Object.Add(this.gameObject , Define.Object.Monster);
        Vector3 position = transform.position;
        position.y -= transform.GetChild(0).GetComponent<SpriteRenderer>().size.y * 0.5f * transform.GetChild(0).transform.localScale.y * transform.localScale.y;
        GameObject go = Managers.Resource.Instantiate("MonsterHpBar" , position, Quaternion.identity, transform);
        _hpBar = Util.GetOrAddComponent<UI_Monster_HpBar>(go);
    }

    protected virtual void OnEnable()
    {
        _hpBar.MaxBar = _maxHp;
        _currentHp = _maxHp;
        //_hpBar.SetHpBar(_currentHp);
    }
    protected virtual void Update()
    {
        MoveDirectionUpdate();
        CheckScreenOut();
    }

    protected virtual void FixedUpdate()
    {
        Move();
    }

    protected virtual void LateUpdate()
    {
        CheckDead();
    }

    protected virtual void MoveDirectionUpdate()
    {
        _moveDirection = transform.up * (_speed * Time.deltaTime);
    }
    
    public void GetDamage(int damage)
    {
        _animator.SetTrigger("Hit");
        _currentHp -= damage;
        _hpBar.SetHpBar(_currentHp);
    }

    public void RecoverHp(int heal)
    {
        _currentHp += heal;
        _hpBar.SetHpBar(_currentHp);
    }

    private void CheckDead()
    {
        if (_currentHp <= 0)
            Dead();
    }

    private void CheckScreenOut()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
        
        if (pos.x < -0.1f || pos.x > 1.1f || pos.y < -0.1f || pos.y > 1.1f)
            Managers.Resource.Destroy(this.gameObject);
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
        _rigidbody.velocity = _moveDirection;
    }
    
    protected void OnTriggerEnter2D(Collider2D other)
    {
    
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Player>().GetDamage(_damage);
            Dead();
        }
    }
}

