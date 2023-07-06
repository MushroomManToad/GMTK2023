//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.1
//     from Assets/Scripts/Player/PlayerControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""MouseKeyboard"",
            ""id"": ""69bd3e9f-de17-4821-9b69-285fc36eaf64"",
            ""actions"": [
                {
                    ""name"": ""up"",
                    ""type"": ""Button"",
                    ""id"": ""1452d8b5-14ab-425f-89d2-8654d2d62505"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""down"",
                    ""type"": ""Button"",
                    ""id"": ""8c38faff-3d31-4f76-b248-7f3a5923e87c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""left"",
                    ""type"": ""Button"",
                    ""id"": ""59ac26b7-898c-413c-8461-345c0f137871"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""right"",
                    ""type"": ""Button"",
                    ""id"": ""0cc37bd8-a3b3-4c6f-87e1-6981df955fa6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""dash"",
                    ""type"": ""Button"",
                    ""id"": ""4801705c-810d-44a6-aef7-c089eb24eb15"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""shoot"",
                    ""type"": ""Button"",
                    ""id"": ""d613f73c-cb14-4c38-a50b-220912ffb311"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""mousePos"",
                    ""type"": ""Value"",
                    ""id"": ""65f2449e-9d71-4b59-9c31-e14578585868"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""fdfedad2-0ab7-47db-95b7-833510056775"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""pause"",
                    ""type"": ""Button"",
                    ""id"": ""98f67bf6-17c1-490e-92df-44f65b5b245c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e8b4b37e-92a9-46fd-94be-eaa84c0f62f8"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5993d080-6602-41cc-9682-3ec7ed9a6650"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""40cacd46-03a3-4da7-b2b6-0ae099d6637a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""35b2b6b3-f411-4557-9daa-49fb96ff5b91"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f4dcd4ab-68b9-475d-85cc-170ce6be0196"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""07d2d78d-5449-480b-a605-47a0736c9f4a"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c01c2162-a30f-459d-a93a-63079ecf1e5d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4a1e78b7-744f-4b2c-a5ad-e124faa3f5a3"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ad89e608-274a-4bc4-b00e-02dee28104d4"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""13b5306c-0b59-4f6a-8aa0-4bcced9ccce8"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""11a80cbc-6286-4397-9161-ebbad2edaa9d"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""11cd4c23-596e-46e5-958f-94c9d6153c5c"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""mousePos"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""50329f8e-2a09-4cbb-a4ea-c29e92b68416"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""76afcffa-42b9-4108-a2e5-cc06e35edaff"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e8904c45-384a-4873-9dbd-747907c4bf77"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""MouseKeyboard"",
            ""bindingGroup"": ""MouseKeyboard"",
            ""devices"": []
        }
    ]
}");
        // MouseKeyboard
        m_MouseKeyboard = asset.FindActionMap("MouseKeyboard", throwIfNotFound: true);
        m_MouseKeyboard_up = m_MouseKeyboard.FindAction("up", throwIfNotFound: true);
        m_MouseKeyboard_down = m_MouseKeyboard.FindAction("down", throwIfNotFound: true);
        m_MouseKeyboard_left = m_MouseKeyboard.FindAction("left", throwIfNotFound: true);
        m_MouseKeyboard_right = m_MouseKeyboard.FindAction("right", throwIfNotFound: true);
        m_MouseKeyboard_dash = m_MouseKeyboard.FindAction("dash", throwIfNotFound: true);
        m_MouseKeyboard_shoot = m_MouseKeyboard.FindAction("shoot", throwIfNotFound: true);
        m_MouseKeyboard_mousePos = m_MouseKeyboard.FindAction("mousePos", throwIfNotFound: true);
        m_MouseKeyboard_Jump = m_MouseKeyboard.FindAction("Jump", throwIfNotFound: true);
        m_MouseKeyboard_pause = m_MouseKeyboard.FindAction("pause", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // MouseKeyboard
    private readonly InputActionMap m_MouseKeyboard;
    private List<IMouseKeyboardActions> m_MouseKeyboardActionsCallbackInterfaces = new List<IMouseKeyboardActions>();
    private readonly InputAction m_MouseKeyboard_up;
    private readonly InputAction m_MouseKeyboard_down;
    private readonly InputAction m_MouseKeyboard_left;
    private readonly InputAction m_MouseKeyboard_right;
    private readonly InputAction m_MouseKeyboard_dash;
    private readonly InputAction m_MouseKeyboard_shoot;
    private readonly InputAction m_MouseKeyboard_mousePos;
    private readonly InputAction m_MouseKeyboard_Jump;
    private readonly InputAction m_MouseKeyboard_pause;
    public struct MouseKeyboardActions
    {
        private @PlayerControls m_Wrapper;
        public MouseKeyboardActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @up => m_Wrapper.m_MouseKeyboard_up;
        public InputAction @down => m_Wrapper.m_MouseKeyboard_down;
        public InputAction @left => m_Wrapper.m_MouseKeyboard_left;
        public InputAction @right => m_Wrapper.m_MouseKeyboard_right;
        public InputAction @dash => m_Wrapper.m_MouseKeyboard_dash;
        public InputAction @shoot => m_Wrapper.m_MouseKeyboard_shoot;
        public InputAction @mousePos => m_Wrapper.m_MouseKeyboard_mousePos;
        public InputAction @Jump => m_Wrapper.m_MouseKeyboard_Jump;
        public InputAction @pause => m_Wrapper.m_MouseKeyboard_pause;
        public InputActionMap Get() { return m_Wrapper.m_MouseKeyboard; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MouseKeyboardActions set) { return set.Get(); }
        public void AddCallbacks(IMouseKeyboardActions instance)
        {
            if (instance == null || m_Wrapper.m_MouseKeyboardActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MouseKeyboardActionsCallbackInterfaces.Add(instance);
            @up.started += instance.OnUp;
            @up.performed += instance.OnUp;
            @up.canceled += instance.OnUp;
            @down.started += instance.OnDown;
            @down.performed += instance.OnDown;
            @down.canceled += instance.OnDown;
            @left.started += instance.OnLeft;
            @left.performed += instance.OnLeft;
            @left.canceled += instance.OnLeft;
            @right.started += instance.OnRight;
            @right.performed += instance.OnRight;
            @right.canceled += instance.OnRight;
            @dash.started += instance.OnDash;
            @dash.performed += instance.OnDash;
            @dash.canceled += instance.OnDash;
            @shoot.started += instance.OnShoot;
            @shoot.performed += instance.OnShoot;
            @shoot.canceled += instance.OnShoot;
            @mousePos.started += instance.OnMousePos;
            @mousePos.performed += instance.OnMousePos;
            @mousePos.canceled += instance.OnMousePos;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @pause.started += instance.OnPause;
            @pause.performed += instance.OnPause;
            @pause.canceled += instance.OnPause;
        }

        private void UnregisterCallbacks(IMouseKeyboardActions instance)
        {
            @up.started -= instance.OnUp;
            @up.performed -= instance.OnUp;
            @up.canceled -= instance.OnUp;
            @down.started -= instance.OnDown;
            @down.performed -= instance.OnDown;
            @down.canceled -= instance.OnDown;
            @left.started -= instance.OnLeft;
            @left.performed -= instance.OnLeft;
            @left.canceled -= instance.OnLeft;
            @right.started -= instance.OnRight;
            @right.performed -= instance.OnRight;
            @right.canceled -= instance.OnRight;
            @dash.started -= instance.OnDash;
            @dash.performed -= instance.OnDash;
            @dash.canceled -= instance.OnDash;
            @shoot.started -= instance.OnShoot;
            @shoot.performed -= instance.OnShoot;
            @shoot.canceled -= instance.OnShoot;
            @mousePos.started -= instance.OnMousePos;
            @mousePos.performed -= instance.OnMousePos;
            @mousePos.canceled -= instance.OnMousePos;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @pause.started -= instance.OnPause;
            @pause.performed -= instance.OnPause;
            @pause.canceled -= instance.OnPause;
        }

        public void RemoveCallbacks(IMouseKeyboardActions instance)
        {
            if (m_Wrapper.m_MouseKeyboardActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMouseKeyboardActions instance)
        {
            foreach (var item in m_Wrapper.m_MouseKeyboardActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MouseKeyboardActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MouseKeyboardActions @MouseKeyboard => new MouseKeyboardActions(this);
    private int m_MouseKeyboardSchemeIndex = -1;
    public InputControlScheme MouseKeyboardScheme
    {
        get
        {
            if (m_MouseKeyboardSchemeIndex == -1) m_MouseKeyboardSchemeIndex = asset.FindControlSchemeIndex("MouseKeyboard");
            return asset.controlSchemes[m_MouseKeyboardSchemeIndex];
        }
    }
    public interface IMouseKeyboardActions
    {
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnMousePos(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
}
