using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Object_Base, IFire
{
    public int Hp;
    public int Atk;
    public float FireDelay { get; set; }
    public float FireCoolTime { get; set; }
    public float Speed { get { return _speed; } set { _speed = value; } }
    [SerializeField] public Animator _animator;
    [SerializeField] public Rigidbody2D _rb2d;
    public Camera _camera;
    private void Awake()
    {
        //_camera = Camera.main;
        Hp = 3;
        Atk = 1;
        FireDelay = 0;
        FireCoolTime = 0.4f;
    }
    private void Update()
    {
        FireUpdate();
    }
    public void FireUpdate()
    {
        if (FireCoolTime > FireDelay)
            FireDelay += Time.deltaTime;
    }
    public bool FireCheck()
    {
        if (FireDelay > FireCoolTime)
            return true;
        return false;
    }

    public void Fire()
    {
        if (FireCheck())
        {
            FireDelay = 0;
            Debug.Log("Fire");
        }
        else
        {
            Debug.Log("CoolTime");
        }
    }
    void GetDamage(int damage)
    {
        Hp -= damage;
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
