using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// 플레이어를 따라 천천히 돌진하여 공격하는 몬스터, 플레이어와 충돌시 폭발하며 사라짐(데이미를 입힘)
/// </summary>
public class GuidedMonster : Monster, IFire
{
    public float FireCoolTime { get; set; }
    public bool IsFireAble { get; set; }
    private GameObject _player;
    private Vector3 _playerPosition;
    private Vector2 _playerDirection;
    private float _lifetime;

    protected override void Awake()
    {
        base.Awake();
        _damage = 1;
        FireCoolTime = 1f;
        IsFireAble = true;
    }
    
    protected void Start()
    {
        _player = Managers.Object.GetPlayer();
    }

    protected override void Update()
    {
        base.Update();
        RotateDirectionUpdate();
        Timer();
        Fire();
    }
    
    protected override void MoveDirectionUpdate()
    {
        _moveDirection = transform.up * (_speed * Time.deltaTime);
    }

    private void RotateDirectionUpdate()
    {
        _playerPosition = _player.transform.position;
        if (_player != null)
        {
            _playerDirection = (_playerPosition - transform.position).normalized;
            // 내적(dot)을 통해 각도를 구함
            float dot = Vector3.Dot(transform.up, _playerDirection);
            if (dot < 1.0f)
            {
                float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;

                // 외적을 통해 각도의 방향을 판별
                Vector3 cross = Vector3.Cross(transform.up, _playerDirection).normalized;
                // 외적 결과 값에 따라 각도 반영
                if (cross.z < 0)
                {
                    angle = transform.rotation.eulerAngles.z - Mathf.Min(10, angle);
                }
                else
                {
                    angle = transform.rotation.eulerAngles.z + Mathf.Min(10, angle);
                }
                transform.rotation = Quaternion.Lerp(transform.rotation , Quaternion.Euler(0 , 0 , angle).normalized , 0.2f);
            }
        }
    }
    
    private void Timer()
    {
        _lifetime -= Time.deltaTime;
        if (_lifetime <= 0)
        {
            Dead();
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
            Managers.Resource.Instantiate("MonsterBullet", transform.position, transform.rotation);
            
            StartCoroutine("FireUpdate", FireCoolTime);
            IsFireAble = false;
        }
    }
    
    private void OnEnable()
    {
        _lifetime = 20;
        _currentHp = 1;
    }
}   