using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class DrawComp : NetworkBehaviour
{
    private float mRadius = 0.0f;
    private Vector3 mBox = Vector3.zero;
    private Color mColor = Color.yellow;

    public void Awake()
    {
        //m秒后自动销毁
        Destroy(gameObject, DefineMgr.DrawTime);
    }

    public void SetRadius(float _radius)
    {
        mRadius = _radius;
    }

    public void SetColor(Color _color)
    {
        mColor = _color;
    }

    public void SetBox(Vector3 _box)
    {
        mBox = _box;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = mColor;
        if (mRadius > 0.0f)
            Gizmos.DrawWireSphere(transform.position, mRadius);

        if (mBox != Vector3.zero)
            Gizmos.DrawWireCube(transform.position, mBox);
    }
}
