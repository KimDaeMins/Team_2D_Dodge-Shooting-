using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Monster_Hp : MonoBehaviour
{
    public int MaxBar { get; set; }
    RectTransform _rectTransform;
    public GameObject _parentObject;
    public Vector3 _offset;
    bool firstUpdate = false;
    bool secondUpdate = false;
    bool thirdpdate = false;
    // Start is called before the first frame update
    void Start()
    {
        _rectTransform = transform.GetChild(1).GetComponent<RectTransform>();
    }
    private void OnEnable()
    {
        firstUpdate = false;
        secondUpdate = false;
        thirdpdate = false;
        //SetHpBar(MaxBar);
    }
    private void OnDisable()
    {
        Vector2 localScale = _rectTransform.localScale;
        localScale.x = 1;
        _rectTransform.localScale = localScale;
        gameObject.SetActive(false);
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
        if (_parentObject.activeSelf == false)
            gameObject.SetActive(false);
        // transform.rotation = Quaternion.Inverse(_parentObject.transform.rotation);
        if (thirdpdate)
            transform.position = _parentObject.transform.position + _offset;
        else
        {
            if (secondUpdate)
                thirdpdate = true;
            if(firstUpdate)
                secondUpdate = true;
            transform.position = new Vector3(1000 , 1000 , 0);
            firstUpdate = true;
        }
    }
}
