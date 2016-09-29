using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SphereFilter : AbsFilter
{
    private float mRadius = 0.0f; //选人半径

    public override void Filter(PkMsg _msg)
    {
        //base.Filter(_msg);

        GameObject target =  _msg.Target;
        Vector3 targetLoc = Vector3.zero;
        Quaternion quat = Quaternion.identity;
        if (target != null)
        {
            targetLoc = target.transform.position;
            quat = Quaternion.Euler(target.transform.eulerAngles);
        }
        else
            targetLoc = _msg.TargetLoc;

        if (targetLoc != Vector3.zero)
        {

            Collider[] hits = Physics.OverlapSphere(targetLoc, mRadius, mLayerMask); //指定层获取，减少不必要的遍历
            for (int i= 0; i< hits.Length; ++i)
            {
                Actor actor = hits[i].GetComponent<Actor>();


                if (mCount > 0)
                {
                    mDestChars.Add(actor);
                    mCount -= 1;
                }
                else if (mCount == -1)
                    mDestChars.Add(actor);
                else
                    break;
            }

            #region debug mode - display range
            if (DefineMgr.DrawFilter)
            {
                GameObject go = (GameObject) GameObject.Instantiate(DefineMgr.DrawNode, targetLoc, quat);
                DrawComp comp = go.AddComponent<DrawComp>();
                comp.SetRadius(mRadius);
                comp.SetColor(DefineMgr.DrawColor);

                for (int i = 0; i < mDestChars.Count; ++i)
                {
                    Debug.DrawLine(targetLoc, mDestChars[i].transform.position, DefineMgr.DrawColor, DefineMgr.DrawTime);
                }
            }
            #endregion
        }
    }

    public static SphereFilter CreateFilter(string _key)
    {
        SphereFilter filter = new SphereFilter();
        filter.Key = _key;
        return filter;
    }

    public override void Parser(ref List<string> _params)
    {
        if (_params.Count == 3)
        {
            mSelectType = (ESelectType) int.Parse(_params[0]);
            mCount = int.Parse(_params[1]);
            mRadius = int.Parse(_params[2]);
        }
        else
            LogMgr.Error("--- SphereFilter Error");
    }

    public override AbsFilter Clone()
    {
        return CreateFilter(mKey);
    }
}
