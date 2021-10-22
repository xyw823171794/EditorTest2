using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 使一个物体始终显示在眼前的某个位置,1.画布Y轴垂直于地面，Z轴和视线在同一平面上2.
/// </summary>
[DisallowMultipleComponent]
public class InEyeFrontBase : MonoBehaviour
{ 
    /// <summary>
    /// UI基于眼睛的偏移
    /// </summary>
    public float Depth;
    /// <summary>
    /// 与视线的夹角
    /// </summary>
    public Vector2 Angle; 
    /// <summary>
    /// 垂直于视角
    /// </summary>
    public bool isLookAtEye; 
    /// <summary>
    /// 位置一直跟随摄像机
    /// </summary>
    public bool isFollwAtEye; 
    
    /// <summary>
    /// 缓动速度
    /// </summary>
    public float screamSpeed = 1.0f;
    /// <summary>
    /// 消失和显示速度
    /// </summary>
    private float deformationTime = 0.2f; 

    protected Vector3 newPostion;
    protected Quaternion newRotation;
    /// <summary>
    /// 眼镜的变换组件
    /// </summary>
    protected Transform eyeTrans; 
    /// <summary>
    /// 初始缩放
    /// </summary>
    protected Vector3 OrignScale;
    /// <summary>
    /// 是否显示
    /// </summary>
    public bool isEnable { get; protected set; }
    /// <summary>
    /// doTween返回值
    /// </summary>
    protected Tween tween;
    /// <summary>
    /// 显示隐藏调用列表
    /// </summary>
    private List<Action> actionList = new List<Action>();
    /// <summary>
    /// 地面高度
    /// </summary>
    public  float floorHeight; 
    protected virtual void Awake()
    {
        eyeTrans = Camera.main.transform;

        OrignScale = transform.localScale;

        Canvas canvas = transform.GetComponentInChildren<Canvas>();

        canvas.worldCamera = Camera.main;

        RectTransform canvasRect = canvas.transform as RectTransform;
        floorHeight += canvasRect.localScale.y * canvasRect.sizeDelta.y * 0.5f; 
    } 


    protected virtual void Start()
    { 
        Enable();
    }

    private void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(eyeTrans.position, newPostion);
        }
    }

    protected void LookAtEye()
    { 
        transform.rotation = newRotation;
        if (Quaternion.Angle(newRotation, transform.rotation) >= 20)
        {
            transform.rotation = newRotation;
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, screamSpeed * Time.deltaTime);
        }
    }

    protected void Follw()
    { 
        if (Vector3.Distance(newPostion, transform.position) >= 5)
        {
            transform.position = newPostion;
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, newPostion, screamSpeed * Time.deltaTime);
        }
    }
    /// <summary>
    /// 更新坐标与朝向
    /// </summary>
    protected void UpdateTargetTrans()
    { 
        Vector3 dir = Vector3.ProjectOnPlane(eyeTrans.forward, Vector3.up).normalized;//平行于地面的视线方向
        float radiansY = Angle.y * Mathf.Deg2Rad,radiansX = Angle.x * Mathf.Deg2Rad;

        Vector3 d = new Vector3(Mathf.Sin(radiansY), Mathf.Tan(radiansX), Mathf.Cos(radiansY));

        dir = Vector3.ProjectOnPlane(eyeTrans.TransformDirection(d), Vector3.up);

        dir = eyeTrans.TransformDirection(d);


        newRotation = Quaternion.LookRotation(dir, Vector3.up);

        newPostion = eyeTrans.position + dir * Depth;

        newPostion.y = Mathf.Max(floorHeight, newPostion.y);
    }

    public virtual void Enable( Action onEnableOver = null)
    {
        if (tween == null)
        { 
            UpdateTargetTrans();
            //
            transform.position = newPostion;
            transform.rotation = newRotation;

            tween = transform.DOScale(OrignScale, deformationTime);
            tween.onComplete += () =>
            {
                onEnableOver?.Invoke();
                isEnable = true;
                tween = null;
                if (actionList.Count > 0)
                {
                    actionList[0]?.Invoke();
                    actionList.RemoveAt(0);
                }
            };
        }
        else
        {
            actionList.Add(() =>
            {
                Enable(onEnableOver);
            }); 
        } 
    } 

    public virtual void Disable(Action onDisableOver = null)
    {
        if (tween == null)
        { 
            tween = transform.DOScale(Vector3.zero, deformationTime);
            tween.onComplete += () =>
            {  
                onDisableOver?.Invoke();
                isEnable = false; 
                tween = null;
                if (actionList.Count > 0)
                {
                    actionList[0]?.Invoke();
                    actionList.RemoveAt(0);
                }
            };
        }
        else
        { 
            actionList.Add(() =>
            {
                Disable(onDisableOver);
            }); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTargetTrans();
        if (isLookAtEye)
        {
            LookAtEye();
        }
        if (isFollwAtEye)
        {
            Follw();
        }
    } 
    protected virtual void OnDestroy()
    {
        tween.Kill();
    }
    protected virtual void LateUpdate()
    {
    } 
}

public enum InEyeFrontType
{  

}
