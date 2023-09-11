using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Object_Base, IBullet
{
    [SerializeField] private float _speed;
    public Player _player;
    private GameObject[] _monsters;
    private Transform _spawnBulletPos;
    private Rigidbody2D _rigidBody;
    private int _bulletCase;
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
        _rigidBody = GetComponent<Rigidbody2D>();
    }


    public void Move()
    {
        //this.rigidBody.velocity = this.gameObject.transform.forward * _speed;
        _rigidBody.velocity = transform.forward * _speed;
    }

    

    public bool DeadCheck()
    {
        _lifeTime -= Time.deltaTime;     // 총알 살아있는 시간
        if (_lifeTime < 0)
        {
            _lifeTime = 10.0f;
            return true;
        }

        //여기서 지정한 화면 밖을 나가면 죽는거도 짜야함
        if (transform.position.x > 100 || transform.position.x < 0 || transform.position.y > 100 || transform.position.y < 0)
        {
            //화면크기 가져오는방법 -
            //화면크기 좌우로 조금 넓게 해서
            //그범위를 넘어가면 삭제되게끔
        }

        return false;
    }

    //불릿 이펙트(프리팹)
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<Player>().GetDamage(_damage);
        }
        if (other.gameObject.tag == "Monster")
        {
            other.GetComponent<Player>().GetDamage(_damage);
        }
    }

    private void Update()
    {
        Move();
        if (DeadCheck())
        {
            Managers.Resource.Destroy(this.gameObject);
        }
    }
}
