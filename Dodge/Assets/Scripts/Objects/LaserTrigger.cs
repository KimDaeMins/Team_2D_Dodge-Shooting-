using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTrigger : LaserBullet
{
    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") 
            other.GetComponent<Player>().GetDamage(_damage);
        if (other.tag == "Monster")
            other.GetComponent<Monster>().GetDamage(_damage);
    }
}
