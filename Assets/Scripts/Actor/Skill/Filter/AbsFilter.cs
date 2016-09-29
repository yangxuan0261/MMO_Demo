using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AbsFilter {

    protected string mKey;
    protected int mCount; //限制人数
    ESelectType mSelectType;
    protected List<GameObject> mDestChars = new List<GameObject>(); //目标集合

    public string Key
    {
        get { return mKey; }
        set { mKey = value; }
    }

    public virtual void Filter(PkMsg _msg) { }
    public virtual AbsFilter Clone() { return null; }
    public virtual void Parser(List<string> _params) {} //解析数据
    public virtual void DebugDraw() { }

}
