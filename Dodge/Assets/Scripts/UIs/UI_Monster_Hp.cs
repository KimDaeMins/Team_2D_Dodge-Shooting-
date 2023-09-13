using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Monster_Hp : MonoBehaviour
{
    public int MaxBar { get; set; }
    public RectTransform _rectTransform;
    public GameObject _parentObject;
    public Vector3 _offset;
    // Start is called before the first frame update
    void Awake()
    {
        _rectTransform = transform.GetChild(1).GetComponent<RectTransform>();
    }
    private void OnEnable()
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
        if(_parentObject == null || _parentObject.activeSelf == false)
        {
            Managers.Resource.Destroy(this);
            return;
        }
        // transform.rotation = Quaternion.Inverse(_parentObject.transform.rotation);
        transform.position = _parentObject.transform.position + _offset;
  
    }
}
