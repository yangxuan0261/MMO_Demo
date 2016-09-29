using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillTpl : MonoBehaviour
{

    #region member
    public int mId = 0;
    public string mName = "";
    public string mDescr = "";
    public int mAtkDist = 5;
    public ESkillType mSkillType = ESkillType.Normal;
    public EAnimType mAnimType;
    public int mBehavId; //技能文件id
    public BulletTpl mBulletTpl;
    public float mCDTime;
    #endregion

    #region 属性字符串
    public string mFilterStr = "";
    public string mBeforeSkillStr = "";
    public string mBeforePkStr = "";
    public string mBeforeEvnsStr = "";
    public string mEndEvnsStr = "";
    public string mEndPkStr = "";
    public string mEndSkillStr = "";
    #endregion

    #region 各种skill的列表
    public List<AbsFunc> mBeforeSkill = new List<AbsFunc>();
    public List<AbsFunc> mBeforePk = new List<AbsFunc>();
    public List<AbsFunc> mBeforeEvns = new List<AbsFunc>();
    public List<AbsFunc> mEndEvns = new List<AbsFunc>();
    public List<AbsFunc> mEndPk = new List<AbsFunc>();
    public List<AbsFunc> mEndSkill = new List<AbsFunc>();
    public AbsFilter mFilter = null;
    #endregion

    #region 各种skill的get
    public List<AbsFunc> BeforeSkill
    {
        get
        {
            if (mBeforeSkill.Count == 0 && mBeforePkStr.Length > 0)
                ParseFuncStr(ref mBeforePkStr, ref mBeforeSkill);
            return mBeforeSkill;
        }
    }

    public List<AbsFunc> BeforePk
    {
        get
        {
            if (mBeforePk.Count == 0 && mBeforePkStr.Length > 0)
                ParseFuncStr(ref mBeforePkStr, ref mBeforePk);
            return mBeforePk;
        }
    }

    public List<AbsFunc> BeforeEvns
    {
        get
        {
            if (mBeforeEvns.Count == 0 && mBeforeEvnsStr.Length > 0)
                ParseFuncStr(ref mBeforeEvnsStr, ref mBeforeEvns);
            return mBeforeEvns;
        }
    }

    public List<AbsFunc> EndEvns
    {
        get
        {
            if (mEndEvns.Count == 0 && mEndEvnsStr.Length > 0)
                ParseFuncStr(ref mEndEvnsStr, ref mEndEvns);
            return mEndEvns;
        }
    }

    public List<AbsFunc> EndPk
    {
        get
        {
            if (mEndPk.Count == 0 && mEndPkStr.Length > 0)
                ParseFuncStr(ref mEndPkStr, ref mEndPk);
            return mEndPk;
        }
    }

    public List<AbsFunc> EndSkill
    {
        get
        {
            if (mEndSkill.Count == 0 && mEndSkillStr.Length > 0)
                ParseFuncStr(ref mEndSkillStr, ref mEndSkill);
            return mEndSkill;
        }
    }
    #endregion

    public void ParseFuncStr(ref string _str, ref List<AbsFunc> _funcList)
    {
        string paramStr = _str.ToLower();
        string[] strArr = _str.Split(DefineMgr.Split_Sem.ToCharArray());
        for (int i = 0; i < strArr.Length; ++i)
        {
            AbsFunc func = FuncsMgr.Ins.CreateFunction(strArr[i]);
            if (func != null)
                _funcList.Add(func);
        }
    }

    public void ParseFilterStr(ref string _str)
    {
        mFilter = FuncsMgr.Ins.CreateFilter(_str);
    }

}
