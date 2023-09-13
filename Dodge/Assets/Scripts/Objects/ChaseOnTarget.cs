using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseOnTarget : Object_Base
{
    private const float LINEWIDTH = 0.1f;
    private const float CHASETIME = 3.0f;
    public static Vector3[] _lineSetPosition = new Vector3[2];
    private LineRenderer _lineRender;
    private float _lifeTime = 5.0f;
    private GameObject _target;
    private Vector2 _targetVector;
    private Vector2 _nowVector;
    private bool _targetOn;

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

    public bool DeadCheck()
    {
        _lifeTime -= Time.deltaTime;
        if (_lifeTime <= 0)
        {
            _isDead = true;
            return true;
        }
        
        return false;
    }

    private void OnTarget()
    {
        if (_lifeTime >= 2)
        {
            _lineRender.SetPosition(0, _lineSetPosition[0]);
            _targetVector = _target.transform.position - _lineSetPosition[0];
            _targetVector.Normalize();
            _nowVector = Vector2.Lerp(_nowVector, _targetVector, 0.02f);
            _lineRender.SetPosition(1, _nowVector * 200f);
            _lineSetPosition[1] = _nowVector;
        }
    }

    private void Awake()
    {
        _target = Managers.Object.GetPlayer();
        _lineRender = GetComponent<LineRenderer>();
        _lineRender.material.color = Color.red;
        _lineRender.startWidth = LINEWIDTH;
        _lineRender.endWidth = LINEWIDTH;
        _lineSetPosition[0] = transform.position;
        _lineRender.positionCount = _lineSetPosition.Length;
    }

    private void Start()
    {
        _nowVector = _target.transform.position - transform.position;
        _nowVector.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        _lineSetPosition[0] = transform.position;
        OnTarget();
        
        
        if (DeadCheck())
        {
            _isDead = true;
            Managers.Resource.Destroy(this);
        }
    }


    
}
