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

    
    private float minX, maxX, minY, maxY; // 화면 경계값
    private float minBounceAngle = 30f; // 최소 튕김 각도
    private float maxBounceAngle = 60f; // 최대 튕김 각도
    private Rigidbody2D rb;

    private void Start()
    {
        minX = Camera.main.ScreenToWorldPoint(Vector3.zero).x;
        maxX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        minY = Camera.main.ScreenToWorldPoint(Vector3.zero).y;
        maxY = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;


        rb = GetComponent<Rigidbody2D>();

        rb.velocity = _moveDir * _speed;

        float bounceAngle = Random.Range(minBounceAngle, maxBounceAngle);
        Vector2 bounceDirection = Quaternion.Euler(0f, 0f, bounceAngle) * Vector2.right;
        rb.velocity = bounceDirection.normalized * _speed;
    }
    private void Update()
    {
        


        // 화면 경계에 부딪혔을 때 튕기는 처리
        if (transform.position.x < minX || transform.position.x > maxX)
        {
            _moveDir.x *= -1; // x 방향 반전
            rb.velocity = _moveDir * _speed; // 반전된 방향으로 이동
        }
        if (transform.position.y < minY || transform.position.y > maxY)
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
