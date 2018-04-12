using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ViewState
{
    SetLock,
    Unlock,
    List,
    Add,
    Settings,
}

public class UIManager : MonoBehaviour {

    [SerializeField] UISetLock _setlockView;
    [SerializeField] UIUnlock _unlockView;
    [SerializeField] UIAddAccount _addView;
    [SerializeField] UIAccountList _mainView;
    [SerializeField] UISettings _settingsView;


    private void Awake()
    {
        DataManager.CreateInstance();

        _settingsView.OnClearDataCallback += ShowMainView;
        _settingsView.OnSetlockPassCallback += ShowSetlockView;
        _addView.OnAddCallback += ShowMainView;
        _unlockView.OnUnlockCallback += ShowMainView;
        _setlockView.OnSetlockCallback += ShowUnlockView;
        _mainView.OnEditAccountCallback += ShowEditView;
    }

    private void Start()
    {
        ShowUnlockView();
    }

    private void OnDestroy()
    {
        _settingsView.OnClearDataCallback -= ShowMainView;
        _settingsView.OnSetlockPassCallback -= ShowSetlockView;
        _setlockView.OnSetlockCallback -= ShowUnlockView;
        _unlockView.OnUnlockCallback -= ShowMainView;
        _addView.OnAddCallback -= ShowMainView;
        _mainView.OnEditAccountCallback -= ShowEditView;
        DataManager.DestroyInstance();
    }

    private void Show(ViewState st, AccountInfo info = null)
    {
        _mainView.Hide();
        _unlockView.Hide();
        _addView.Hide();
        _setlockView.Hide();
        _settingsView.Hide();

        switch (st)
        {
            case ViewState.Add:
                _addView.Show(info);
                break;
            case ViewState.List:
                _mainView.Show();
                break;
            case ViewState.Unlock:
                _unlockView.Show();
                break;

            case ViewState.SetLock:
                _setlockView.Show();
                break;

            case ViewState.Settings:
                _settingsView.Show();
                break;
        }
    }

    void ShowEditView(AccountInfo info)
    {
        Show(ViewState.Add, info);
    }


    public void ShowUnlockView()
    {
        Show(ViewState.Unlock);
    }

    public void ShowAddView()
    {
        Show(ViewState.Add);
    }

    public void ShowMainView()
    {
        Show(ViewState.List);
    }

    public void ShowSetlockView()
    {
        Show(ViewState.SetLock);
    }

    public void ShowSettingsView()
    {
        Show(ViewState.Settings);
    }
}
