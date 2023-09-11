﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Object_Base, IFire
{
    [SerializeField] public float FireCoolTime { get; set; }
    public bool IsFireAble { get; set; }


    public float Speed { get { return _speed; } set { _speed = value; } }

    public Animator _animator;
    public Rigidbody2D _rb2d;
    public int _hp;
    public int _atk;
    public Camera _camera;
    private void Awake()
    {
        _camera = Camera.main;
        _animator = this.transform.GetChild(0).GetComponent<Animator>();
        _rb2d = this.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
    }
    public IEnumerator FireUpdate(float coolTime)
    {
        yield return new WaitForSeconds(coolTime);
        IsFireAble = true;
    }
    public void Fire()
    {
        if (IsFireAble)
        {
            Debug.Log("Fire");
            StartCoroutine("FireUpdate", FireCoolTime);
            IsFireAble = false;
        }
        else
        {
            Debug.Log("CoolTime");
        }
    }
    void GetDamage(int damage)
    {
        _hp -= damage;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag != "Item")
        {
            Debug.Log("충돌");
            GetDamage(1);
            _animator.SetTrigger("Hit");
        }
        else
        {
            Managers.Data.GetItem(0);
        }
    }
}
