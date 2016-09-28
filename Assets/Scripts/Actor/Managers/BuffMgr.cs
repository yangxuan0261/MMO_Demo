using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuffMgr : BaseMgr
{
    private Dictionary<int, BuffTpl> mBuffTplDict = new Dictionary<int, BuffTpl>();

    public BuffTpl GetBuffTpl(int _buffId)
    {
        BuffTpl tpl = null;
        mBuffTplDict.TryGetValue(_buffId, out tpl);
        return tpl;
    }

    public void LoadBuffTpl()
    {

    }
}
