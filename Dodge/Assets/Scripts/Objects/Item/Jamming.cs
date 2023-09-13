using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jamming : MonoBehaviour
{
    public float growthSpeed = 1.0f; // 서클 스프라이트의 확대 속도
    public float destroyDelay = 2.0f; // 파괴까지의 지연 시간

    private bool isGrowing = true;
    private float startTime;

    private void Start()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        if (isGrowing)
        {
            // 서클 스프라이트를 확대
            transform.localScale += Vector3.one * growthSpeed * Time.deltaTime;
        }

        // 일정 시간이 지나면 파괴
        if (Time.time - startTime >= destroyDelay)
        {
            Destroy(transform.parent.gameObject); // 재밍밤 프리팹과 함께 파괴
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MonsterBullet"))
        {
            Destroy(other.gameObject);
        }
    }
}
