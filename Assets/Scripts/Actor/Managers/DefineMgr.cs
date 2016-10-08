using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DefineMgr : BaseMgr
{
    #region split string
    public static string Split_Line = "_";
    public static string Split_Pound = "#";
    public static string Split_Sem = ";";
    #endregion

    #region debug draw - filter
    public static GameObject DrawNode = null;
    public static bool DrawFilter = true;
    public static Color DrawColor = Color.yellow;
    public static float DrawTime = 5.0f;
    #endregion
}
