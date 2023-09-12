using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Object_Base
{
    [SerializeField] private string _name;
    public string Name { get => _name; }

    [SerializeField] private Vector2 _moveDir;
    public Vector2 MoveDir { get => _moveDir; }
    public int Count { get; set; } = 1;

    private void Start()
    {
    }
    private void Update()
    {
        
    }

    public void Move()
    {
        
    }
}
