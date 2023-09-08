using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Object_Base, IFire
{
    public int Hp { get; set; }
    [SerializeField] protected Animator _animator;
    protected Camera _camera;
    [SerializeField] protected Rigidbody2D _rb2d;
    public float FireDelay { get; set; }
    public float FireCoolTime { get; set; }
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
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("충돌");
        _animator.SetTrigger("Hit");
    }
}
