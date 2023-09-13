using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Monster_HpBar : MonoBehaviour
{
    public int MaxBar { get; set; }
    RectTransform _rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        _rectTransform = transform.GetChild(1).GetComponent<RectTransform>();
    }
    private void OnEnable()
    {
        SetHpBar(MaxBar);
    }
    public void SetHpBar(int currentHp)
    {
        Vector2 localScale = _rectTransform.localScale;
        localScale.x =  (float)currentHp/ (float)MaxBar;
        _rectTransform.localScale = localScale;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.identity;
    }
}
