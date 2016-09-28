using UnityEngine;
using System.Collections;

public class GameMgr : BaseMgr
{

    public static string gNodeName = "GameMgrNode";
    private static GameObject gGameObj = null;
    private static GameMgr gGameMgr = null;

    public SkillMgr mSkillMgr;
    public BuffMgr mBuffMgr;

    /// <summary>
    /// 游戏开始时实例宿主对象gameobject，全局唯一，切场景不被销毁
    /// </summary>
    public static void Init()
    {
        //GameObject obj = Resources.Load("Prefabs/GameMgrNode") as GameObject;
        //obj = Instantiate(obj);

    }

    public static GameObject Obj
    {
        get { return gGameObj; }
    }

    public static GameMgr Ins
    {
        get { return gGameMgr; }
    }

    public override void Awake()
    {
        base.Awake();
        gameObject.name = gNodeName;
        DontDestroyOnLoad(gameObject);

        gGameObj = gameObject;
        gGameMgr = this;

        InitMgrs();
    }

    public void InitMgrs()
    {
        mSkillMgr = gameObject.AddComponent<SkillMgr>();
        mBuffMgr = gameObject.AddComponent<BuffMgr>();
    }

    public void Start()
    {
        Debug.Log("--- GameMgr.Start");
    }

    /// <summary>
    /// 可能要求清除顺序
    /// </summary>
    public override void Clear()
    {
        //BaseMgr[] comps = gameObject.GetComponents<BaseMgr>();
        //for (int i = 0; i < comps.Length; ++i)
        //{
        //    if (!(comps[i] is GameMgr)) //跳过自己，最后请自己
        //    {
        //        comps[i].Clear();
        //    }
        //}
        base.Clear();
    }

    public void Quit()
    {
        Debug.Log("--- GameMgr.Quit");
        Clear();

        DestroyObject(gGameObj);
    }
}
