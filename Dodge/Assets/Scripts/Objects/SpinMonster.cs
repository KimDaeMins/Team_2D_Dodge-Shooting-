using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinMonster : Monster, IFire
{
    public float FireCoolTime { get; set; }
    public bool IsFireAble { get; set; }
    private float _rotationSpeed;
    private int _stage;
    private float _lifeTime = 0;
    private Animator _animator;
    [SerializeField] string _bullet;
    protected override void Awake()
    {
        base.Awake();
        FireCoolTime = 0.1f - (0.3f * _stage - 1);
        _rotationSpeed = 45f + (0.8f * _stage - 1);
        IsFireAble = true;
        _damage = 1;
        _animator = this.transform.GetChild(0).GetComponent<Animator>();
    }
    protected override void OnEnable()
    {
        base.OnEnable();
    }
    protected override void Update()
    {
        _lifeTime += Time.deltaTime;
        if (_lifeTime >= 15f)
        {
            Managers.Resource.Destroy(this.gameObject);
        }
        transform.Rotate(Vector3.forward * _rotationSpeed * Time.deltaTime);
        Fire();
    }

    public IEnumerator FireUpdate(float coolTime)
    {
        IsFireAble = false;
        yield return new WaitForSeconds(coolTime);
        IsFireAble = true;
    }

    public virtual void Fire()
    {
        if (IsFireAble)
        {
            Managers.Resource.Instantiate(_bullet, transform.position, transform.rotation);

            StartCoroutine("FireUpdate", FireCoolTime);
            
        }
    }
}
