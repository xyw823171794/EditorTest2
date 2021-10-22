using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

[DisallowMultipleComponent]//禁止一个游戏物体存在多个组件
public class MyVRToolManager : MonoBehaviour
{
    static MyVRToolManager _instance = null; 
    public MyVRToolManager Instance => _instance;

    public XRRig Rig => m_XRRig;

    private XRRig m_XRRig;

    public GameObject LeftHandObject;
    public GameObject RightHandObject;

    public HandInputActionManager LeftControllerManager { get; private set; }
    public HandInputActionManager RightControllerManager { get; private set; }


    public Transform CameraOffset { get; private set; }

    public Camera Eye { get; private set; }
     
    /// <summary>
    /// 黑屏遮罩                                                                                                                                                                                                                      vb                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  
    /// </summary>
    private Renderer maskRender;
    private Transform loadingUI;

    private MyVRController inputActions;

    public static Action onUpdate;
    /// <summary>
    /// 初始化完成事件
    /// </summary>
    public static Action onInitComplete;
     
    private void Awake()
    {
        _instance = this;
        inputActions = new MyVRController();
        m_XRRig = transform.GetComponent<XRRig>();
        CameraOffset = m_XRRig.transform.Find("CameraOffset");
        Eye = CameraOffset.GetComponentInChildren<Camera>();
        Transform blackMask = m_XRRig.cameraGameObject.transform.Find("BlackMask");
        maskRender = blackMask.GetComponent<Renderer>();
        loadingUI = blackMask.Find("loadingUI");

        #region 获取并初始化左右手的事件管理器
        LeftControllerManager = LeftHandObject.GetComponent<HandInputActionManager>();
        LeftControllerManager.Init(inputActions);
        RightControllerManager = RightHandObject.GetComponent<HandInputActionManager>();
        RightControllerManager.Init(inputActions);
        #endregion

        ToNight(0.001f);
    } 
    // Start is called before the first frame update
    void Start()
    {
        onInitComplete?.Invoke();
        ToDawn(0.3f);
    }
    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }
    public Tween SetMaskColor(Color endColor,float duration = 1)
    {
        Color color = maskRender.material.color;
        Tween tween = DOTween.To(()=>color,c=>color = c,endColor,duration);
        tween.SetEase(Ease.InCubic);
        tween.onUpdate += () => 
        {
            maskRender.material.color = color;
        };
        return tween;
    }
    /// <summary>
    /// 进入黑屏
    /// </summary>
    /// <param name="duration"></param>
    /// <returns></returns>
    public Tween ToNight(float duration = 1)
    {
        maskRender.gameObject.SetActive(true);
        return SetMaskColor(Color.black,duration);
    }
    /// <summary>
    /// 离开黑屏
    /// </summary>
    /// <param name="duration"></param>
    /// <returns></returns>
    public Tween ToDawn(float duration = 1)
    {
        Tween tween = SetMaskColor(Color.black * 0.3f,0.3f);

        tween.onComplete += () => 
        {
            maskRender.material.color = Color.clear;
            maskRender.gameObject.SetActive(false); 
        };

        Sequence sequence = DOTween.Sequence();
        sequence.Append(tween);
        sequence.PrependInterval(duration);

        return sequence;
    }
    public Tween AllDayAndNight(float duration = 1)
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(ToNight(duration * 0.5f));
        sequence.Append(ToDawn(duration * 0.5f));
        return sequence;
    }
    /// <summary>
    /// 设置头显位置和朝向
    /// </summary>
    /// <param name="target"></param>
    public void SetEyePositionAndRotation(Transform target)
    {
        Transform eye = Rig.cameraGameObject.transform;
        Vector3 rotateOffset = transform.eulerAngles - eye.eulerAngles;
        Vector3 dir = eye.position - transform.position;
        dir.y = 0;
        transform.position = target.position + dir;
        transform.rotation = Quaternion.Euler(0,target.eulerAngles.y - rotateOffset.y,0);
    }
    /// <summary>
    /// 限制头显高度（用于防止头超过地面）
    /// </summary>
    /// <param name="height"></param>
    public void ClampHeight(float height)
    {
        Transform cameraOffset = Rig.cameraFloorOffsetObject.transform.parent;
        Vector3 pos = cameraOffset.InverseTransformPoint(Eye.transform.position);
        float y = height - pos.y;
        cameraOffset.position = new Vector3(cameraOffset.position.x,y,cameraOffset.position.z);
    }
    /// <summary>
    /// 显示某只手
    /// </summary>
    /// <param name="isRight"></param>
    public void EnableHand(bool isRight)
    {
        if (isRight)
        {
            LeftHandObject.SetActive(true);
        }
        else
        {
            RightHandObject.SetActive(true);
        }
    }
    /// <summary>
    /// 隐藏某只手
    /// </summary>
    /// <param name="isRight"></param>
    public void DisableHand(bool isRight)
    {
        if (isRight)
        {
            LeftHandObject.SetActive(false);
        }
        else
        {
            RightHandObject.SetActive(false);
        }
    }
    /// <summary>
    /// 显示双手
    /// </summary>
    public void EnableAllHand()
    {
        LeftHandObject.SetActive(true);
        RightHandObject.SetActive(true);
    }
    /// <summary>
    /// 隐藏双手
    /// </summary>
    public void DisableAllHand()
    {
        LeftHandObject.SetActive(false);
        RightHandObject.SetActive(false);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
