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
    private float damage = 5.0f; // 총알 데미지
    public float Damage 
    {
        get => damage;
        set => damage = value; 
    }

    private GameObject target;  //유도 시스템 시 target 탐색
    public GameObject Target 
    {
        get => target; 
        set => target = value; 
    }

    private float lifeTime = 10.0f; //총알이 살아있는 시간
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
        LifeTime -= Time.deltaTime;     // 총알 살아있는 시간
        if (LifeTime < 0)
        {
            LifeTime = 10.0f;
            return true;
        }

        //여기서 지정한 화면 밖을 나가면 죽는거도 짜야함
        if (this.transform.position.x > 100 || this.transform.position.x < 0 || this.transform.position.y > 100 || this.transform.y < 0)
            return true;

        return false;
    }

    //불릿 이펙트(프리팹)
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
