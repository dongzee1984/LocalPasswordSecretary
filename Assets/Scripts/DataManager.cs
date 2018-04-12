using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class AccountInfo
{
    public string plat;
    public string user;
    public string password;

    public override string ToString()
    {
        return plat+","+user+","+password;
    }
}

public class DataManager : SingletonTeamplate<DataManager>, ISingletonTeamplate
{
    private List<AccountInfo> _data;

    const string _KEY_ = "alldata";
    const string _UNLOCK_KEY_ = "_UNLOCK_";

    public List<AccountInfo> data
    {
        get
        {
            return _data;
        }
    }

    public void Delete(AccountInfo info)
    {
        data.Remove(info);
    }

    public void Save(AccountInfo info)
    {
        _data.Add(info);
        Save(data);
    }

    public override void Initialize()
    {
        base.Initialize();

        _data = Load();
    }

    public bool CheckLock(string pwd)
    {
        var s = PlayerPrefs.GetString(_UNLOCK_KEY_);
        return s == pwd;
    }

    public void SetLock(string pwd)
    {
        PlayerPrefs.SetString(_UNLOCK_KEY_, pwd);
        PlayerPrefs.Save();
    }

    public void Clear()
    {
        PlayerPrefs.DeleteKey(_KEY_);
        PlayerPrefs.Save();
    }

    public void Save(List<AccountInfo> list)
    {
        var _sb = new StringBuilder();
        foreach (var item in list)
        {
            _sb.AppendFormat("{0};", item.ToString());
        }
        PlayerPrefs.SetString(_KEY_, _sb.ToString());
        PlayerPrefs.Save();
    }

    public List<AccountInfo> Load()
    {
        var s = PlayerPrefs.GetString(_KEY_);

        var result = new List<AccountInfo>();

        if (string.IsNullOrEmpty(s))
        {
            return result;
        }

        var list = s.Split(";".ToCharArray());
        foreach(var item in list)
        {
            if (string.IsNullOrEmpty(item))
                continue;

            var list2 = item.Split(",".ToCharArray());
            if (list2.Length != 3)
                continue;

            result.Add(new AccountInfo() {
                plat = list2[0],
                user = list2[1],
                password = list2[2]
            });
        }

        return result;
    }
}
