﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SphereFilter : AbsFilter
{
    public override void Filter(PkMsg _msg)
    {
        base.Filter(_msg);
    }

    public static SphereFilter CreateFilter(string _key)
    {

        return null;
    }

    public override void Parser(ref List<string> _params)
    {

    }
}
