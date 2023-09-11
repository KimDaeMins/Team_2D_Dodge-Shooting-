using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Object_Base, IBullet
{
    [SerializeField] private float _speed;
    public Player player;
    private GameObject[] monsters;
    private Transform spawn_bulletPos;
    private Rigidbody2D rigidBody;
    private int bulletCase;
    private float damage = 5.0f; // �Ѿ� ������
    public float Damage 
    {
        get => damage;
        set => damage = value; 
    }

    private GameObject target;  //���� �ý��� �� target Ž��
    public GameObject Target 
    {
        get => target; 
        set => target = value; 
    }

    private float lifeTime = 10.0f; //�Ѿ��� ����ִ� �ð�
    public float LifeTime 
    {
        get => lifeTime;
        set => lifeTime = value;
    }

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }


    public void Move()
    {
        this.rigidBody.velocity = this.gameObject.transform.forward * _speed;
    }

    

    public bool DeadCheck()
    {
        LifeTime -= Time.deltaTime;     // �Ѿ� ����ִ� �ð�
        if (LifeTime < 0)
        {
            LifeTime = 10.0f;
            return true;
        }

        //���⼭ ������ ȭ�� ���� ������ �״°ŵ� ¥����
        if (this.transform.position.x > 100 || this.transform.position.x < 0 || this.transform.position.y > 100 || this.transform.y < 0)
            return true;

        return false;
    }

    //�Ҹ� ����Ʈ(������)
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player.Hp -= damage;
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
