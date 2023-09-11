using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGudiedBullet : Object_Base, IBullet
{
    private Rigidbody2D _rigidBody;
    private int _damage = 5; // �Ѿ� ������
    private float _lifeTime = 10.0f; //�Ѿ��� ����ִ� �ð�
    private GameObject _target;  //���� �ý��� �� target Ž��
    private Vector2 _targetVector;  //Ÿ�� ��������
    private Vector2 _dirVector;     //�󸶳� ������� ���� �ý��� ���� ����

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
        _target = GameObject.FindWithTag("Monster"); //Ÿ�� Ž��
        _targetVector = (_target.transform.position - transform.position).normalized;   //Ÿ�� ���� ��������
        _dirVector = _target.transform.position - transform.position;
    }

    public void Move()
    {
        Follow();
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

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<Player>().GetDamage(_damage);
            Managers.Resource.Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        Move();
        if (DeadCheck())
        {
            _isDead = true;
            Managers.Resource.Destroy(this.gameObject);
        }
    }

    IEnumerator Follow()
    {
        while(gameObject.activeSelf && _dirVector.magnitude < 10) //�Ѿ��� ����ְ� �󸶳� ������� ����
        {
            _targetVector = (_target.transform.position - transform.position).normalized;
            // ����(dot)�� ���� ������ ����
            float dot = Vector3.Dot(transform.up, _targetVector);
            if (dot < 1.0f)
            {
                float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;

                // ������ ���� ������ ������ �Ǻ�
                Vector3 cross = Vector3.Cross(transform.up, _targetVector);
                // ���� ��� ���� ���� ���� �ݿ�
                if (cross.z < 0)
                {
                    angle = transform.rotation.eulerAngles.z - Mathf.Min(10, angle);
                }
                else
                {
                    angle = transform.rotation.eulerAngles.z + Mathf.Min(10, angle);
                }

                // angle�� �� ����� target�� ����.
            }
            _dirVector = _target.transform.position - transform.position;
            yield return new WaitForSeconds(0.1f); //0.1�ʸ��� ����������� �ݿ� �� ���������� ���� ����
        }
    }
}
