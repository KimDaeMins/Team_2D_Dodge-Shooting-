using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Object_Base, IBullet
{
    private Player _player;
    private Monster _monster;
    private Rigidbody2D _rigidBody;
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
        _rigidBody = GetComponent<Rigidbody2D>();   //�Ѿ� ������ ����
    }


    public void Move()
    {
        _rigidBody.velocity = transform.forward * _speed;
    }

    

    public bool DeadCheck()
    {
        _lifeTime -= Time.deltaTime;     // �Ѿ� ����ִ� �ð�
        if (_lifeTime <= 0)
        {
            return true;
        }

        //���⼭ ������ ȭ�� ���� ������ �״°ŵ� ¥����
        if (transform.position.x > Screen.width + 3 || transform.position.x < -Screen.width - 3 ||
            transform.position.y > Screen.height + 3 || transform.position.y < -Screen.height - 3)
        {
            return true;
        }

        return false;
    }

    //�Ҹ� ����Ʈ(������)
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")   //�÷��̾ �¾��� ��
        {
            Managers.Resource.Destroy(this.gameObject);
            other.GetComponent<Player>().GetDamage(_damage);
        }
        if (other.gameObject.tag == "Monster")  //���Ͱ� �¾��� ��
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
            _isDead = true;     //�Ҹ� �� ���� �� ��Ʈ����
            Managers.Resource.Destroy(this.gameObject);
        }
    }
}
