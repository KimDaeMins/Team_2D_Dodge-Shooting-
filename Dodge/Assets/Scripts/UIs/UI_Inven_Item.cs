using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inven_Item : UI_Base
{
    Image _image;
    RectTransform _rectTransform;
    bool _firstUpdate;
    bool _secondUpdate;
    // Start is called before the first frame update
    void Start()
    {
    }

    public override void Init()
    {
        _image = transform.GetChild(0).GetComponent<Image>();
        _rectTransform = GetComponent<RectTransform>();
        _rectTransform.sizeDelta = new Vector2(_rectTransform.sizeDelta.y, _rectTransform.sizeDelta.y);
    }

    public void SetSprite(Sprite sprite)
    {
        _image.sprite = sprite;
    }
    public void ItemUpdate(bool b)
    {
        _image.color = b ? Color.white : Color.black;
    }
    // Update is called once per frame
    void Update()
    {
        if(!_secondUpdate)
        {
            Color color = _image.color;
            if (!_firstUpdate)
            {
                _firstUpdate = true;
                color.a = 0;
                _image.color = color;
                return;
            }
            _secondUpdate = true;
            _rectTransform.sizeDelta = new Vector2(_rectTransform.sizeDelta.y , _rectTransform.sizeDelta.y);
            color.a = 1;
            _image.color = color;
        }
    }
}
