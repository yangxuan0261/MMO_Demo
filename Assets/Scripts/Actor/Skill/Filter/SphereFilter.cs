using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SphereFilter : AbsFilter
{
    private int mRadius = 0; //选人半径

    public override void Filter(PkMsg _msg)
    {
        base.Filter(_msg);
    }

    public static SphereFilter CreateFilter(string _key)
    {
        SphereFilter filter = new SphereFilter();
        filter.Key = _key;
        return filter;
    }

    public override void Parser(ref List<string> _params)
    {
        if (_params.Count == 3)
        {
            mSelectType = (ESelectType) int.Parse(_params[0]);
            mCount = int.Parse(_params[1]);
            mRadius = int.Parse(_params[2]);
        }
        else
            LogMgr.Error("--- SphereFilter Error");
    }

    public override AbsFilter Clone()
    {
        return CreateFilter(mKey);
    }
}
