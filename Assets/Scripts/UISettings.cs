using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISettings : UIView {

    public event System.Action OnSetlockPassCallback;
    public event System.Action OnClearDataCallback;


    public void SetlockPass()
    {
        if (OnSetlockPassCallback != null)
            OnSetlockPassCallback();
    }

    public void Clear()
    {
        DataManager.GetInstance().Clear();
        if (OnClearDataCallback != null)
            OnClearDataCallback();
    }
}
