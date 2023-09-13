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
    protected int _damage { get; set; }
    protected Rigidbody2D _rigidbody;


    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _objectType = Define.Object.Monster;
        Managers.Object.Add(this.gameObject , Define.Object.Monster);
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
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            GetDamage(100);
        }
    
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Player>().GetDamage(_damage);
            Dead();
        }
    }
}

