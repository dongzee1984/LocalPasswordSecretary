using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAddAccount : UIView
{

    public event System.Action OnAddCallback;

    [SerializeField] InputField _inputPlat;
    [SerializeField] InputField _inputUser;
    [SerializeField] InputField _inputPassword;

    [SerializeField] Text _tip;

    // old info
    private AccountInfo _oldInfo;

    public void Show(AccountInfo info)
    {
        _oldInfo = info;

        if(info!=null)
        {
            _inputPlat.text = info.plat;
            _inputUser.text = info.user;
            _inputPassword.text = info.password;
        }
        else
        {
            _inputPlat.text = null;
            _inputUser.text = null;
            _inputPassword.text = null;
        }

        _tip.gameObject.SetActive(false);


        base.Show();
    }

    private bool Check()
    {
        if(string.IsNullOrEmpty(_inputPlat.text))
        {
            _tip.text = "平台名不能为空";
            return false;
        }

        if (string.IsNullOrEmpty(_inputUser.text))
        {
            _tip.text = "用户名不能为空";
            return false;
        }

        if (string.IsNullOrEmpty(_inputPassword.text))
        {
            _tip.text = "密码不能为空";
            return false;
        }

        return true;
    }

    public void Save()
    {
        if (Check() == false)
        {
            _tip.gameObject.SetActive(true);
            return;
        }
            

        if (_oldInfo != null)
        {
            DataManager.GetInstance().Delete(_oldInfo);
            _oldInfo = null;
        }

        AccountInfo info = new AccountInfo();
        info.plat = _inputPlat.text;
        info.user = _inputUser.text;
        info.password = _inputPassword.text;

        DataManager.GetInstance().Save(info);

        if (OnAddCallback != null)
            OnAddCallback();
    }
}
