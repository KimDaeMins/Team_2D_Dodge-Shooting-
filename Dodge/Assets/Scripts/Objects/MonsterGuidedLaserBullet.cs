using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGuidedLaserBullet : Object_Base, IBullet
{
    private LineRenderer _lineRender;
    private int _damage = 10;
    private float _lifeTime = 5.0f;
    private GameObject _target;

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

    public void Move()
    {

    }

    public bool DeadCheck()
    {
        _lifeTime -= Time.deltaTime;
        if (_lifeTime <= 0)
        {
            _isDead = true;
            return true;
        }
        
        return false;
    }

    private void OnTarget()
    {

    }

    private void Awake()
    {
        _target = Managers.Object.GetPlayer();
    }

    // Start is called before the first frame update
    void Start()
    {
        Move();
    }

    // Update is called once per frame
    void Update()
    {
        if (_lifeTime > 2)
        {
            Move();
        }
        else
        {
            OnTarget();
        }
        if (DeadCheck())
        {
            Managers.Resource.Destroy(this);
        }
    }
}
