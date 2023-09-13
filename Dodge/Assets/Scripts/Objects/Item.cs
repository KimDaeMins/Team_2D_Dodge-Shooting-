using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.Progress;

public class Item : Object_Base
{
    [SerializeField] private string _name;
    public string Name { get => _name; }

    [SerializeField] private Vector2 _moveDir;
    public Vector2 MoveDir { get => _moveDir; }
    public int Count { get; set; } = 1;

    
    
    
    private Rigidbody2D rb;

    private float x;
    private float y;
    private void Start()
    {
        if (x >= 9)
        {
            x = 9;
        }
        if (x <= -9)
        {
            x = -9;
        }
        if (y >= 5)
        {
            y = 5;
        }
        if (y <= -5)
        {
            y = -5;
        }

        rb = GetComponent<Rigidbody2D>();

        rb.velocity = _moveDir * _speed;

    }
    private void Update()
    {
        


        // 화면 경계에 부딪혔을 때 튕기는 처리
        if (transform.position.x < -9 || transform.position.x > 9)
        {
            _moveDir.x *= -1; // x 방향 반전
            rb.velocity = _moveDir * _speed; // 반전된 방향으로 이동
        }
        if (transform.position.y < -5 || transform.position.y > 5)
        {
            _moveDir.y *= -1; // y 방향 반전
            rb.velocity = _moveDir * _speed; // 반전된 방향으로 이동
        }
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
            if (this._name == "AddPowerLevel")
            {
                Managers.Object.GetPlayer().GetComponent<Player>().AddPowerLevel();


            }
            else
            {
                Managers.Data.GetItem(this);
            }
            

            // 아이템을 화면에서 제거하거나 기타 처리를 할 수 있습니다.
            Destroy(gameObject);
        }
    }
    
}
