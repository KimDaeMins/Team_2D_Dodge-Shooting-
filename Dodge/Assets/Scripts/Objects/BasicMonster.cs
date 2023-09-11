using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BasicMonster : Monster, IFire
{
    public float FireCoolTime { get; set; }
    public bool IsFireAble { get; set; }
    private Vector2 _fireDirection;
    private GameObject _target;
    
    protected override void Awake()
    {
        base.Awake();
        _currentHp = 1;
        _moveSpeed = 1;
        _moveDirection = new Vector2(-1, 0);
        FireCoolTime = 1f;
        IsFireAble = true;
        // _target = Util.GetOrAddComponent<GameObject>(Player);
    }

    protected void Update()
    {
        // _fireDirection
        Fire();
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
    
    public IEnumerator FireUpdate(float coolTime)
    {
        yield return new WaitForSeconds(coolTime);
        IsFireAble = true;
    }

    public void Fire()
    {
        if (IsFireAble)
        {
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
