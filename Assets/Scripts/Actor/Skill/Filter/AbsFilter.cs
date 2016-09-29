using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AbsFilter {

    protected int mLayerMask = 0;
    protected string mKey;
    protected int mCount = 0; //限制人数
    protected ESelectType mSelectType = ESelectType.Enemy;

    protected List<Actor> mDestChars = new List<Actor>(); //目标集合

    public string Key
    {
        get { return mKey; }
        set { mKey = value; }
    }

    public virtual void Filter(PkMsg _msg) { }
    public virtual AbsFilter Clone() { return null; }
    public virtual void Parser(ref List<string> _params) {} //解析数据
    public virtual void DebugDraw() { }

}
