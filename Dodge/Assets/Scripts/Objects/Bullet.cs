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
    private int _damage = 5; // �Ѿ� ������
    private float _lifeTime = 10.0f; //�Ѿ��� ����ִ� �ð�
    private GameObject _target;  //���� �ý��� �� target Ž��

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
        _lifeTime -= Time.deltaTime;     // �Ѿ� ����ִ� �ð�
        if (_lifeTime < 0)
        {
            _lifeTime = 10.0f;
            return true;
        }

        //���⼭ ������ ȭ�� ���� ������ �״°ŵ� ¥����
        if (transform.position.x > 100 || transform.position.x < 0 || transform.position.y > 100 || transform.position.y < 0)
        {
            //ȭ��ũ�� �������¹�� -
            //ȭ��ũ�� �¿�� ���� �а� �ؼ�
            //�׹����� �Ѿ�� �����ǰԲ�
        }

        return false;
    }

    //�Ҹ� ����Ʈ(������)
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
