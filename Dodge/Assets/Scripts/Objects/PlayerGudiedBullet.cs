using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGudiedBullet : Item_Base, IBullet
{
    private GameObject _hitEffect;
    private Rigidbody2D _rigidBody;
    private int _damage = 5; // 총알 데미지
    private float _lifeTime = 10.0f; //총알이 살아있는 시간
    private GameObject _target;  //유도 시스템 시 target 탐색
    private Vector2 _targetVector;  //타겟 단위벡터

    public int Damage
    {
        get => _damage;
        set => _damage = value;
    }
    public float LifeTime
    {
        get => _lifeTime;
        set => _lifeTime = value;
    }
    public GameObject Target
    {
        get => _target;
        set => _target = value;
    }


    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();   //총알 움직임 위해

        //if ((_target = GameObject.FindWithTag("Monster")) != null) //타겟 탐색
        //    _targetVector = (_target.transform.position - transform.position).normalized;   //타겟 방향 단위벡터
        //else
        //    _targetVector = transform.up;

        _target = Managers.Object.GetNearObject(this.gameObject, Define.Object.Monster);
        _targetVector = transform.up;
        _objectType = Define.Object.PlayerBullet;
    }

    public void Move()
    {
        _rigidBody.velocity = _targetVector * _speed * Time.deltaTime;
    }

    public bool DeadCheck()
    {
        _lifeTime -= Time.deltaTime;     // 총알 살아있는 시간
        if (_lifeTime <= 0)
        {
            return true;
        }

        //화면범위 밖
        if (transform.position.x > Screen.width + 3 || transform.position.x < -Screen.width - 3 ||
            transform.position.y > Screen.height + 3 || transform.position.y < -Screen.height - 3)
        {
            return true;
        }

        return false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Monster")
        {
            _hitEffect = Managers.Resource.Instantiate("MonsterHitEffect", transform.position);
            Managers.Resource.Destroy(_hitEffect, 0.5f);
            other.GetComponent<Player>().GetDamage(_damage);
            Managers.Resource.Destroy(this.gameObject);
        }
    }

    private void Follow()
    {
        if (_target != null)
        {
            if (gameObject.activeSelf && _lifeTime > 5) //총알이 살아있고 얼마나 가까운지 조건 임의로 5초 조건 넣어둠
            {
                _targetVector = (_target.transform.position - transform.position).normalized;
                // 내적(dot)을 통해 각도를 구함
                float dot = Vector3.Dot(transform.up, _targetVector);
                if (dot < 1.0f)
                {
                    float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;

                    // 외적을 통해 각도의 방향을 판별
                    Vector3 cross = Vector3.Cross(transform.up, _targetVector).normalized;
                    // 외적 결과 값에 따라 각도 반영
                    if (cross.z < 0)
                    {
                        angle = transform.rotation.eulerAngles.z - Mathf.Min(10, angle);
                    }
                    else
                    {
                        angle = transform.rotation.eulerAngles.z + Mathf.Min(10, angle);
                    }

                    transform.rotation = Quaternion.Euler(0, 0, angle).normalized;
                    // angle이 윗 방향과 target의 각도.
                }
            }
        }
    }

    void Update()
    {
        Move();
        Follow();
        if (DeadCheck())
        {
            _isDead = true;
            Managers.Resource.Destroy(this.gameObject);
        }
    }

}
