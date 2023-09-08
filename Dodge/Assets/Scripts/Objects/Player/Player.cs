using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Object_Base
{
    public int Hp { get; set; }
    [SerializeField] protected Animator _animator;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("충돌");
        _animator.SetTrigger("Hit");
    }
}
