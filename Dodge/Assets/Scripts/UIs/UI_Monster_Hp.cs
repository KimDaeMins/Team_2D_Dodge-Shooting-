using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Monster_Hp : MonoBehaviour
{
    public int MaxBar { get; set; }
    RectTransform _rectTransform;
    public GameObject _parentObject;
    public Vector3 _offset;
    // Start is called before the first frame update
    void Start()
    {
        _rectTransform = transform.GetChild(1).GetComponent<RectTransform>();
    }
    private void OnEnable()
    {
        //SetHpBar(MaxBar);
    }
    private void OnDisable()
    {
        Vector2 localScale = _rectTransform.localScale;
        localScale.x = 1;
        _rectTransform.localScale = localScale;
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
       // transform.rotation = Quaternion.Inverse(_parentObject.transform.rotation);
        transform.position = _parentObject.transform.position + _offset;
    }
}
