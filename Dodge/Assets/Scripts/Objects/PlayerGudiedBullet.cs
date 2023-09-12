using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGudiedBullet : Object_Base, IBullet
{
    private const float ANGLE = 60f; // 60�� ������ Ÿ�� Ž���ϱ� ���� ���� ���
    private const float RATE = 0.2f; // Lerp t ���� 0.3f
    private const float TARGET_DEAD_TIME = 5.0f; // Ÿ�� ���󰡴� �ð�
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
        if(_target == null)
        {
            _target = Managers.Object.GetNearObject(this.gameObject, Define.Object.Monster);
            return;
        }

        if (_target != null)
        {
            if (gameObject.activeSelf && _lifeTime > TARGET_DEAD_TIME) //�Ѿ��� ����ְ� �󸶳� ������� ���� ���Ƿ� 5�� ���� �־��
            {
                _targetVector = (_target.transform.position - transform.position).normalized;
                // ����(dot)�� ���� ������ ����
                float dot = Vector3.Dot(transform.up, _targetVector);
                float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;

                if (angle < ANGLE)
                {

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

                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, angle).normalized, RATE);
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
