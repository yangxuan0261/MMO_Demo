using UnityEngine;
using System.Collections;

public class CoolDownTimer : MonoBehaviour
{
    public delegate void CDFinishDlg(CoolDownTimer _dlg);
    public event CDFinishDlg dlgHandler;

    #region member
    int mSkillId = 0;
    float mCDTime = 1.0f;//cd时间
    float mTimer = 0.0f;//cd计时
    float mRatio = 1.0f;//比例，用于加快cd
    bool mIsOK = true;//
    SkillTpl mSkillTpl = null;
    //USkillFunction* mSkillFunc;
    //FCDFinishDlg mCDFinishDlg;//通知代理
    #endregion

    public bool IsOk
    {
        get { return mIsOK; }
    }

    public SkillTpl skillTpl
    {
        get { return mSkillTpl; }
        set {
            mSkillTpl = value;
        }
    }

    public void FixedUpdate()
    {
        if (!mIsOK)
        {
            mTimer += Time.fixedDeltaTime * mRatio;
            if (mTimer >= mCDTime)
            {
                mTimer = mCDTime;
                mIsOK = true;
                dlgHandler(this); //cd完通知char，可以释放技能了
            }
        }
        else
            mTimer = mCDTime;
    }

    public void Restart()
    {
        mTimer = 0.0f;
        mIsOK = false;
    }
}
