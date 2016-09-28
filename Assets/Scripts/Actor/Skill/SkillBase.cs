using UnityEngine;
using System.Collections;

public class SkillBase {

    private SkillTpl mSkillTpl = null;
    private CDTimer mCDTimer = null;
    private int mSkillId;

    public int SkillId
    {
        get { return mSkillId; }
    }

    public SkillTpl Tpl
    {
        get { return mSkillTpl; }
        set
        {
            mSkillTpl = value;
            mSkillId = mSkillTpl.mId;
        }
    }

    public CDTimer Timer
    {
        get { return mCDTimer; }
        set { mCDTimer = value; }
    }

}
