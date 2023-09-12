﻿using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
/// <summary>
/// 오른쪽으로 이동하며 정면으로 공격하는 몬스터, 이동 후 일정이상 스크린 밖으로 벗어나면 사라짐
/// </summary>
public class RightSideMoveMonster : Monster, IFire
{
    public float FireCoolTime { get; set; }
    public bool IsFireAble { get; set; }
    
    protected override void Awake()
    {
        base.Awake();
        _currentHp = 1;
        FireCoolTime = 1f;
        IsFireAble = true;
    }

    protected override void Update()
    {
        base.Update();
        Fire();
    }

    protected override void MoveDirectionUpdate()
    {
        _moveDirection = transform.right * (_speed * Time.deltaTime);
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
            Managers.Resource.Instantiate("MonsterBullet", transform.position, transform.rotation);
            
            StartCoroutine("FireUpdate", FireCoolTime);
            IsFireAble = false;
            Debug.Log("총쏨");
        }
        else
        {
            Debug.Log("CoolTime");
        }
    }
    
    protected void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("충돌");
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            GetDamage(100);
        }
    
        if (other.gameObject.CompareTag("Player"))
        {
            GetDamage(100);
        }
    }
}   

