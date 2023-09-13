using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGuidedLaser : LaserBullet
{
    private ChaseOnTarget _laserChaseOnTarget;
    private Vector2 _targetVector;
    private float _angle;


    private void Start()
    {
        _targetVector = (ChaseOnTarget._lineSetPosition[1] - transform.position).normalized;
        _angle = Mathf.Atan2(_targetVector.y, _targetVector.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, _angle);
        transform.localScale = new Vector3(transform.localScale.x * Screen.width, 
                                transform.localScale.y, transform.localScale.z);
        _objectType = Define.Object.MonsterBullet;
    }

    protected void Update()
    {
        _lifeTime -= Time.deltaTime;

        if(_lifeTime <= 0)
        {
            Vector2 _vetorScale = transform.localScale;
            _vetorScale.y -= Time.deltaTime * 1;
            transform.localScale = _vetorScale;
            if(transform.localScale.y < 0)
            {
                _isDead = true;
                Managers.Resource.Destroy(gameObject);
            }
        }// 로컬 스케일폭 0으로줄이면서 0 되면 삭제

    }

    
}
