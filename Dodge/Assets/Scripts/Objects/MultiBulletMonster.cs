﻿using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Unity.VisualScripting;
using UnityEngine;
/// <summary>
/// 제자리에서 정면으로 공격하는 몬스터, 여러 총알 동시에 사용
/// </summary>
public class MultiBulletMonster : Monster, IFire
{
    public float FireCoolTime { get; set; }
    public bool IsFireAble { get; set; }
    [SerializeField] private bool _move;
    
    protected override void Awake()
    {
        base.Awake();
        _currentHp = 1;
        FireCoolTime = 1f;
        IsFireAble = true;
        _damage = 1;
    }

    protected override void Update()
    {
        base.Update();
        Fire();
    }

    protected override void FixedUpdate()
    {
        if (_move)
        {
            base.FixedUpdate();
        }
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
            var _rot = transform.eulerAngles;
            Managers.Resource.Instantiate("MonsterBullet", transform.position,
                Quaternion.Euler(_rot.x, _rot.y, _rot.z - 30f));
            Managers.Resource.Instantiate("MonsterBullet", transform.position,
                Quaternion.Euler(_rot.x, _rot.y, _rot.z - 20f));
            Managers.Resource.Instantiate("MonsterBullet", transform.position,
                Quaternion.Euler(_rot.x, _rot.y, _rot.z - 10f));
            Managers.Resource.Instantiate("MonsterBullet" , transform.position, _rot);
            Managers.Resource.Instantiate("MonsterBullet", transform.position,
                Quaternion.Euler(_rot.x, _rot.y, _rot.z + 10f));
            Managers.Resource.Instantiate("MonsterBullet", transform.position,
                Quaternion.Euler(_rot.x, _rot.y, _rot.z + 20f));
            Managers.Resource.Instantiate("MonsterBullet", transform.position,
                Quaternion.Euler(_rot.x, _rot.y, _rot.z + 30f));

            StartCoroutine("FireUpdate", FireCoolTime);
            IsFireAble = false;
        }
    }
    
    private void OnEnable()
    {
        _currentHp = 1;
    }
}   

