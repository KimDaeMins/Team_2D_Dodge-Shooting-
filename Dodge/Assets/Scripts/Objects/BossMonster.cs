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
    private int _currentPhase;

    protected override void Awake()
    {
        base.Awake();
        FireCoolTime = 0.1f;
        IsFireAble = true;
        _damage = 1;
        _bulletCount = 10;
        _bossPatternCooltime = 2f;
    }
    protected override void OnEnable()
    {
        base.OnEnable();
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
            var _rot = transform.eulerAngles;
            if (_currentPhase == 1)
            {
                float angleStep = 360f / _bulletCount;
                for (int i = 0; i < _bulletCount; i++)
                {
                    float angle = i * angleStep;
                    Managers.Resource.Instantiate("MonsterBullet", transform.position,
                        Quaternion.Euler(0, 0, _rot.z + angle));
                }
            }
            else
            {
                float angle = 150f / (_bulletCount - 3);
                for (int i = 0; i < (_bulletCount - 3); i++)
                {
                    Managers.Resource.Instantiate("MonsterBullet", transform.position,
                        Quaternion.Euler(_rot.x, _rot.y, _rot.z - 70f + (angle * i)));
                }
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
        while (!_isDead)
        {
            _currentPhase = Random.Range(1, 4);
            switch (_currentPhase)
            {
                case 1:
                case 2:
                    Fire();
                    break;

                case 3:
                    StartCoroutine(Shoot());
                    break;
                default:
                    break;
            }
            yield return new WaitForSeconds(_bossPatternCooltime);
        }
    }
}
