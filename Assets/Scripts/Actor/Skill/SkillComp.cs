using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillComp : MonoBehaviour
{
    private Dictionary<int, SkillFunc> mSkillList = new Dictionary<int, SkillFunc>();

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

            SkillFunc skill = new SkillFunc();
            skill.Timer = timer;
            skill.Tpl = tpl;
            mSkillList.Add(_skillId, skill);
        }
    }

    public void FixedUpdate()
    {
        foreach (SkillFunc skill in mSkillList.Values)
        {
            skill.Timer.FixedUpdate();
        }
    }

    /// <summary>
    /// 技能cd完的通知
    /// </summary>
    /// <param name="_timer"></param>
    public void OnCDOver(CDTimer _timer)
    {

    }

    public void UseSkill(int _skillId, GameObject _go, Vector3 _loc)
    {
        SkillFunc skill = CanUse(_skillId);
        if (skill != null)
        {
            if (_go != null)
            {
                Actor ator = _go.GetComponent<Actor>();
                if (ator)
                {

                }
            }
            else
            {

            }

        }
    }

    /// <summary>
    /// 限制技能的cd，TODO: 还有就是buff
    /// </summary>
    /// <param name="_skillId"></param>
    /// <returns></returns>
    public SkillFunc CanUse(int _skillId)
    {
        SkillFunc skill = null;
        mSkillList.TryGetValue(_skillId, out skill);
        if (skill != null)
        {
            if (skill.Timer.IsOk)
                return skill;
        }
        return null;
    }
}
