using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AbsFunc
{
    protected string mKey;
    protected bool mIsPercent;

    public string Key
    {
        get { return mKey; }
        set { mKey = value; }
    }

    public virtual void Parser(List<string> _params) {} //解释数据
    public virtual AbsFunc Clone() { return null; }

    public virtual void RunBeforeSkill(PkMsg _msg) { }
    public virtual void RunBeforePk(PkMsg _msg) { }
    public virtual void RunBeforeEvns(PkMsg _msg) { }
    public virtual void RunEndEvns(PkMsg _msg) { }
    public virtual void RunEndPk(PkMsg _msg) { }
    public virtual void RunEndSkill(PkMsg _msg) { }
}
