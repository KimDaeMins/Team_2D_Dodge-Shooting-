using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBullet : Object_Base, IBullet
{
    private Vector2 _targetVector;
    private Player _player;
    private Monster _monster;

    private int _damage = 7;
    public int Damage
    {
        get => _damage;
        set => _damage = value;
    }

    private float _lifeTime = 3.0f;
    public float LifeTime
    {
        get => _lifeTime;
        set => _lifeTime = value;
    }

    private GameObject _target;
    public GameObject Target
    {
        get => _target;
        set => _target = value;
    }

    private void Awake()
    {
        _targetVector = transform.up;
        Managers.Resource.Instantiate("LaserBullet");
        _objectType = transform.tag == "PlayerBullet" ? Define.Object.PlayerBullet : Define.Object.MonsterBullet;
    }


    public bool DeadCheck()
    {
        _lifeTime -= Time.deltaTime;
        if (_lifeTime <= 0)
            return true;

        return false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            _player.GetDamage(_damage);
        if (other.tag == "Monster")
            _monster.GetDamage(_damage);

    }

    private void Update()
    {
        if (DeadCheck())
        {
            _isDead = true;
            Managers.Resource.Destroy(this);
        }
    }
    public void Move()
    {

    }
}
