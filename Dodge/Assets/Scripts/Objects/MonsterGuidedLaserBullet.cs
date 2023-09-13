using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGuidedLaserBullet : LaserBullet
{
    private ChaseOnTarget _laserChaseOnTarget;
    private Rigidbody2D _rigidBody;
    private Vector2 _targetVector;
    private float _angle;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _targetVector = (ChaseOnTarget._lineSetPosition[1] - transform.position).normalized;
        _angle = Mathf.Atan2(_targetVector.y, _targetVector.x ) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, _angle);
        _objectType = Define.Object.MonsterBullet;
    }


    protected void Update()
    {
        Move();
        if (DeadCheck())
        {
            _isDead = true;
            Managers.Resource.Destroy(this);
        }
    }

    public override void Move()
    {
        _rigidBody.velocity = transform.right * _speed * Time.deltaTime;
    }
}
