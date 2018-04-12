using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUnlock : UIView
{
    public event System.Action OnUnlockCallback;

    [SerializeField] InputField _inputPassword;

    [SerializeField] Text _tip;

    private void OnEnable()
    {
        _tip.gameObject.SetActive(false);
    }

    public void Unlock()
    {
        if(DataManager.GetInstance().CheckLock(_inputPassword.text))
        {
            if (OnUnlockCallback != null)
                OnUnlockCallback();
        }
        else
        {
            _tip.gameObject.SetActive(true);
        }
    }

}
