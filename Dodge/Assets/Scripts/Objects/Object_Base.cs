using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Object_Base : MonoBehaviour
{
    protected Define.Object _objectType;
    public Define.Object ObejctType { get => _objectType; } 

    [SerializeField] public float _speed;
    protected bool _isDead = false;
    // Start is called before the first frame update
    private void Awake()
    {
        _objectType = Define.Object.None;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }


    
}
