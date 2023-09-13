using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonster : Monster, IFire
{
    public float FireCoolTime { get; set; }
    public bool IsFireAble { get; set; }
    [SerializeField] private bool _move;
    int _bulletCount;
    float _bossPatternCooltime;
    protected override void Awake()
    {
        base.Awake();
        FireCoolTime = 0.1f;
        IsFireAble = true;
        _damage = 1;
        _bulletCount = 10;
        _bossPatternCooltime = 2f;
    }
    private void OnEnable()
    {
        _currentHp = 10;
    }
    protected  void Start()
    {
        StartCoroutine(BossPattern());
    }
    public IEnumerator FireUpdate(float coolTime)
    {
        yield return new WaitForSeconds(coolTime);
        IsFireAble = true;
    }

    public virtual void Fire()
    {
        if (IsFireAble)
        {
            float angle = 150f / (_bulletCount - 3);
            var _rot = transform.eulerAngles;
            for (int i = 0; i < (_bulletCount - 3); i++)
            {
                Managers.Resource.Instantiate("MonsterBullet", transform.position,
                Quaternion.Euler(_rot.x, _rot.y, _rot.z - 70f + (angle * i)));
            }
            IsFireAble = false;
            StartCoroutine("FireUpdate", FireCoolTime);
        }
    }

    public IEnumerator Shoot()
    {
        float angle = 150f / _bulletCount;
        var _rot = transform.eulerAngles;
        for (int i = 0; i < _bulletCount; i++)
        {
            Managers.Resource.Instantiate("MonsterBullet", transform.position,
            Quaternion.Euler(_rot.x, _rot.y, _rot.z - 70f + (angle * i)));
            yield return new WaitForSeconds(0.1f);
        }
    }
    private IEnumerator BossPattern()
    {
        int currentPhase = 1;
        while (!_isDead)
        {
            switch (currentPhase)
            {
                case 1:
                    Fire();
                    break;

                case 2:
                    StartCoroutine(Shoot());
                    break;

                case 3:
                    //작업중
                    break;
                default:
                    break;
            }
            yield return new WaitForSeconds(_bossPatternCooltime);
            if (currentPhase < 3)
            {
                currentPhase++;
            }
            else
            {
                currentPhase = 1;
            }
        }
    }
}
