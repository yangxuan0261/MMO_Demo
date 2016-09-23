using UnityEngine;
using System.Collections;

public enum ESkillType
{
    Normal = 0,
    Initiative, //主动
    Passive_A,
    Passive_B,
    Passive_C,
    Passive_Permanent,
    Count,
}

public enum EAnimType //动作动画
{
    None = 0,
    Skill_1,
    Skill_2,
    Skill_3,
    Skill_4,
    Skill_5,
    Skill_6,
    Skill_7,
    Injure_1,
    Injure_2,
    Victory_1,
    Victory_2,
    Victory_3,
    Count,
};

public enum ELockedType  //锁定类型
{
    Loc = 0,	//地点
	Char,		//人
	Count,
};