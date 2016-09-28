using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillComp : MonoBehaviour
{
    private Dictionary<int, SkillBase> mSkillList = new Dictionary<int, SkillBase>();

    public void Awake()
    {

    }

    public void AddSkill(int _skillId)
    {
        SkillTpl tpl = SkillMgr.Instance.GetSkillTpl(_skillId);
        if (tpl != null)
        {
            CDTimer timer = new CDTimer(tpl);
            timer.dlgHandler += OnCDOver;

            SkillBase skill = new SkillBase();
            skill.Timer = timer;
            skill.Tpl = tpl;
            mSkillList.Add(_skillId, skill);
        }
    }

    public void OnCDOver(CDTimer _timer)
    {

    }
}
