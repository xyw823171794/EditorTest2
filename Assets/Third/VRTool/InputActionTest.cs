using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class InputActionTest : MonoBehaviour
{
    public MyVRController inputActions;
    private void Awake()
    { 
        inputActions = new MyVRController();
    }
    // Start is called before the first frame update
    void Start()
    {
        inputActions.MyXRLeftHand.Menu_Y.performed += OnLeftMenuDown;
        inputActions.MyXRRightHand.Menu_B.performed += OnRightMenuDown;
        inputActions.MyXRLeftHand.Pad_X.performed += OnLeftPadDown;
        inputActions.MyXRRightHand.Pad_A.performed += OnRightPadDown;
        inputActions.MyXRLeftHand.Aixs.performed += OnLeftAixs;
        inputActions.MyXRRightHand.Aixs.performed += OnRightAixs;
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    public void OnRightMenuDown(CallbackContext callback)
    {
        Debug.Log("按下右手柄菜单键/A键");
    }
    public void OnLeftMenuDown(CallbackContext callback)
    {
        Debug.Log("按下左手柄菜单键/X键");
    }

    public void OnRightPadDown(CallbackContext callback)
    {
        Debug.Log("按下右手柄Pad键");
    }
    public void OnLeftPadDown(CallbackContext callback)
    {
        Debug.Log("按下左手手柄Pad键");
    }

    public void OnRightAixs(CallbackContext callback)
    {
        Debug.Log("RightAixs = " + callback.ReadValue<Vector2>());
    }
    public void OnLeftAixs(CallbackContext callback)
    {
        Debug.Log("LeftAixs = " + callback.ReadValue<Vector2>());
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
