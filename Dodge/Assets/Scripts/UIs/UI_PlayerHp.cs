using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_PlayerHp : MonoBehaviour
{
    public int MaxBar;
    RectTransform _rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        _rectTransform = transform.GetChild(1).GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHpBar(int currentHp)
    {
        Vector2 localScale = _rectTransform.localScale;
        localScale.x = (float)currentHp / (float)MaxBar;
        _rectTransform.localScale = localScale;
    }
}
