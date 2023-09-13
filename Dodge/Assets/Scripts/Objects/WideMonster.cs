using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WideMonster : Monster, IFire
{
    public float FireCoolTime { get; set; }
    public bool IsFireAble { get; set; }
    float _lifetime = 0;
    [SerializeField] private bool _move;
    int _bulletCount;
    protected override void Awake()
    {
        base.Awake();
        FireCoolTime = 2f;
        IsFireAble = true;
        _damage = 1;
        _bulletCount = 12;
    }
    protected override void OnEnable()
    {
        base.OnEnable();
    }
    protected override void Update()
    {
        _lifetime += Time.deltaTime;
        if (_lifetime >= 15)
        {
            Managers.Resource.Destroy(this.gameObject);
        }
        base.Update();
        Fire();
    }

    protected override void FixedUpdate()
    {
        if (_move)
        {
            base.FixedUpdate();
        }
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
            float angleStep = 360f / _bulletCount;
            for (int i = 0; i < _bulletCount; i++)
            {
                float angle = i * angleStep;
                Managers.Resource.Instantiate("MonsterBullet", transform.position,
                Quaternion.Euler(0, 0, angle));
            }

            IsFireAble = false;
            StartCoroutine("FireUpdate", FireCoolTime);
            
        }
    }
}
