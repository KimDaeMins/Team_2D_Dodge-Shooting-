using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            // 플레이어와 충돌했을 때 처리
            Managers.Data.GetItem(this);

            // 아이템을 화면에서 제거하거나 기타 처리를 할 수 있습니다.
            Destroy(gameObject);
        }
    }
}
