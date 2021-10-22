using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class HandInputActionManager : MonoBehaviour
{
    private MyVRController inputActions;

    public bool IsRight;

    public Action OnTriggerDown;
    public Action OnTriggerUp;

    public Action OnGripDown;
    public Action OnGripUp;

    public Action OnMenuDown;
    public Action OnMenuUp;

    public Action OnPadDown;
    public Action OnPadUp;

    public Action<Vector2> OnAixsChange;
     

    public void Init(MyVRController vrController)
    {
        inputActions = vrController;
        if (IsRight)
        {
            inputActions.MyXRRightHand.Trigger.started += Trigger_Started;
            inputActions.MyXRRightHand.Trigger.canceled += Trigger_Canceled;

            inputActions.MyXRRightHand.Grip.started += Grip_Started;
            inputActions.MyXRRightHand.Grip.canceled += Grip_Canceled;

            inputActions.MyXRRightHand.Menu_B.started += Menu_Started;
            inputActions.MyXRRightHand.Menu_B.canceled += Menu_Canceled;

            inputActions.MyXRRightHand.Pad_A.started += Pad_Started;
            inputActions.MyXRRightHand.Pad_A.canceled += Pad_Canceled;

            inputActions.MyXRRightHand.Aixs.performed += Aixs_Performed;
        }
        else
        {
            inputActions.MyXRLeftHand.Trigger.started += Trigger_Started;
            inputActions.MyXRLeftHand.Trigger.canceled += Trigger_Canceled;

            inputActions.MyXRLeftHand.Grip.started += Grip_Started;
            inputActions.MyXRLeftHand.Grip.canceled += Grip_Canceled;

            inputActions.MyXRLeftHand.Menu_Y.started += Menu_Started;
            inputActions.MyXRLeftHand.Menu_Y.canceled += Menu_Canceled;

            inputActions.MyXRLeftHand.Pad_X.started += Pad_Started;
            inputActions.MyXRLeftHand.Pad_X.canceled += Pad_Canceled;

            inputActions.MyXRLeftHand.Aixs.performed += Aixs_Performed;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Trigger_Started(CallbackContext context)
    {
        Debug.Log((IsRight?"右手":"左手")+ "扳机键" + "按下");
        OnTriggerDown?.Invoke();
    }

    void Trigger_Canceled(CallbackContext context)
    {
        Debug.Log((IsRight ? "右手" : "左手") + "扳机键" + "松开");
        OnTriggerUp?.Invoke();
    }

    void Grip_Started(CallbackContext context)
    {
        Debug.Log((IsRight ? "右手" : "左手") + "侧键" + "按下");
        OnGripDown?.Invoke();
    }

    void Grip_Canceled(CallbackContext context)
    {
        Debug.Log((IsRight ? "右手" : "左手") + "侧键" + "松开");
        OnGripUp?.Invoke();
    }

    void Menu_Started(CallbackContext context)
    {
        Debug.Log((IsRight ? "右手" : "左手") + "菜单键" + "按下");
        OnMenuDown?.Invoke();
    }
    void Menu_Canceled(CallbackContext context)
    {
        Debug.Log((IsRight ? "右手" : "左手") + "菜单键" + "松开");
        OnMenuUp?.Invoke();
    }
    void Pad_Started(CallbackContext context)
    {
        Debug.Log((IsRight ? "右手" : "左手") + "大饼键" + "按下");
        OnPadDown?.Invoke();
    }
    void Pad_Canceled(CallbackContext context)
    {
        Debug.Log((IsRight ? "右手" : "左手") + "大饼键" + "松开");
        OnPadUp?.Invoke();
    }

    void Aixs_Performed(CallbackContext context)
    {
        Vector2 aixs = context.ReadValue<Vector2>();
        Debug.Log("摇杆移动，Aixs = " + aixs);
        OnAixsChange?.Invoke(aixs);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
