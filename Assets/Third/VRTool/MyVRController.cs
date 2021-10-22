// GENERATED AUTOMATICALLY FROM 'Assets/Third/VRTool/MyVRController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MyVRController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MyVRController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MyVRController"",
    ""maps"": [
        {
            ""name"": ""MyXR HMD"",
            ""id"": ""9e96837b-2fc2-44fb-b4e2-b8c1066347c2"",
            ""actions"": [
                {
                    ""name"": ""Position"",
                    ""type"": ""Value"",
                    ""id"": ""3766bf25-7aae-4ab9-a3d7-f7f682965d0a"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotation"",
                    ""type"": ""Value"",
                    ""id"": ""f2eb9cb5-b00b-45c9-9e8d-9955ad6ea0e2"",
                    ""expectedControlType"": ""Quaternion"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a4edefa0-6bec-4b2f-851f-c702bf52cffe"",
                    ""path"": ""<XRHMD>/centerEyePosition"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""26a1437c-7f87-4603-99be-e9c742dfb45b"",
                    ""path"": ""<XRHMD>/centerEyeRotation"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MyXR LeftHand"",
            ""id"": ""6775864b-ce6b-4bc0-ac5d-bc2fef62c5a4"",
            ""actions"": [
                {
                    ""name"": ""Position"",
                    ""type"": ""Value"",
                    ""id"": ""0698f8a6-f4c5-4838-bf5a-713b333a10f6"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotation"",
                    ""type"": ""Value"",
                    ""id"": ""fe3aa166-33d6-4c6c-a84d-d25f033dcbd7"",
                    ""expectedControlType"": ""Quaternion"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Grip"",
                    ""type"": ""Button"",
                    ""id"": ""909c30df-88c4-4442-9745-3c2334e2009e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Trigger"",
                    ""type"": ""Button"",
                    ""id"": ""ab37ed6f-03c9-4674-8df2-5beaeed05af0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Menu_Y"",
                    ""type"": ""Button"",
                    ""id"": ""8f45b74d-f964-46ca-934b-a39835a883ef"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pad_X"",
                    ""type"": ""Button"",
                    ""id"": ""68043f78-4100-4de1-bdf2-3fe7f7e3b8fa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aixs"",
                    ""type"": ""Value"",
                    ""id"": ""c77d541d-1fc4-4083-aa29-201bd048e592"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Vector 3 Fallback"",
                    ""id"": ""d231da3e-e205-4214-9714-b01541721668"",
                    ""path"": ""Vector3Fallback"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Position"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""first"",
                    ""id"": ""d1c56aaa-8899-44c9-a89c-4793fe973f1c"",
                    ""path"": ""<XRController>{LeftHand}/pointerPosition"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR Controller"",
                    ""action"": ""Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""second"",
                    ""id"": ""a76332cf-2d7a-460b-9f75-5763ada4e280"",
                    ""path"": ""<XRController>{LeftHand}/devicePosition"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR Controller"",
                    ""action"": ""Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""third"",
                    ""id"": ""59249bb1-ca0b-4883-9d7e-1db7cd88bf2a"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR Controller"",
                    ""action"": ""Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Quaternion Fallback"",
                    ""id"": ""6edfac77-9159-4188-9881-389b7f64718b"",
                    ""path"": ""QuaternionFallback"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""first"",
                    ""id"": ""986e5078-d76e-46a8-9fc5-258c0c80101b"",
                    ""path"": ""<XRController>{LeftHand}/pointerRotation"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR Controller"",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""second"",
                    ""id"": ""26d8173a-b242-489f-ab03-373c56008751"",
                    ""path"": ""<XRController>{LeftHand}/deviceRotation"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR Controller"",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""third"",
                    ""id"": ""4f2004bb-d781-4129-835b-5a9d63d5337c"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR Controller"",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""cacfd104-6e2b-49d2-818a-2d98f9782458"",
                    ""path"": ""<XRController>{LeftHand}/gripPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR Controller"",
                    ""action"": ""Grip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e3afa89e-76bb-4855-9e0e-cf1efc31895f"",
                    ""path"": ""<XRController>{LeftHand}/triggerPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR Controller"",
                    ""action"": ""Trigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""89e6b667-e224-4d2a-9a57-3ff894bde237"",
                    ""path"": ""<XRController>{LeftHand}/primaryTouch"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR Controller"",
                    ""action"": ""Menu_Y"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""96718eb2-6507-4dc0-8431-dedeeb0ba473"",
                    ""path"": ""<XRController>{LeftHand}/primary2DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aixs"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e6862041-2911-4d66-b9aa-374605ff23df"",
                    ""path"": ""<XRController>{LeftHand}/secondaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR Controller"",
                    ""action"": ""Pad_X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MyXR RightHand"",
            ""id"": ""3c09449d-e1ca-412e-bafc-f679f9757985"",
            ""actions"": [
                {
                    ""name"": ""Position"",
                    ""type"": ""Value"",
                    ""id"": ""3ae7f8f8-817a-4166-88ba-407a1362dc38"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotation"",
                    ""type"": ""Value"",
                    ""id"": ""ecdbff9b-cf55-439e-a893-cf99f7127078"",
                    ""expectedControlType"": ""Quaternion"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Grip"",
                    ""type"": ""Button"",
                    ""id"": ""04f62dd7-d6a9-440d-a8ed-dc05355fe185"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Trigger"",
                    ""type"": ""Button"",
                    ""id"": ""2189a4d5-ce1e-4972-94eb-b4e7b3162c9f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Menu_B"",
                    ""type"": ""Button"",
                    ""id"": ""60847026-2a78-45cc-a750-4eee5dd0df2a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pad_A"",
                    ""type"": ""Button"",
                    ""id"": ""91e089d5-6ff9-4dfa-8d0f-d5b5e07efaa1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aixs"",
                    ""type"": ""Value"",
                    ""id"": ""30102579-b9c1-479c-970c-e892134c63e3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Vector 3 Fallback"",
                    ""id"": ""8ef57d8b-9aa1-415a-8d3b-5e02c6b30135"",
                    ""path"": ""Vector3Fallback"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR Controller"",
                    ""action"": ""Position"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""first"",
                    ""id"": ""06d7a53e-b48d-4083-9c87-e05dbcb5d835"",
                    ""path"": ""<XRController>{RightHand}/pointerPosition"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR Controller"",
                    ""action"": ""Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""second"",
                    ""id"": ""604e2aeb-332c-4f30-883a-2131fdbe27cf"",
                    ""path"": ""<XRController>{RightHand}/devicePosition"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR Controller"",
                    ""action"": ""Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""third"",
                    ""id"": ""549639ac-ced2-48df-8d6f-e218236319e7"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR Controller"",
                    ""action"": ""Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Quaternion Fallback"",
                    ""id"": ""de9cad57-4c77-4968-8137-26a9c48fcd16"",
                    ""path"": ""QuaternionFallback"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR Controller"",
                    ""action"": ""Rotation"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""first"",
                    ""id"": ""f00c685d-a287-46f0-af37-a7ba66ab1011"",
                    ""path"": ""<XRController>{RightHand}/pointerRotation"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR Controller"",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""second"",
                    ""id"": ""c28272ea-80aa-44b0-bb7c-68445a4bf311"",
                    ""path"": ""<XRController>{RightHand}/deviceRotation"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR Controller"",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""third"",
                    ""id"": ""fca754ba-d96e-4979-80e6-f8eec9a8b99a"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR Controller"",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""65e6bdba-d796-4e65-b586-59235b34d095"",
                    ""path"": ""<XRController>{RightHand}/gripPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR Controller"",
                    ""action"": ""Grip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c3b1dc3f-aa33-4338-b74e-40805c0d70e6"",
                    ""path"": ""<XRController>{RightHand}/triggerPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR Controller"",
                    ""action"": ""Trigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c8b4c34a-f90b-4a0c-8d4e-4b5bd753ebc8"",
                    ""path"": ""<XRController>{RightHand}/primaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR Controller"",
                    ""action"": ""Menu_B"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ae2ea3c9-cb49-4973-b146-3a1246faf8bf"",
                    ""path"": ""<XRController>{RightHand}/secondaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pad_A"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c2e0a287-1835-48a3-ab3c-a6f063ca21fa"",
                    ""path"": ""<XRController>{RightHand}/primary2DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aixs"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""XR Controller"",
            ""bindingGroup"": ""XR Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<XRHMD>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<XRController>{RightHand}"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<XRController>{LeftHand}"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<WMRHMD>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // MyXR HMD
        m_MyXRHMD = asset.FindActionMap("MyXR HMD", throwIfNotFound: true);
        m_MyXRHMD_Position = m_MyXRHMD.FindAction("Position", throwIfNotFound: true);
        m_MyXRHMD_Rotation = m_MyXRHMD.FindAction("Rotation", throwIfNotFound: true);
        // MyXR LeftHand
        m_MyXRLeftHand = asset.FindActionMap("MyXR LeftHand", throwIfNotFound: true);
        m_MyXRLeftHand_Position = m_MyXRLeftHand.FindAction("Position", throwIfNotFound: true);
        m_MyXRLeftHand_Rotation = m_MyXRLeftHand.FindAction("Rotation", throwIfNotFound: true);
        m_MyXRLeftHand_Grip = m_MyXRLeftHand.FindAction("Grip", throwIfNotFound: true);
        m_MyXRLeftHand_Trigger = m_MyXRLeftHand.FindAction("Trigger", throwIfNotFound: true);
        m_MyXRLeftHand_Menu_Y = m_MyXRLeftHand.FindAction("Menu_Y", throwIfNotFound: true);
        m_MyXRLeftHand_Pad_X = m_MyXRLeftHand.FindAction("Pad_X", throwIfNotFound: true);
        m_MyXRLeftHand_Aixs = m_MyXRLeftHand.FindAction("Aixs", throwIfNotFound: true);
        // MyXR RightHand
        m_MyXRRightHand = asset.FindActionMap("MyXR RightHand", throwIfNotFound: true);
        m_MyXRRightHand_Position = m_MyXRRightHand.FindAction("Position", throwIfNotFound: true);
        m_MyXRRightHand_Rotation = m_MyXRRightHand.FindAction("Rotation", throwIfNotFound: true);
        m_MyXRRightHand_Grip = m_MyXRRightHand.FindAction("Grip", throwIfNotFound: true);
        m_MyXRRightHand_Trigger = m_MyXRRightHand.FindAction("Trigger", throwIfNotFound: true);
        m_MyXRRightHand_Menu_B = m_MyXRRightHand.FindAction("Menu_B", throwIfNotFound: true);
        m_MyXRRightHand_Pad_A = m_MyXRRightHand.FindAction("Pad_A", throwIfNotFound: true);
        m_MyXRRightHand_Aixs = m_MyXRRightHand.FindAction("Aixs", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // MyXR HMD
    private readonly InputActionMap m_MyXRHMD;
    private IMyXRHMDActions m_MyXRHMDActionsCallbackInterface;
    private readonly InputAction m_MyXRHMD_Position;
    private readonly InputAction m_MyXRHMD_Rotation;
    public struct MyXRHMDActions
    {
        private @MyVRController m_Wrapper;
        public MyXRHMDActions(@MyVRController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Position => m_Wrapper.m_MyXRHMD_Position;
        public InputAction @Rotation => m_Wrapper.m_MyXRHMD_Rotation;
        public InputActionMap Get() { return m_Wrapper.m_MyXRHMD; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MyXRHMDActions set) { return set.Get(); }
        public void SetCallbacks(IMyXRHMDActions instance)
        {
            if (m_Wrapper.m_MyXRHMDActionsCallbackInterface != null)
            {
                @Position.started -= m_Wrapper.m_MyXRHMDActionsCallbackInterface.OnPosition;
                @Position.performed -= m_Wrapper.m_MyXRHMDActionsCallbackInterface.OnPosition;
                @Position.canceled -= m_Wrapper.m_MyXRHMDActionsCallbackInterface.OnPosition;
                @Rotation.started -= m_Wrapper.m_MyXRHMDActionsCallbackInterface.OnRotation;
                @Rotation.performed -= m_Wrapper.m_MyXRHMDActionsCallbackInterface.OnRotation;
                @Rotation.canceled -= m_Wrapper.m_MyXRHMDActionsCallbackInterface.OnRotation;
            }
            m_Wrapper.m_MyXRHMDActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Position.started += instance.OnPosition;
                @Position.performed += instance.OnPosition;
                @Position.canceled += instance.OnPosition;
                @Rotation.started += instance.OnRotation;
                @Rotation.performed += instance.OnRotation;
                @Rotation.canceled += instance.OnRotation;
            }
        }
    }
    public MyXRHMDActions @MyXRHMD => new MyXRHMDActions(this);

    // MyXR LeftHand
    private readonly InputActionMap m_MyXRLeftHand;
    private IMyXRLeftHandActions m_MyXRLeftHandActionsCallbackInterface;
    private readonly InputAction m_MyXRLeftHand_Position;
    private readonly InputAction m_MyXRLeftHand_Rotation;
    private readonly InputAction m_MyXRLeftHand_Grip;
    private readonly InputAction m_MyXRLeftHand_Trigger;
    private readonly InputAction m_MyXRLeftHand_Menu_Y;
    private readonly InputAction m_MyXRLeftHand_Pad_X;
    private readonly InputAction m_MyXRLeftHand_Aixs;
    public struct MyXRLeftHandActions
    {
        private @MyVRController m_Wrapper;
        public MyXRLeftHandActions(@MyVRController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Position => m_Wrapper.m_MyXRLeftHand_Position;
        public InputAction @Rotation => m_Wrapper.m_MyXRLeftHand_Rotation;
        public InputAction @Grip => m_Wrapper.m_MyXRLeftHand_Grip;
        public InputAction @Trigger => m_Wrapper.m_MyXRLeftHand_Trigger;
        public InputAction @Menu_Y => m_Wrapper.m_MyXRLeftHand_Menu_Y;
        public InputAction @Pad_X => m_Wrapper.m_MyXRLeftHand_Pad_X;
        public InputAction @Aixs => m_Wrapper.m_MyXRLeftHand_Aixs;
        public InputActionMap Get() { return m_Wrapper.m_MyXRLeftHand; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MyXRLeftHandActions set) { return set.Get(); }
        public void SetCallbacks(IMyXRLeftHandActions instance)
        {
            if (m_Wrapper.m_MyXRLeftHandActionsCallbackInterface != null)
            {
                @Position.started -= m_Wrapper.m_MyXRLeftHandActionsCallbackInterface.OnPosition;
                @Position.performed -= m_Wrapper.m_MyXRLeftHandActionsCallbackInterface.OnPosition;
                @Position.canceled -= m_Wrapper.m_MyXRLeftHandActionsCallbackInterface.OnPosition;
                @Rotation.started -= m_Wrapper.m_MyXRLeftHandActionsCallbackInterface.OnRotation;
                @Rotation.performed -= m_Wrapper.m_MyXRLeftHandActionsCallbackInterface.OnRotation;
                @Rotation.canceled -= m_Wrapper.m_MyXRLeftHandActionsCallbackInterface.OnRotation;
                @Grip.started -= m_Wrapper.m_MyXRLeftHandActionsCallbackInterface.OnGrip;
                @Grip.performed -= m_Wrapper.m_MyXRLeftHandActionsCallbackInterface.OnGrip;
                @Grip.canceled -= m_Wrapper.m_MyXRLeftHandActionsCallbackInterface.OnGrip;
                @Trigger.started -= m_Wrapper.m_MyXRLeftHandActionsCallbackInterface.OnTrigger;
                @Trigger.performed -= m_Wrapper.m_MyXRLeftHandActionsCallbackInterface.OnTrigger;
                @Trigger.canceled -= m_Wrapper.m_MyXRLeftHandActionsCallbackInterface.OnTrigger;
                @Menu_Y.started -= m_Wrapper.m_MyXRLeftHandActionsCallbackInterface.OnMenu_Y;
                @Menu_Y.performed -= m_Wrapper.m_MyXRLeftHandActionsCallbackInterface.OnMenu_Y;
                @Menu_Y.canceled -= m_Wrapper.m_MyXRLeftHandActionsCallbackInterface.OnMenu_Y;
                @Pad_X.started -= m_Wrapper.m_MyXRLeftHandActionsCallbackInterface.OnPad_X;
                @Pad_X.performed -= m_Wrapper.m_MyXRLeftHandActionsCallbackInterface.OnPad_X;
                @Pad_X.canceled -= m_Wrapper.m_MyXRLeftHandActionsCallbackInterface.OnPad_X;
                @Aixs.started -= m_Wrapper.m_MyXRLeftHandActionsCallbackInterface.OnAixs;
                @Aixs.performed -= m_Wrapper.m_MyXRLeftHandActionsCallbackInterface.OnAixs;
                @Aixs.canceled -= m_Wrapper.m_MyXRLeftHandActionsCallbackInterface.OnAixs;
            }
            m_Wrapper.m_MyXRLeftHandActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Position.started += instance.OnPosition;
                @Position.performed += instance.OnPosition;
                @Position.canceled += instance.OnPosition;
                @Rotation.started += instance.OnRotation;
                @Rotation.performed += instance.OnRotation;
                @Rotation.canceled += instance.OnRotation;
                @Grip.started += instance.OnGrip;
                @Grip.performed += instance.OnGrip;
                @Grip.canceled += instance.OnGrip;
                @Trigger.started += instance.OnTrigger;
                @Trigger.performed += instance.OnTrigger;
                @Trigger.canceled += instance.OnTrigger;
                @Menu_Y.started += instance.OnMenu_Y;
                @Menu_Y.performed += instance.OnMenu_Y;
                @Menu_Y.canceled += instance.OnMenu_Y;
                @Pad_X.started += instance.OnPad_X;
                @Pad_X.performed += instance.OnPad_X;
                @Pad_X.canceled += instance.OnPad_X;
                @Aixs.started += instance.OnAixs;
                @Aixs.performed += instance.OnAixs;
                @Aixs.canceled += instance.OnAixs;
            }
        }
    }
    public MyXRLeftHandActions @MyXRLeftHand => new MyXRLeftHandActions(this);

    // MyXR RightHand
    private readonly InputActionMap m_MyXRRightHand;
    private IMyXRRightHandActions m_MyXRRightHandActionsCallbackInterface;
    private readonly InputAction m_MyXRRightHand_Position;
    private readonly InputAction m_MyXRRightHand_Rotation;
    private readonly InputAction m_MyXRRightHand_Grip;
    private readonly InputAction m_MyXRRightHand_Trigger;
    private readonly InputAction m_MyXRRightHand_Menu_B;
    private readonly InputAction m_MyXRRightHand_Pad_A;
    private readonly InputAction m_MyXRRightHand_Aixs;
    public struct MyXRRightHandActions
    {
        private @MyVRController m_Wrapper;
        public MyXRRightHandActions(@MyVRController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Position => m_Wrapper.m_MyXRRightHand_Position;
        public InputAction @Rotation => m_Wrapper.m_MyXRRightHand_Rotation;
        public InputAction @Grip => m_Wrapper.m_MyXRRightHand_Grip;
        public InputAction @Trigger => m_Wrapper.m_MyXRRightHand_Trigger;
        public InputAction @Menu_B => m_Wrapper.m_MyXRRightHand_Menu_B;
        public InputAction @Pad_A => m_Wrapper.m_MyXRRightHand_Pad_A;
        public InputAction @Aixs => m_Wrapper.m_MyXRRightHand_Aixs;
        public InputActionMap Get() { return m_Wrapper.m_MyXRRightHand; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MyXRRightHandActions set) { return set.Get(); }
        public void SetCallbacks(IMyXRRightHandActions instance)
        {
            if (m_Wrapper.m_MyXRRightHandActionsCallbackInterface != null)
            {
                @Position.started -= m_Wrapper.m_MyXRRightHandActionsCallbackInterface.OnPosition;
                @Position.performed -= m_Wrapper.m_MyXRRightHandActionsCallbackInterface.OnPosition;
                @Position.canceled -= m_Wrapper.m_MyXRRightHandActionsCallbackInterface.OnPosition;
                @Rotation.started -= m_Wrapper.m_MyXRRightHandActionsCallbackInterface.OnRotation;
                @Rotation.performed -= m_Wrapper.m_MyXRRightHandActionsCallbackInterface.OnRotation;
                @Rotation.canceled -= m_Wrapper.m_MyXRRightHandActionsCallbackInterface.OnRotation;
                @Grip.started -= m_Wrapper.m_MyXRRightHandActionsCallbackInterface.OnGrip;
                @Grip.performed -= m_Wrapper.m_MyXRRightHandActionsCallbackInterface.OnGrip;
                @Grip.canceled -= m_Wrapper.m_MyXRRightHandActionsCallbackInterface.OnGrip;
                @Trigger.started -= m_Wrapper.m_MyXRRightHandActionsCallbackInterface.OnTrigger;
                @Trigger.performed -= m_Wrapper.m_MyXRRightHandActionsCallbackInterface.OnTrigger;
                @Trigger.canceled -= m_Wrapper.m_MyXRRightHandActionsCallbackInterface.OnTrigger;
                @Menu_B.started -= m_Wrapper.m_MyXRRightHandActionsCallbackInterface.OnMenu_B;
                @Menu_B.performed -= m_Wrapper.m_MyXRRightHandActionsCallbackInterface.OnMenu_B;
                @Menu_B.canceled -= m_Wrapper.m_MyXRRightHandActionsCallbackInterface.OnMenu_B;
                @Pad_A.started -= m_Wrapper.m_MyXRRightHandActionsCallbackInterface.OnPad_A;
                @Pad_A.performed -= m_Wrapper.m_MyXRRightHandActionsCallbackInterface.OnPad_A;
                @Pad_A.canceled -= m_Wrapper.m_MyXRRightHandActionsCallbackInterface.OnPad_A;
                @Aixs.started -= m_Wrapper.m_MyXRRightHandActionsCallbackInterface.OnAixs;
                @Aixs.performed -= m_Wrapper.m_MyXRRightHandActionsCallbackInterface.OnAixs;
                @Aixs.canceled -= m_Wrapper.m_MyXRRightHandActionsCallbackInterface.OnAixs;
            }
            m_Wrapper.m_MyXRRightHandActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Position.started += instance.OnPosition;
                @Position.performed += instance.OnPosition;
                @Position.canceled += instance.OnPosition;
                @Rotation.started += instance.OnRotation;
                @Rotation.performed += instance.OnRotation;
                @Rotation.canceled += instance.OnRotation;
                @Grip.started += instance.OnGrip;
                @Grip.performed += instance.OnGrip;
                @Grip.canceled += instance.OnGrip;
                @Trigger.started += instance.OnTrigger;
                @Trigger.performed += instance.OnTrigger;
                @Trigger.canceled += instance.OnTrigger;
                @Menu_B.started += instance.OnMenu_B;
                @Menu_B.performed += instance.OnMenu_B;
                @Menu_B.canceled += instance.OnMenu_B;
                @Pad_A.started += instance.OnPad_A;
                @Pad_A.performed += instance.OnPad_A;
                @Pad_A.canceled += instance.OnPad_A;
                @Aixs.started += instance.OnAixs;
                @Aixs.performed += instance.OnAixs;
                @Aixs.canceled += instance.OnAixs;
            }
        }
    }
    public MyXRRightHandActions @MyXRRightHand => new MyXRRightHandActions(this);
    private int m_XRControllerSchemeIndex = -1;
    public InputControlScheme XRControllerScheme
    {
        get
        {
            if (m_XRControllerSchemeIndex == -1) m_XRControllerSchemeIndex = asset.FindControlSchemeIndex("XR Controller");
            return asset.controlSchemes[m_XRControllerSchemeIndex];
        }
    }
    public interface IMyXRHMDActions
    {
        void OnPosition(InputAction.CallbackContext context);
        void OnRotation(InputAction.CallbackContext context);
    }
    public interface IMyXRLeftHandActions
    {
        void OnPosition(InputAction.CallbackContext context);
        void OnRotation(InputAction.CallbackContext context);
        void OnGrip(InputAction.CallbackContext context);
        void OnTrigger(InputAction.CallbackContext context);
        void OnMenu_Y(InputAction.CallbackContext context);
        void OnPad_X(InputAction.CallbackContext context);
        void OnAixs(InputAction.CallbackContext context);
    }
    public interface IMyXRRightHandActions
    {
        void OnPosition(InputAction.CallbackContext context);
        void OnRotation(InputAction.CallbackContext context);
        void OnGrip(InputAction.CallbackContext context);
        void OnTrigger(InputAction.CallbackContext context);
        void OnMenu_B(InputAction.CallbackContext context);
        void OnPad_A(InputAction.CallbackContext context);
        void OnAixs(InputAction.CallbackContext context);
    }
}
