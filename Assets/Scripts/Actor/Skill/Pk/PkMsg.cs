using UnityEngine;
using System;
using System.Collections.Generic;

public class PkMsg
{
    int mSkillId = 0;
    Vector3 mTargetLoc = Vector3.zero;
    GameObject mTargetLocked = null;
    GameObject mAttacker = null;

    public GameObject Target
    {
        get { return mTargetLocked;}
    }

    public GameObject Attacker
    {
        get { return mAttacker; }
    }

    public Vector3 TargetLoc
    {
        get { return mTargetLoc; }
    }


}
