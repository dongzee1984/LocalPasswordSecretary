using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISetLock : UIView
{

    public event System.Action OnSetlockCallback;

    [SerializeField] InputField _inputOldPassword;

    [SerializeField] InputField _inputNewPassword;

    [SerializeField] Text _tip;


    private void OnEnable()
    {
        _tip.gameObject.SetActive(false);
    }

    public void SaveLockPass()
    {
        if (DataManager.GetInstance().CheckLock(_inputOldPassword.text))
        {

            DataManager.GetInstance().SetLock(_inputNewPassword.text);

            if (OnSetlockCallback != null)
                OnSetlockCallback();
        }
        else
        {
            _tip.gameObject.SetActive(true);
        }
    }

}
