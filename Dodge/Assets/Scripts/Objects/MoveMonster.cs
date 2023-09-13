using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Unity.VisualScripting;
using UnityEngine;
/// <summary>
/// 오른쪽으로 이동하며 정면으로 공격하는 몬스터, 이동 후 일정이상 스크린 밖으로 벗어나면 사라짐
/// </summary>
public class MoveMonster : Monster, IFire
{
    public float FireCoolTime { get; set; }
    public bool IsFireAble { get; set; }
    [SerializeField] Vector3 _move;
    [SerializeField] int _bulletCount;
    [SerializeField] string _bullet;

    protected override void Awake()
    {
        base.Awake();
        FireCoolTime = 1f;
        IsFireAble = true;
        _damage = 1;
        _move = _move.normalized;
    }
    private void OnEnable()
    {
        _currentHp = 1;
    }
    protected override void Update()
    {
        base.Update();
        Fire();
    }

    protected override void MoveDirectionUpdate()
    {
        _moveDirection = this.transform.rotation * _move * (_speed * Time.deltaTime);
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
            StartCoroutine(Shoot());
            IsFireAble = false;
            StartCoroutine("FireUpdate", FireCoolTime);
        }
    }
 
    public IEnumerator Shoot()
    {
        for (int i = 0; i < _bulletCount; i++)
        {
            Managers.Resource.Instantiate(_bullet, transform.position, transform.rotation);
            yield return new WaitForSeconds(0.05f);
        }
    }
    
   
}   

