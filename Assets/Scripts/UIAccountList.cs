using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAccountList : UIView
{
    public event System.Action<AccountInfo> OnEditAccountCallback;

    [SerializeField] RectTransform _listRoot;
    [SerializeField] ScrollRect _scroll;

    const string ItemPrefabPath = "AccountItem";

    float _height;

    // Use this for initialization
    public override void Show()
    {
        for (int i = _scroll.content.transform.childCount - 1; i >= 0; --i)
            Destroy(_scroll.content.transform.GetChild(i).gameObject);

        var data = DataManager.GetInstance().data;

        foreach(var o in data)
        {
            var go = Create(_listRoot, ItemPrefabPath);
            var item = go.GetComponent<UIAccountItem>();
            item.SetData(o, OnSelectItem);
        }
        base.Show();
    }

    void OnSelectItem(AccountInfo info)
    {
        if (OnEditAccountCallback != null)
            OnEditAccountCallback(info);
    }

    // Update is called once per frame
    void Update () {

        ResetPos();

    }

    void ResetPos()
    {
        if(_height != _scroll.content.rect.height)
        {
            var pos = _scroll.content.localPosition;
            pos.y = 0 - _scroll.content.rect.height * 0.5f;
            _scroll.content.localPosition = pos;

            _height = _scroll.content.rect.height;
        }
    }

    GameObject Create(RectTransform parent, string prefabPath)
    {
        var go = GameObject.Instantiate(Resources.Load(prefabPath)) as GameObject;
        go.transform.SetParent(parent);
        return go;
    }
}
