using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item_Base : MonoBehaviour
{
    protected Define.Object _objectType;
    public Define.Object ObejctType { get; } 

    [SerializeField] protected float _speed;
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
