using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// 전방을 향해 빠르게 돌진하여 플레이어와 충돌시 폭발하며 피해를 주고 사라짐
/// </summary>
public class RushMonster : Monster
{
    private Vector3 _playerPosition;
    private Vector2 _playerDirection;

    protected override void Awake()
    {
        base.Awake();
        _damage = 1;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
    }
}   