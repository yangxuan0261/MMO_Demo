using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class SkillMgr : BaseMgr
{
    private Dictionary<int, SkillTpl> mSkillTplDict = new Dictionary<int, SkillTpl>();

    private static SkillMgr mInstance = null;
    public static SkillMgr Instance
    {
        get { return mInstance; }
    }

    public override void Awake()
    {
        base.Awake();
        mInstance = this;
    }

    public SkillTpl GetSkillTpl(int _skillId)
    {
        SkillTpl tpl = null;
        mSkillTplDict.TryGetValue(_skillId, out tpl);
        return tpl;
    }


    public void LoadSkillTpl()
    {

    }
}
