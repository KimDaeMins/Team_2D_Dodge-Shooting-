using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainFly : MonoBehaviour, IFire
{
    public float FireCoolTime { get; set; } = 0f;
    public bool IsFireAble { get; set; } = true;

    public IEnumerator FireUpdate(float coolTime)
    {
        yield return new WaitForSeconds(coolTime);
        IsFireAble = true;
    }
    public void Fire()
    {
        if (IsFireAble)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position , transform.up , 100 , LayerMask.GetMask("Water"));
            if (hit.collider != null)
            {
                Quaternion currentRotation = transform.rotation;
                Quaternion invertedRotation = Quaternion.Euler(0 , 0 , 180) * currentRotation;
                Managers.Resource.Instantiate("LogoMonster" , hit.point , invertedRotation);
            }
            Managers.Resource.Instantiate("IntroBullet" , transform.position , transform.rotation);
            StartCoroutine("FireUpdate" , FireCoolTime);
            IsFireAble = false;
            Managers.Sound.Play("Fire" , Define.Sound.Effect , 1f);
        }
        else
        {
            Debug.Log("CoolTime");
        }
    }

   

    // Update is called once per frame
    void Update()
    {
        //Fire();
    }
}
