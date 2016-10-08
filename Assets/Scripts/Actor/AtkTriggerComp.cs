using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MecanimComp))]

public class AtkTriggerComp : MonoBehaviour
{
    [HideInInspector]
    public bool isCasting = false;
    private float nextFire = 0.0f;
    public float attackSpeed = 0.15f;
    public float atkDelay1 = 0.1f;
    public float skillDelay = 0.3f;

    private int c = 0;
    private int conCombo = 0;

    public AnimationClip[] attackCombo = new AnimationClip[3];
    public float attackAnimationSpeed = 1.0f;
    public AnimationClip[] skillAnimation = new AnimationClip[3];
    public float skillAnimationSpeed = 1.0f;

    public void Update()
    {
        //Normal Trigger
        if (Input.GetButton("Fire1") && Time.time > nextFire && !isCasting)
        {
            if (Time.time > (nextFire + 0.5f))
            { //如果超过下一段攻击时间（nextFire + 0.5f），则重新开始第一段攻击计 c = 0
                c = 0;
            }
            //Attack Combo
            if (attackCombo.Length >= 1)
            {
                conCombo++;
                //AttackCombo();
                Debug.LogFormat("--- conCombo+1:{0}, nextFire:{1}", conCombo, nextFire);
                StartCoroutine(AttackCombo());

            }
        }
    }

    /// <summary>
    /// 组合攻击
    /// </summary>
    /// <returns></returns>
    IEnumerator AttackCombo()
    {
        yield return new WaitForSeconds(0.1f);

    }
}
