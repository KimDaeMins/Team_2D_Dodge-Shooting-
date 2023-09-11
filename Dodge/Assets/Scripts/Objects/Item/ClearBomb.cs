using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearBomb : Object_Base
{
    
    // Start is called before the first frame update
    public void UseClearBomb()
    {

        Debug.Log("ClearBomb을 사용했습니다.");
        GameObject[] monsterBullets = GameObject.FindGameObjectsWithTag("MonsterBullet");

        foreach (GameObject bullet in monsterBullets)
        {
            Destroy(bullet);
        }
    }

    void Start()
    {
        UseClearBomb();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
