// GENERATED AUTOMATICALLY FROM 'Assets/Project/Scripts/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""b8d1025a-dbcb-4023-85de-c949b9f0df05"",
            ""actions"": [
                {
                    ""name"": ""MoveLeft"",
                    ""type"": ""Button"",
                    ""id"": ""1bb5f07f-8106-45b9-b45c-bdc55595c967"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveRight"",
                    ""type"": ""Button"",
                    ""id"": ""577c3fdf-6f59-44c8-9e11-1a0a44a5557b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveBack"",
                    ""type"": ""Button"",
                    ""id"": ""352cf331-d270-477a-9b8d-1807a191bc64"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveForward"",
                    ""type"": ""Button"",
                    ""id"": ""6a408fc3-5e60-454a-9931-0bb35d416e35"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangePlayers"",
                    ""type"": ""Button"",
                    ""id"": ""9b8815b6-5047-44ab-b1a4-bd78e5e3b0ea"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Undo"",
                    ""type"": ""Button"",
                    ""id"": ""9d6fe6ed-8a3d-4850-a37e-80b72e99a030"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Restart"",
                    ""type"": ""Button"",
                    ""id"": ""e136e9e6-f1f2-4b80-a36b-22280932f92f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""bf4b478a-cae0-4e41-a2d3-24c67242cd39"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Number1"",
                    ""type"": ""Button"",
                    ""id"": ""10968148-c798-4042-a573-ed2ccfd94b06"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Number2"",
                    ""type"": ""Button"",
                    ""id"": ""c82e15a4-e78e-4ab3-9712-1a94dc2c885b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Number3"",
                    ""type"": ""Button"",
                    ""id"": ""21a9a801-af8e-44a4-ae76-d1c04f695b56"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Number4"",
                    ""type"": ""Button"",
                    ""id"": ""c56a91ec-20f8-4fcc-bcf4-59cf7045668e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Number5"",
                    ""type"": ""Button"",
                    ""id"": ""46017feb-7893-40fa-ba02-52ca6c9b9b5d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e5cca0eb-9f8b-4299-a240-ad3dc5b16538"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""97c96aaa-53e3-4000-a87f-a19f26924612"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bc8c3ea3-7b81-4522-a7a2-21aea299841d"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""16c2e41f-1ef1-4a75-93db-40d449271417"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bc391fd2-03f7-4aa3-b438-cbca6a4def92"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveBack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0b1ccda2-0b82-4fb8-ad3d-2d3380697475"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveBack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3ccbf6e5-e570-4cd1-b92e-6c696a8123cd"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4b8a4418-ad7c-44c4-b874-42300b6348ff"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dea87978-da68-4af9-9c86-769fbce25006"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangePlayers"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f0fc1144-7306-4c32-abac-d69216ef5587"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Undo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""48683eb0-7047-47bc-a705-c8e79fad3a4b"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0c8f2849-6082-46d6-ad48-805d5066e352"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2ece6a31-840f-47b1-9d7b-a0cbbf25cd20"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Number1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""16d539a2-e53d-46a6-b91f-573d18920406"",
                    ""path"": ""<Keyboard>/numpad1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Number1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""55cadcae-fa4d-456d-927c-6810e6148bb3"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Number2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""753c34ba-dbb0-4b95-973a-aecc3700122e"",
                    ""path"": ""<Keyboard>/numpad2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Number2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e2723c15-b730-49df-b73a-99a0070108fb"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Number3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fe8276d5-d185-4989-abf6-50abfc83f832"",
                    ""path"": ""<Keyboard>/numpad3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Number3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""248cf0b7-d859-4126-81e2-45293375f56b"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Number4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""945b4a35-3622-4838-8f74-4353efe488d4"",
                    ""path"": ""<Keyboard>/numpad4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Number4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""05b21bd7-b9f0-47d7-8b71-0724274de7a1"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Number5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c06e1636-7550-4cb7-899b-dfb6e4aceb58"",
                    ""path"": ""<Keyboard>/numpad5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Number5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_MoveLeft = m_Player.FindAction("MoveLeft", throwIfNotFound: true);
        m_Player_MoveRight = m_Player.FindAction("MoveRight", throwIfNotFound: true);
        m_Player_MoveBack = m_Player.FindAction("MoveBack", throwIfNotFound: true);
        m_Player_MoveForward = m_Player.FindAction("MoveForward", throwIfNotFound: true);
        m_Player_ChangePlayers = m_Player.FindAction("ChangePlayers", throwIfNotFound: true);
        m_Player_Undo = m_Player.FindAction("Undo", throwIfNotFound: true);
        m_Player_Restart = m_Player.FindAction("Restart", throwIfNotFound: true);
        m_Player_Pause = m_Player.FindAction("Pause", throwIfNotFound: true);
        m_Player_Number1 = m_Player.FindAction("Number1", throwIfNotFound: true);
        m_Player_Number2 = m_Player.FindAction("Number2", throwIfNotFound: true);
        m_Player_Number3 = m_Player.FindAction("Number3", throwIfNotFound: true);
        m_Player_Number4 = m_Player.FindAction("Number4", throwIfNotFound: true);
        m_Player_Number5 = m_Player.FindAction("Number5", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_MoveLeft;
    private readonly InputAction m_Player_MoveRight;
    private readonly InputAction m_Player_MoveBack;
    private readonly InputAction m_Player_MoveForward;
    private readonly InputAction m_Player_ChangePlayers;
    private readonly InputAction m_Player_Undo;
    private readonly InputAction m_Player_Restart;
    private readonly InputAction m_Player_Pause;
    private readonly InputAction m_Player_Number1;
    private readonly InputAction m_Player_Number2;
    private readonly InputAction m_Player_Number3;
    private readonly InputAction m_Player_Number4;
    private readonly InputAction m_Player_Number5;
    public struct PlayerActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveLeft => m_Wrapper.m_Player_MoveLeft;
        public InputAction @MoveRight => m_Wrapper.m_Player_MoveRight;
        public InputAction @MoveBack => m_Wrapper.m_Player_MoveBack;
        public InputAction @MoveForward => m_Wrapper.m_Player_MoveForward;
        public InputAction @ChangePlayers => m_Wrapper.m_Player_ChangePlayers;
        public InputAction @Undo => m_Wrapper.m_Player_Undo;
        public InputAction @Restart => m_Wrapper.m_Player_Restart;
        public InputAction @Pause => m_Wrapper.m_Player_Pause;
        public InputAction @Number1 => m_Wrapper.m_Player_Number1;
        public InputAction @Number2 => m_Wrapper.m_Player_Number2;
        public InputAction @Number3 => m_Wrapper.m_Player_Number3;
        public InputAction @Number4 => m_Wrapper.m_Player_Number4;
        public InputAction @Number5 => m_Wrapper.m_Player_Number5;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @MoveLeft.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveLeft;
                @MoveRight.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveRight;
                @MoveRight.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveRight;
                @MoveRight.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveRight;
                @MoveBack.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveBack;
                @MoveBack.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveBack;
                @MoveBack.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveBack;
                @MoveForward.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveForward;
                @MoveForward.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveForward;
                @MoveForward.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveForward;
                @ChangePlayers.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChangePlayers;
                @ChangePlayers.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChangePlayers;
                @ChangePlayers.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChangePlayers;
                @Undo.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUndo;
                @Undo.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUndo;
                @Undo.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUndo;
                @Restart.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRestart;
                @Restart.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRestart;
                @Restart.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRestart;
                @Pause.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Number1.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNumber1;
                @Number1.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNumber1;
                @Number1.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNumber1;
                @Number2.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNumber2;
                @Number2.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNumber2;
                @Number2.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNumber2;
                @Number3.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNumber3;
                @Number3.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNumber3;
                @Number3.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNumber3;
                @Number4.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNumber4;
                @Number4.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNumber4;
                @Number4.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNumber4;
                @Number5.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNumber5;
                @Number5.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNumber5;
                @Number5.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNumber5;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveLeft.started += instance.OnMoveLeft;
                @MoveLeft.performed += instance.OnMoveLeft;
                @MoveLeft.canceled += instance.OnMoveLeft;
                @MoveRight.started += instance.OnMoveRight;
                @MoveRight.performed += instance.OnMoveRight;
                @MoveRight.canceled += instance.OnMoveRight;
                @MoveBack.started += instance.OnMoveBack;
                @MoveBack.performed += instance.OnMoveBack;
                @MoveBack.canceled += instance.OnMoveBack;
                @MoveForward.started += instance.OnMoveForward;
                @MoveForward.performed += instance.OnMoveForward;
                @MoveForward.canceled += instance.OnMoveForward;
                @ChangePlayers.started += instance.OnChangePlayers;
                @ChangePlayers.performed += instance.OnChangePlayers;
                @ChangePlayers.canceled += instance.OnChangePlayers;
                @Undo.started += instance.OnUndo;
                @Undo.performed += instance.OnUndo;
                @Undo.canceled += instance.OnUndo;
                @Restart.started += instance.OnRestart;
                @Restart.performed += instance.OnRestart;
                @Restart.canceled += instance.OnRestart;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @Number1.started += instance.OnNumber1;
                @Number1.performed += instance.OnNumber1;
                @Number1.canceled += instance.OnNumber1;
                @Number2.started += instance.OnNumber2;
                @Number2.performed += instance.OnNumber2;
                @Number2.canceled += instance.OnNumber2;
                @Number3.started += instance.OnNumber3;
                @Number3.performed += instance.OnNumber3;
                @Number3.canceled += instance.OnNumber3;
                @Number4.started += instance.OnNumber4;
                @Number4.performed += instance.OnNumber4;
                @Number4.canceled += instance.OnNumber4;
                @Number5.started += instance.OnNumber5;
                @Number5.performed += instance.OnNumber5;
                @Number5.canceled += instance.OnNumber5;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnMoveLeft(InputAction.CallbackContext context);
        void OnMoveRight(InputAction.CallbackContext context);
        void OnMoveBack(InputAction.CallbackContext context);
        void OnMoveForward(InputAction.CallbackContext context);
        void OnChangePlayers(InputAction.CallbackContext context);
        void OnUndo(InputAction.CallbackContext context);
        void OnRestart(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnNumber1(InputAction.CallbackContext context);
        void OnNumber2(InputAction.CallbackContext context);
        void OnNumber3(InputAction.CallbackContext context);
        void OnNumber4(InputAction.CallbackContext context);
        void OnNumber5(InputAction.CallbackContext context);
    }
}
