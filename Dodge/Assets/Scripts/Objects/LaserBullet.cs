using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBullet : Object_Base, IBullet
{
    private Vector2 _targetVector;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _monster;

    protected int _damage = 7;
    public int Damage
    {
        get => _damage;
        set => _damage = value;
    }

    protected float _lifeTime = 3.0f;
    public float LifeTime
    {
        get => _lifeTime;
        set => _lifeTime = value;
    }

    protected GameObject _target;
    public GameObject Target
    {
        get => _target;
        set => _target = value;
    }

    private void OnEnable()
    {
        _lifeTime = 10.0f;
    }
    private void Awake()
    {
        _targetVector = transform.right;
        _objectType = transform.tag == "PlayerBullet" ? Define.Object.PlayerBullet : Define.Object.MonsterBullet;
    }

    private void Start()
    {
        if(transform.tag == "PlayerBullet")
        
            _player = Managers.Object.GetNearObject(gameObject, Define.Object.Player);
        
        if(transform.tag == "MonsterBullet")
        
            _monster = Managers.Object.GetNearObject(gameObject, Define.Object.Monster);
          
        
        transform.localScale = new Vector2(Screen.width * 2 , transform.localScale.y);
    }



    private void Update()
    {
        _lifeTime -= Time.deltaTime;

        Move();
        if (_lifeTime <= 0)
        {
            Vector2 _vetorScale = transform.localScale;
            _vetorScale.y -= Time.deltaTime * 1;
            transform.localScale = _vetorScale;
            if (transform.localScale.y < 0)
            {
                _isDead = true;
                Managers.Resource.Destroy(gameObject);
            }
        }
    }
    public bool DeadCheck()
    {
        if (_lifeTime <= 0)
            return true;

        return false;
    }
    public virtual void Move()
    {
        if (transform.tag == "PlayerBullet")
        {
            _targetVector = _player.transform.up;
            float angle = Mathf.Atan2(_targetVector.y, _targetVector.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
            transform.position = _player.transform.position;
        }
            

        if (transform.tag == "MonsterBullet")
        {
            _targetVector = _monster.transform.up;
            float angle = Mathf.Atan2(_targetVector.y, _targetVector.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
            transform.position = _monster.transform.position;
        }
        
    }
}
