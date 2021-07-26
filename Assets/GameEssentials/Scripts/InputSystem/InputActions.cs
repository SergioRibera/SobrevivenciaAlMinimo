// GENERATED AUTOMATICALLY FROM 'Assets/InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""PlayerKeyboard"",
            ""id"": ""6d021e5d-3e7f-456b-ad0f-916133c99acb"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""00de2498-6f1c-4cbb-ac71-70368491abc7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Mouse"",
                    ""type"": ""PassThrough"",
                    ""id"": ""4b2cbb65-7629-4ec8-8edb-b46b9f7aaa32"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""63fc7cab-7efd-42c2-b48f-46f289e2c226"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": ""AxisDeadzone"",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e7f6af66-3c94-4c9b-b65f-6c5aaf1cc51c"",
                    ""path"": ""<Keyboard>/#(w)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controls"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3d0da08f-dd83-4f5b-a4c6-bc65cf36af85"",
                    ""path"": ""<Keyboard>/#(s)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controls"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c33440ac-43a2-4f21-baf0-5acdd5136926"",
                    ""path"": ""<Keyboard>/#(a)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controls"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""da028b16-954b-4ffa-aef4-0e1c5409c41b"",
                    ""path"": ""<Keyboard>/#(d)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controls"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""c3dcceda-bdbc-4f2e-80c4-eb5b32c62487"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouse"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""4dd19a39-098b-4c26-b680-1cbef80a077a"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controls"",
                    ""action"": ""Mouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""dc2f77b7-3854-4029-9048-8ca61243b38f"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controls"",
                    ""action"": ""Mouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e82d2f1e-525a-4c92-84ed-2a6911b4329d"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controls"",
                    ""action"": ""Mouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c4b39e45-df7e-4576-874b-4c671de79586"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controls"",
                    ""action"": ""Mouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""PlayerNormal"",
            ""id"": ""0782184e-d7e6-40c3-848a-71a6e1ad3495"",
            ""actions"": [
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""4a941aad-5169-4077-bc9d-07bca4c0219c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""01c7006c-b4d2-4d1f-ad54-411ca59ea55f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e05e9c26-ab7e-4c1f-b1fe-41236f66c3a8"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""110ffd42-cecb-43fa-b29e-e490b0974cd6"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Interface"",
            ""id"": ""6e7748cc-b8b9-46e0-bb5d-717b9a09e7f0"",
            ""actions"": [
                {
                    ""name"": ""Acept"",
                    ""type"": ""Button"",
                    ""id"": ""0cd40f4e-9ac4-4fab-b630-99783c9bb4fb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""063d463a-0cd4-4edd-ab23-de1a60d5c3a7"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Acept"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eaa0bfe9-b537-4b28-bdb2-45324356dda0"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Acept"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Controls"",
            ""bindingGroup"": ""Controls"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PlayerKeyboard
        m_PlayerKeyboard = asset.FindActionMap("PlayerKeyboard", throwIfNotFound: true);
        m_PlayerKeyboard_Move = m_PlayerKeyboard.FindAction("Move", throwIfNotFound: true);
        m_PlayerKeyboard_Mouse = m_PlayerKeyboard.FindAction("Mouse", throwIfNotFound: true);
        // PlayerNormal
        m_PlayerNormal = asset.FindActionMap("PlayerNormal", throwIfNotFound: true);
        m_PlayerNormal_MousePosition = m_PlayerNormal.FindAction("MousePosition", throwIfNotFound: true);
        m_PlayerNormal_Pause = m_PlayerNormal.FindAction("Pause", throwIfNotFound: true);
        // Interface
        m_Interface = asset.FindActionMap("Interface", throwIfNotFound: true);
        m_Interface_Acept = m_Interface.FindAction("Acept", throwIfNotFound: true);
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

    // PlayerKeyboard
    private readonly InputActionMap m_PlayerKeyboard;
    private IPlayerKeyboardActions m_PlayerKeyboardActionsCallbackInterface;
    private readonly InputAction m_PlayerKeyboard_Move;
    private readonly InputAction m_PlayerKeyboard_Mouse;
    public struct PlayerKeyboardActions
    {
        private @InputActions m_Wrapper;
        public PlayerKeyboardActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerKeyboard_Move;
        public InputAction @Mouse => m_Wrapper.m_PlayerKeyboard_Mouse;
        public InputActionMap Get() { return m_Wrapper.m_PlayerKeyboard; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerKeyboardActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerKeyboardActions instance)
        {
            if (m_Wrapper.m_PlayerKeyboardActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnMove;
                @Mouse.started -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnMouse;
                @Mouse.performed -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnMouse;
                @Mouse.canceled -= m_Wrapper.m_PlayerKeyboardActionsCallbackInterface.OnMouse;
            }
            m_Wrapper.m_PlayerKeyboardActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Mouse.started += instance.OnMouse;
                @Mouse.performed += instance.OnMouse;
                @Mouse.canceled += instance.OnMouse;
            }
        }
    }
    public PlayerKeyboardActions @PlayerKeyboard => new PlayerKeyboardActions(this);

    // PlayerNormal
    private readonly InputActionMap m_PlayerNormal;
    private IPlayerNormalActions m_PlayerNormalActionsCallbackInterface;
    private readonly InputAction m_PlayerNormal_MousePosition;
    private readonly InputAction m_PlayerNormal_Pause;
    public struct PlayerNormalActions
    {
        private @InputActions m_Wrapper;
        public PlayerNormalActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @MousePosition => m_Wrapper.m_PlayerNormal_MousePosition;
        public InputAction @Pause => m_Wrapper.m_PlayerNormal_Pause;
        public InputActionMap Get() { return m_Wrapper.m_PlayerNormal; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerNormalActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerNormalActions instance)
        {
            if (m_Wrapper.m_PlayerNormalActionsCallbackInterface != null)
            {
                @MousePosition.started -= m_Wrapper.m_PlayerNormalActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_PlayerNormalActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_PlayerNormalActionsCallbackInterface.OnMousePosition;
                @Pause.started -= m_Wrapper.m_PlayerNormalActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_PlayerNormalActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_PlayerNormalActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_PlayerNormalActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public PlayerNormalActions @PlayerNormal => new PlayerNormalActions(this);

    // Interface
    private readonly InputActionMap m_Interface;
    private IInterfaceActions m_InterfaceActionsCallbackInterface;
    private readonly InputAction m_Interface_Acept;
    public struct InterfaceActions
    {
        private @InputActions m_Wrapper;
        public InterfaceActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Acept => m_Wrapper.m_Interface_Acept;
        public InputActionMap Get() { return m_Wrapper.m_Interface; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InterfaceActions set) { return set.Get(); }
        public void SetCallbacks(IInterfaceActions instance)
        {
            if (m_Wrapper.m_InterfaceActionsCallbackInterface != null)
            {
                @Acept.started -= m_Wrapper.m_InterfaceActionsCallbackInterface.OnAcept;
                @Acept.performed -= m_Wrapper.m_InterfaceActionsCallbackInterface.OnAcept;
                @Acept.canceled -= m_Wrapper.m_InterfaceActionsCallbackInterface.OnAcept;
            }
            m_Wrapper.m_InterfaceActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Acept.started += instance.OnAcept;
                @Acept.performed += instance.OnAcept;
                @Acept.canceled += instance.OnAcept;
            }
        }
    }
    public InterfaceActions @Interface => new InterfaceActions(this);
    private int m_ControlsSchemeIndex = -1;
    public InputControlScheme ControlsScheme
    {
        get
        {
            if (m_ControlsSchemeIndex == -1) m_ControlsSchemeIndex = asset.FindControlSchemeIndex("Controls");
            return asset.controlSchemes[m_ControlsSchemeIndex];
        }
    }
    public interface IPlayerKeyboardActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnMouse(InputAction.CallbackContext context);
    }
    public interface IPlayerNormalActions
    {
        void OnMousePosition(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
    public interface IInterfaceActions
    {
        void OnAcept(InputAction.CallbackContext context);
    }
}
