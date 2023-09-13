using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jamming : MonoBehaviour
{
    public float growthSpeed = 1.0f; // ��Ŭ ��������Ʈ�� Ȯ�� �ӵ�
    public float destroyDelay = 2.0f; // �ı������� ���� �ð�

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
            // ��Ŭ ��������Ʈ�� Ȯ��
            transform.localScale += Vector3.one * growthSpeed * Time.deltaTime;
        }

        // ���� �ð��� ������ �ı�
        if (Time.time - startTime >= destroyDelay)
        {
            Managers.Resource.Destroy(transform.parent.gameObject); // ��ֹ� �����հ� �Բ� �ı�
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger entered!");
        if (other.CompareTag("MonsterBullet"))
        {
            Managers.Resource.Destroy(other.gameObject);
        }
    }
}
