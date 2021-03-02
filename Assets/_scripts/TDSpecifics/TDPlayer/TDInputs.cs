// GENERATED AUTOMATICALLY FROM 'Assets/_scripts/TopdownSpecifics/TDPlayer/TDInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @TDInputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @TDInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""TDInputs"",
    ""maps"": [
        {
            ""name"": ""PlayerNormal"",
            ""id"": ""6160647d-4508-425e-92ea-602f0a9ee641"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""c8af17b9-36fd-4980-a00c-9d0bfca6840f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""bf0409ad-033d-4d01-9406-95df812febfe"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c09961ea-af8d-42b8-b25d-254fd7192911"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e5228b8b-19a4-4d53-8de2-970796040b39"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""05a3869c-f5a5-4ffe-a526-54a9aa25b8cc"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""62359462-762e-4b17-a5e1-f3f1aa2d31fd"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""f498dbc3-60f0-49d3-a6bd-4521f1b9e764"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c47a471e-43ac-472f-959f-abdacfce4a4d"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""93790f90-b53b-4640-8f4b-9ff246fc5e25"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a48c6d85-7f79-4c4d-b4f4-4d883ca9586b"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3f7bb936-5c3a-407d-955b-7bd41f8ad430"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Directional Pad [Gamepad]"",
                    ""id"": ""d8c12c4d-9326-4ea2-97d3-9baca158bba3"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""37104c28-76aa-4e4c-b72a-ae040a7e4e6a"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b398feb1-83be-4dd8-894d-cc0dd02ea787"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""75383bc9-b7e9-4e8b-b6a8-7ab3db8145d8"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b13ea8fd-ea0d-49e5-8edb-096b72232962"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""db9ec1b0-57dd-49dd-873d-576feb9ad24d"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerInvented"",
            ""id"": ""b4dffbdb-c919-4e9a-8425-ea9ed2661d9b"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""71bee5f6-dfc2-4ca0-b6b3-9c59e7ccbb3a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""c8706621-6bd5-4cd0-8846-60935ec14ce0"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""28314b00-f3c6-46bc-b9e3-158fa0fb8c7a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d792758b-67d2-4811-81fa-7759bcbbb7cb"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""6ec5d227-bb8a-4daa-9f27-5f0f5317de5f"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3968e2d7-adfe-4a7e-ae72-35ed85d83993"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8aa35551-3bf2-4f65-ac5e-d2caef04d464"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""afa90712-2975-4b4f-a0f3-3b96a45060e0"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Directional Pad [Gamepad]"",
                    ""id"": ""bdf7b968-b878-4d29-8dd3-9281f42cfbd1"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""5f02bf96-3a6f-411c-97de-60dda2bf4585"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c625af6a-016c-4170-a4a6-6d9b38962995"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""49223ad2-a0e3-47c4-8ad7-fd9ec16ea727"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a19b531f-a68a-4abb-b03b-ee00bc812611"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""419c15bc-f78b-4ced-bf13-b3bd4f54b2f3"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7bc4bd5d-c855-4d96-ad2e-6c0efd89a739"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a4063f8b-ddf9-45df-9af5-691f3aff2099"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Main"",
            ""bindingGroup"": ""Main"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<SwitchProControllerHID>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PlayerNormal
        m_PlayerNormal = asset.FindActionMap("PlayerNormal", throwIfNotFound: true);
        m_PlayerNormal_Move = m_PlayerNormal.FindAction("Move", throwIfNotFound: true);
        // PlayerInvented
        m_PlayerInvented = asset.FindActionMap("PlayerInvented", throwIfNotFound: true);
        m_PlayerInvented_Move = m_PlayerInvented.FindAction("Move", throwIfNotFound: true);
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

    // PlayerNormal
    private readonly InputActionMap m_PlayerNormal;
    private IPlayerNormalActions m_PlayerNormalActionsCallbackInterface;
    private readonly InputAction m_PlayerNormal_Move;
    public struct PlayerNormalActions
    {
        private @TDInputs m_Wrapper;
        public PlayerNormalActions(@TDInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerNormal_Move;
        public InputActionMap Get() { return m_Wrapper.m_PlayerNormal; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerNormalActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerNormalActions instance)
        {
            if (m_Wrapper.m_PlayerNormalActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerNormalActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerNormalActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerNormalActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_PlayerNormalActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
    public PlayerNormalActions @PlayerNormal => new PlayerNormalActions(this);

    // PlayerInvented
    private readonly InputActionMap m_PlayerInvented;
    private IPlayerInventedActions m_PlayerInventedActionsCallbackInterface;
    private readonly InputAction m_PlayerInvented_Move;
    public struct PlayerInventedActions
    {
        private @TDInputs m_Wrapper;
        public PlayerInventedActions(@TDInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerInvented_Move;
        public InputActionMap Get() { return m_Wrapper.m_PlayerInvented; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerInventedActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerInventedActions instance)
        {
            if (m_Wrapper.m_PlayerInventedActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerInventedActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerInventedActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerInventedActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_PlayerInventedActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
    public PlayerInventedActions @PlayerInvented => new PlayerInventedActions(this);
    private int m_MainSchemeIndex = -1;
    public InputControlScheme MainScheme
    {
        get
        {
            if (m_MainSchemeIndex == -1) m_MainSchemeIndex = asset.FindControlSchemeIndex("Main");
            return asset.controlSchemes[m_MainSchemeIndex];
        }
    }
    public interface IPlayerNormalActions
    {
        void OnMove(InputAction.CallbackContext context);
    }
    public interface IPlayerInventedActions
    {
        void OnMove(InputAction.CallbackContext context);
    }
}
