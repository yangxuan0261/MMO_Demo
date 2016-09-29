using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FuncsMgr : BaseMgr
{
    private static FuncsMgr mInstance = null;
    public static FuncsMgr Ins
    {
        get { return mInstance; }
    }

    #region define attribute && filter string 
    [SerializeField]
    string Filter_Circle = "circle";
    [SerializeField]
    string Func_AttackPhy = "phyattack";
    #endregion

    private Dictionary<string, AbsFilter> mFilterList = new Dictionary<string, AbsFilter>();
    private Dictionary<string, AbsFunc> mFuncList = new Dictionary<string, AbsFunc>();



    public override void Awake()
    {
        base.Awake();
        mInstance = this;
        InitFiltersAndFuncs();
    }

    /// <summary>
    /// 初始化各种模板
    /// </summary>
    public void InitFiltersAndFuncs()
    {
        #region RegisterFilter
        RegisterFilter(SphereFilter.CreateFilter(Filter_Circle));

        #endregion

        #region RegisterFunction
        RegisterFunction(AttackPhy.CreateFunc(Func_AttackPhy));

        #endregion
    }

    /// <summary>
    /// 注册Function
    /// </summary>
    /// <param name="_object"></param>
    public void RegisterFunction(AbsFunc _abs)
    {
        string key = _abs.Key;
        if (!mFuncList.ContainsKey(key))
            mFuncList.Add(key, _abs);
    }

    /// <summary>
    /// 注册选人
    /// </summary>
    /// <param name="_abs"></param>
    public void RegisterFilter(AbsFilter _abs)
    {
        string key = _abs.Key;
        if (!mFilterList.ContainsKey(key))
            mFilterList.Add(key, _abs);
    }

    public AbsFilter CreateFilter(string _str)
    {
        string str = _str.ToLower();
        string[] strArr = str.Split(DefineMgr.Split_Line.ToCharArray());
        if (strArr.Length > 0)
        {
            List<string> paramArr = new List<string>(strArr);
            string clsName = paramArr[0];
            AbsFilter filter = null;
            mFilterList.TryGetValue(clsName, out filter);
            if (filter == null)
            {
                LogMgr.Error("--- Not found Filter clsName:{0}", clsName);
                return null;
            }

            paramArr.RemoveAt(0);
            AbsFilter ret = filter.Clone();
            ret.Parser(ref paramArr);
            return ret;
        }
        return null;
    }

    public AbsFunc CreateFunction(string _str)
    {
        string str = _str.ToLower();
        string[] strArr = str.Split(DefineMgr.Split_Line.ToCharArray());
        if (strArr.Length > 0)
        {
            List<string> paramArr = new List<string>(strArr);
            string clsName = paramArr[0];
            AbsFunc func = null;
            mFuncList.TryGetValue(clsName, out func);
            if (func == null)
            {
                LogMgr.Error("--- Not found Func clsName:{0}", clsName);
                return null;
            }

            paramArr.RemoveAt(0);
            AbsFunc ret = func.Clone();
            ret.Parser(ref paramArr);
            return ret;
        }
        return null;
    }
}
