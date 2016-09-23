using UnityEngine;
using System.Collections;

public class SkillTpl : MonoBehaviour {

    #region member
    public int mId = 0;
    public string mName = "";
    public string mDescr = "";
    public int mAtkDist = 5;
    public ESkillType mSkillType = ESkillType.Normal;
    public EAnimType mAnimType;
    public int mBehavId; //技能文件id
    public BulletTpl mBulletTpl;
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
}
