using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Monster : Object_Base, IFire
{
    public float FireCoolTime { get; set; }
    public bool IsFireAble { get; set; }
    protected int _currentHp { get; set; }
    protected Vector2 _moveDirection { get; set; }
    
    protected Rigidbody2D _rigidbody;


    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
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

    private void CheckDead()
    {
        if (_currentHp <= 0)
        {
            _isDead = true;
            Managers.Resource.Destroy(this.gameObject);
            Managers.Resource.Instantiate("MonsterExplosion",
                new Vector3(_rigidbody.position.x, _rigidbody.position.y, 0));
        }
    }

    private void Move(Vector2 direction)
    {
        direction *= _speed;
        _rigidbody.velocity = direction;

    }

    public IEnumerator FireUpdate(float coolTime)
    {
        yield return new WaitForSeconds(coolTime);
        IsFireAble = true;
    }

    public virtual void Fire()
    {
        if (IsFireAble)
        {
            Managers.Resource.Instantiate("MonsterBullet", _rigidbody.position);
            
            StartCoroutine("FireUpdate", FireCoolTime);
            IsFireAble = false;
            Debug.Log("총쏨");
        }
        else
        {
            Debug.Log("CoolTime");
        }
    }
}

