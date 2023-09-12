using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Object_Base, IFire
{
    [SerializeField] public float FireCoolTime { get; set; }
    public bool IsFireAble { get; set; }
    public float Speed { get { return _speed; } set { _speed = value; } }
    [SerializeField] public SpriteRenderer _sprite;
    [SerializeField] Transform _bulletTrans;
    public Animator _animator;
    public Rigidbody2D _rb2d;
    public int _hp;
    public int _atk;
    public Camera _camera;
    public string _bullet;
    bool _isSkill = true;
    private void Awake()
    {
        IsFireAble = true;
        FireCoolTime = 0.2f;
        _hp = 10;
        _atk = 3;
        Speed = 5f;
        _bullet = "PlayerBullet";
        _camera = Camera.main;
        _animator = this.transform.GetChild(0).GetComponent<Animator>();
        _rb2d = this.GetComponent<Rigidbody2D>();
        _objectType = Define.Object.Player;
        Managers.Object.Add(this.gameObject , Define.Object.Player);
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
            Managers.Resource.Instantiate("PlayerGudiedBullet", _bulletTrans.position , this.transform.rotation);
            StartCoroutine("FireUpdate", FireCoolTime);
            IsFireAble = false;
            Managers.Sound.Play("Fire", Define.Sound.Effect, 1);
        }
        else
        {
            Debug.Log("CoolTime");
        }
    }
    public void GetDamage(int damage)
    {
        _hp -= damage;
        _animator.SetTrigger("Hit");
        if (_hp <= 0)
        {
            _isDead = true;
            Speed = 0;
            _animator.SetTrigger("IsDead");
            Managers.Sound.Play("Destroy", Define.Sound.Effect, 1);
        }
    }
    public void HitEffect(string tag, int layer)
    {
        gameObject.tag = tag;
        gameObject.layer = layer;
    }
    public void DestroyPlayer()
    {
        Managers.Resource.Destroy(this.gameObject);
    }
    public void SpeedUp()
    {
        if(_isSkill)
        {
            _sprite.color = Color.cyan;
            Speed = 8f;
            Managers.Sound.Play("Skill", Define.Sound.Effect, 1);
            StartCoroutine(SpeedDown());
        }
        else
        {
            Debug.Log("쿨타임 기다리는중");
        }
    }
    IEnumerator SpeedDown()
    {
        _isSkill = false;
        yield return new WaitForSeconds(10f);
        Speed = 5f;
        _sprite.color = Color.white;
        yield return new WaitForSeconds(10f);
        _isSkill = true;
    }
}
