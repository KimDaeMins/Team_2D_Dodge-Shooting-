using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Unity.VisualScripting;
using UnityEngine;
/// <summary>
/// 왼쪽으로 이동하며 정면으로 공격하는 몬스터, 이동 후 일정이상 스크린 밖으로 벗어나면 사라짐
/// </summary>
public class LeftMoveMonster : Monster, IFire
{
    public float FireCoolTime { get; set; }
    public bool IsFireAble { get; set; }
    
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

    protected override void MoveDirectionUpdate()
    {
        _moveDirection = new Vector2(-1 * transform.right.x, transform.right.y) * (_speed * Time.deltaTime);
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
            Managers.Resource.Instantiate("MonsterBullet" , transform.position, transform.rotation);
            
            StartCoroutine("FireUpdate", FireCoolTime);
            IsFireAble = false;
        }
    }
}   

