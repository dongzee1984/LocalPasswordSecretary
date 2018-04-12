using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAccountItem : MonoBehaviour
{

    [SerializeField] Text _plat;
    [SerializeField] Text _username;

    private AccountInfo _data;
    private System.Action<AccountInfo> _onSelected;

    public void OnSelected()
    {
        if (_onSelected != null)
            _onSelected(_data);
    }

    public void SetData(AccountInfo data, System.Action<AccountInfo> onSelected)
    {
        _data = data;

        _onSelected = onSelected;

        UpdateUI();
    }

    private void UpdateUI()
    {
        if (_data == null)
            return;

        _plat.text = _data.plat;
        _username.text = _data.user;
    }
}
