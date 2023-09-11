using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Object_Base, IBullet
{
    private Player _player;
    private Monster _monster;
    private Rigidbody2D _rigidBody;
    private int _damage = 5; // 총알 데미지
    private float _lifeTime = 10.0f; //총알이 살아있는 시간
    private GameObject _target;  //유도 시스템 시 target 탐색

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
    }


    public void Move()
    {
        _rigidBody.velocity = transform.forward * _speed;
    }

    

    public bool DeadCheck()
    {
        _lifeTime -= Time.deltaTime;     // 총알 살아있는 시간
        if (_lifeTime <= 0)
        {
            return true;
        }

        //여기서 지정한 화면 밖을 나가면 죽는거도 짜야함
        if (transform.position.x > Screen.width + 3 || transform.position.x < -Screen.width - 3 ||
            transform.position.y > Screen.height + 3 || transform.position.y < -Screen.height - 3)
        {
            return true;
        }

        return false;
    }

    //불릿 이펙트(프리팹)
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")   //플레이어가 맞았을 때
        {
            Managers.Resource.Destroy(this.gameObject);
            other.GetComponent<Player>().GetDamage(_damage);
        }
        if (other.gameObject.tag == "Monster")  //몬스터가 맞았을 때
        {
            Managers.Resource.Destroy(this.gameObject);
            other.GetComponent<Monster>().GetDamage(_damage);
        }
    }

    private void Update()
    {
        Move();
        if (DeadCheck())
        {
            _isDead = true;     //불린 값 변경 후 디스트로이
            Managers.Resource.Destroy(this.gameObject);
        }
    }
}
