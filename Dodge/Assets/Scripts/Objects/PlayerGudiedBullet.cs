using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGudiedBullet : Item_Base, IBullet
{
    private GameObject _hitEffect;
    private Rigidbody2D _rigidBody;
    private int _damage = 5; // �Ѿ� ������
    private float _lifeTime = 10.0f; //�Ѿ��� ����ִ� �ð�
    private GameObject _target;  //���� �ý��� �� target Ž��
    private Vector2 _targetVector;  //Ÿ�� ��������

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


    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();   //�Ѿ� ������ ����

        //if ((_target = GameObject.FindWithTag("Monster")) != null) //Ÿ�� Ž��
        //    _targetVector = (_target.transform.position - transform.position).normalized;   //Ÿ�� ���� ��������
        //else
        //    _targetVector = transform.up;

        _target = Managers.Object.GetNearObject(this.gameObject, Define.Object.Monster);
        _targetVector = transform.up;
        _objectType = Define.Object.PlayerBullet;
    }

    public void Move()
    {
        _rigidBody.velocity = _targetVector * _speed * Time.deltaTime;
    }

    public bool DeadCheck()
    {
        _lifeTime -= Time.deltaTime;     // �Ѿ� ����ִ� �ð�
        if (_lifeTime <= 0)
        {
            return true;
        }

        //ȭ����� ��
        if (transform.position.x > Screen.width + 3 || transform.position.x < -Screen.width - 3 ||
            transform.position.y > Screen.height + 3 || transform.position.y < -Screen.height - 3)
        {
            return true;
        }

        return false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Monster")
        {
            _hitEffect = Managers.Resource.Instantiate("MonsterHitEffect", transform.position);
            Managers.Resource.Destroy(_hitEffect, 0.5f);
            other.GetComponent<Player>().GetDamage(_damage);
            Managers.Resource.Destroy(this.gameObject);
        }
    }

    private void Follow()
    {
        if (_target != null)
        {
            if (gameObject.activeSelf && _lifeTime > 5) //�Ѿ��� ����ְ� �󸶳� ������� ���� ���Ƿ� 5�� ���� �־��
            {
                _targetVector = (_target.transform.position - transform.position).normalized;
                // ����(dot)�� ���� ������ ����
                float dot = Vector3.Dot(transform.up, _targetVector);
                if (dot < 1.0f)
                {
                    float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;

                    // ������ ���� ������ ������ �Ǻ�
                    Vector3 cross = Vector3.Cross(transform.up, _targetVector).normalized;
                    // ���� ��� ���� ���� ���� �ݿ�
                    if (cross.z < 0)
                    {
                        angle = transform.rotation.eulerAngles.z - Mathf.Min(10, angle);
                    }
                    else
                    {
                        angle = transform.rotation.eulerAngles.z + Mathf.Min(10, angle);
                    }

                    transform.rotation = Quaternion.Euler(0, 0, angle).normalized;
                    // angle�� �� ����� target�� ����.
                }
            }
        }
    }

    void Update()
    {
        Move();
        Follow();
        if (DeadCheck())
        {
            _isDead = true;
            Managers.Resource.Destroy(this.gameObject);
        }
    }

}
