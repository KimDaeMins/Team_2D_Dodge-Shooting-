using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Object_Base, IFire
{
    [SerializeField] public float FireCoolTime { get; set; }
    public bool IsFireAble { get; set; }


    public float Speed { get { return _speed; } set { _speed = value; } }

    public Animator _animator;
    public Rigidbody2D _rb2d;
    public int _hp;
    public int _atk;
    public Camera _camera;
    private void Awake()
    {
        IsFireAble = true;
        FireCoolTime = 0.3f;
        _hp = 3;
        Speed = 5f;
        _camera = Camera.main;
        _animator = this.transform.GetChild(0).GetComponent<Animator>();
        _rb2d = this.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
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
            //Managers.Resource.Instantiate("Bullet");
            StartCoroutine("FireUpdate", FireCoolTime);
            IsFireAble = false;
        }
        else
        {
            Debug.Log("CoolTime");
        }
    }
    public void GetDamage(int damage)
    {
        _hp -= damage;
        if(_hp <= 0)
        {
            _isDead = true;
            _animator.SetTrigger("IsDead");
        }
    }
    public void DestroyPlayer()
    {
        Destroy(this.gameObject);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag != "Item")
        {
            _animator.SetTrigger("Hit");
            /*if(collision.tag == "Monster")
            {
                collision.gameObject.GetComponent<Monster>().GetDamage(_atk);
            }*/
        }
        else
        {
            Managers.Data.GetItem(0);
        }
    }
}
