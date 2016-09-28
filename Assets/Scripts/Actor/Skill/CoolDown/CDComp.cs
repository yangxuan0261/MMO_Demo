using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CDComp : MonoBehaviour
{
    private List<CDTimer> mCDList = new List<CDTimer>();

    public void Awake()
    {

    }

    public void FixedUpdate()
    {
        CDTimer cdTimer = null;
        for (int i = 0;i < mCDList.Count; ++i)
        {
            cdTimer = mCDList[i];
            if (!cdTimer.IsOk)
                cdTimer.FixedUpdate();
        }
    }

    public void AddCD(int _skillId, bool _restartCD)
    {

    }

}
