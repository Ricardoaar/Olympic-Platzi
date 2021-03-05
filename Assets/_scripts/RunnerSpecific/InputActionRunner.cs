// GENERATED AUTOMATICALLY FROM 'Assets/_scripts/RunnerSpecific/InputActionRunner.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputActionRunner : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActionRunner()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActionRunner"",
    ""maps"": [
        {
            ""name"": ""A_Fizq"",
            ""id"": ""dc53624b-bf71-4390-9806-7ff5d5b6eda1"",
            ""actions"": [
                {
                    ""name"": ""Button1"",
                    ""type"": ""Button"",
                    ""id"": ""ffdc5f89-b2c7-4510-afd3-b8fc7abd7d3f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""10eefd4d-bb68-406c-ae6a-a891a38ef6e1"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Button1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6180fde2-bc07-4005-a833-3da7e807c156"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Button1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""28c63c78-f9d3-441e-8243-33c8b2b5d707"",
                    ""path"": ""<XInputController>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Button1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""07c3b055-927a-408d-b361-24030741b31c"",
                    ""path"": ""<DualShockGamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Button1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""S_Tizq"",
            ""id"": ""f8626617-77b0-4f7c-aac4-8bdc4f618044"",
            ""actions"": [
                {
                    ""name"": ""Button2"",
                    ""type"": ""Button"",
                    ""id"": ""d25cf6b6-5123-44d3-8936-c181b9799873"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2a2e7c90-435a-4cf5-a62b-1741825c0edf"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Button2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""709b10e5-a530-4f84-882a-99016f376bdb"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Button2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""18781efa-fcf4-4aab-8790-680fa2a703b9"",
                    ""path"": ""<XInputController>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Button2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8a2f356f-b0ed-446d-9230-65181bacb7a3"",
                    ""path"": ""<DualShockGamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Button2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""D_Tder"",
            ""id"": ""1fb45cc1-4c12-4b43-aa40-32edcfc52d8b"",
            ""actions"": [
                {
                    ""name"": ""Button3"",
                    ""type"": ""Button"",
                    ""id"": ""983cbddc-6d8c-482c-bd5e-1af316d45694"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""bdddefc7-7c88-4401-b228-6dabac3a843b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Button3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8c992f75-c533-444a-8d49-637b22027a49"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Button3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""36c0524d-dfbe-497d-a177-f509904eb1bb"",
                    ""path"": ""<XInputController>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Button3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a0f723e8-2f41-4b7d-a24f-62f22e5e9754"",
                    ""path"": ""<DualShockGamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Button3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""F_B"",
            ""id"": ""cf24d1b3-6b05-4481-91ec-9640c022758b"",
            ""actions"": [
                {
                    ""name"": ""Button4"",
                    ""type"": ""Button"",
                    ""id"": ""d29f663c-d2c6-4619-b673-4a88db943b56"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2a9e049a-4927-456f-8e3c-a9e36925d9db"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Button4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2bad731d-0058-442d-beb2-df68d2291dc1"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Button4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""626800bd-ef99-4f50-b0ab-e4fb8d3c3977"",
                    ""path"": ""<XInputController>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Button4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""093328ca-e685-414b-975d-5a924290a291"",
                    ""path"": ""<DualShockGamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Button4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // A_Fizq
        m_A_Fizq = asset.FindActionMap("A_Fizq", throwIfNotFound: true);
        m_A_Fizq_Button1 = m_A_Fizq.FindAction("Button1", throwIfNotFound: true);
        // S_Tizq
        m_S_Tizq = asset.FindActionMap("S_Tizq", throwIfNotFound: true);
        m_S_Tizq_Button2 = m_S_Tizq.FindAction("Button2", throwIfNotFound: true);
        // D_Tder
        m_D_Tder = asset.FindActionMap("D_Tder", throwIfNotFound: true);
        m_D_Tder_Button3 = m_D_Tder.FindAction("Button3", throwIfNotFound: true);
        // F_B
        m_F_B = asset.FindActionMap("F_B", throwIfNotFound: true);
        m_F_B_Button4 = m_F_B.FindAction("Button4", throwIfNotFound: true);
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

    // A_Fizq
    private readonly InputActionMap m_A_Fizq;
    private IA_FizqActions m_A_FizqActionsCallbackInterface;
    private readonly InputAction m_A_Fizq_Button1;
    public struct A_FizqActions
    {
        private @InputActionRunner m_Wrapper;
        public A_FizqActions(@InputActionRunner wrapper) { m_Wrapper = wrapper; }
        public InputAction @Button1 => m_Wrapper.m_A_Fizq_Button1;
        public InputActionMap Get() { return m_Wrapper.m_A_Fizq; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(A_FizqActions set) { return set.Get(); }
        public void SetCallbacks(IA_FizqActions instance)
        {
            if (m_Wrapper.m_A_FizqActionsCallbackInterface != null)
            {
                @Button1.started -= m_Wrapper.m_A_FizqActionsCallbackInterface.OnButton1;
                @Button1.performed -= m_Wrapper.m_A_FizqActionsCallbackInterface.OnButton1;
                @Button1.canceled -= m_Wrapper.m_A_FizqActionsCallbackInterface.OnButton1;
            }
            m_Wrapper.m_A_FizqActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Button1.started += instance.OnButton1;
                @Button1.performed += instance.OnButton1;
                @Button1.canceled += instance.OnButton1;
            }
        }
    }
    public A_FizqActions @A_Fizq => new A_FizqActions(this);

    // S_Tizq
    private readonly InputActionMap m_S_Tizq;
    private IS_TizqActions m_S_TizqActionsCallbackInterface;
    private readonly InputAction m_S_Tizq_Button2;
    public struct S_TizqActions
    {
        private @InputActionRunner m_Wrapper;
        public S_TizqActions(@InputActionRunner wrapper) { m_Wrapper = wrapper; }
        public InputAction @Button2 => m_Wrapper.m_S_Tizq_Button2;
        public InputActionMap Get() { return m_Wrapper.m_S_Tizq; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(S_TizqActions set) { return set.Get(); }
        public void SetCallbacks(IS_TizqActions instance)
        {
            if (m_Wrapper.m_S_TizqActionsCallbackInterface != null)
            {
                @Button2.started -= m_Wrapper.m_S_TizqActionsCallbackInterface.OnButton2;
                @Button2.performed -= m_Wrapper.m_S_TizqActionsCallbackInterface.OnButton2;
                @Button2.canceled -= m_Wrapper.m_S_TizqActionsCallbackInterface.OnButton2;
            }
            m_Wrapper.m_S_TizqActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Button2.started += instance.OnButton2;
                @Button2.performed += instance.OnButton2;
                @Button2.canceled += instance.OnButton2;
            }
        }
    }
    public S_TizqActions @S_Tizq => new S_TizqActions(this);

    // D_Tder
    private readonly InputActionMap m_D_Tder;
    private ID_TderActions m_D_TderActionsCallbackInterface;
    private readonly InputAction m_D_Tder_Button3;
    public struct D_TderActions
    {
        private @InputActionRunner m_Wrapper;
        public D_TderActions(@InputActionRunner wrapper) { m_Wrapper = wrapper; }
        public InputAction @Button3 => m_Wrapper.m_D_Tder_Button3;
        public InputActionMap Get() { return m_Wrapper.m_D_Tder; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(D_TderActions set) { return set.Get(); }
        public void SetCallbacks(ID_TderActions instance)
        {
            if (m_Wrapper.m_D_TderActionsCallbackInterface != null)
            {
                @Button3.started -= m_Wrapper.m_D_TderActionsCallbackInterface.OnButton3;
                @Button3.performed -= m_Wrapper.m_D_TderActionsCallbackInterface.OnButton3;
                @Button3.canceled -= m_Wrapper.m_D_TderActionsCallbackInterface.OnButton3;
            }
            m_Wrapper.m_D_TderActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Button3.started += instance.OnButton3;
                @Button3.performed += instance.OnButton3;
                @Button3.canceled += instance.OnButton3;
            }
        }
    }
    public D_TderActions @D_Tder => new D_TderActions(this);

    // F_B
    private readonly InputActionMap m_F_B;
    private IF_BActions m_F_BActionsCallbackInterface;
    private readonly InputAction m_F_B_Button4;
    public struct F_BActions
    {
        private @InputActionRunner m_Wrapper;
        public F_BActions(@InputActionRunner wrapper) { m_Wrapper = wrapper; }
        public InputAction @Button4 => m_Wrapper.m_F_B_Button4;
        public InputActionMap Get() { return m_Wrapper.m_F_B; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(F_BActions set) { return set.Get(); }
        public void SetCallbacks(IF_BActions instance)
        {
            if (m_Wrapper.m_F_BActionsCallbackInterface != null)
            {
                @Button4.started -= m_Wrapper.m_F_BActionsCallbackInterface.OnButton4;
                @Button4.performed -= m_Wrapper.m_F_BActionsCallbackInterface.OnButton4;
                @Button4.canceled -= m_Wrapper.m_F_BActionsCallbackInterface.OnButton4;
            }
            m_Wrapper.m_F_BActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Button4.started += instance.OnButton4;
                @Button4.performed += instance.OnButton4;
                @Button4.canceled += instance.OnButton4;
            }
        }
    }
    public F_BActions @F_B => new F_BActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IA_FizqActions
    {
        void OnButton1(InputAction.CallbackContext context);
    }
    public interface IS_TizqActions
    {
        void OnButton2(InputAction.CallbackContext context);
    }
    public interface ID_TderActions
    {
        void OnButton3(InputAction.CallbackContext context);
    }
    public interface IF_BActions
    {
        void OnButton4(InputAction.CallbackContext context);
    }
}
