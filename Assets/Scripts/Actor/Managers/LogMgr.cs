using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LogMgr : BaseMgr
{
    [SerializeField]
    static ELevel Log_Level = ELevel.Debug2;

    private enum ELevel
    {
        Debug2 = 0,
        Info,
        Warn,
        Error,
        Fatal,
    }

    private static void Echo(ELevel _lv, params object[] _params)
    {

        if (_lv < Log_Level)
            return;

        if (_params.Length > 0)
        {
            ArrayList tmpArr = new ArrayList(_params);
            string format = tmpArr[0].ToString();
            tmpArr.RemoveAt(0);
            Debug.LogFormat(format, tmpArr);
        }
    }

    public static void Fatal(params object[] _params)
    {
        Echo(ELevel.Fatal, _params);
    }

    public static void Error(params object[] _params)
    {
        Echo(ELevel.Error, _params);
    }

    public static void Warn(params object[] _params)
    {
        Echo(ELevel.Warn, _params);
    }

    public static void Info(params object[] _params)
    {
        Echo(ELevel.Info, _params);
    }

    public static void Debug2(params object[] _params)
    {
        Echo(ELevel.Debug2, _params);
    }
}
