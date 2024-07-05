//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Scripts/InputMap/GameControls.inputactions
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

namespace InputMap
{
    public partial class @GameController: IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @GameController()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameControls"",
    ""maps"": [
        {
            ""name"": ""Input"",
            ""id"": ""486cd634-e311-46b1-8c42-76b5e8512443"",
            ""actions"": [
                {
                    ""name"": ""LeftTrigger"",
                    ""type"": ""Value"",
                    ""id"": ""7be9eef6-cf3a-4c92-ad87-c3d86d8da65d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""RightTrigger"",
                    ""type"": ""Value"",
                    ""id"": ""c281b28d-d583-4ac1-893f-6501412e65fb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""LeftButton"",
                    ""type"": ""Button"",
                    ""id"": ""c10bb6a1-18e1-461a-acab-89d784e1dc65"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RightButton"",
                    ""type"": ""Button"",
                    ""id"": ""9919a266-cf85-4839-a1e6-0d087cf0b6d1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SelectButton"",
                    ""type"": ""Button"",
                    ""id"": ""8f65c8f2-d22f-4465-a1c1-ea71629aa164"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""StartButton"",
                    ""type"": ""Button"",
                    ""id"": ""f4b43fe8-3174-4e9b-ab8e-aa611a201483"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""WestButton"",
                    ""type"": ""Button"",
                    ""id"": ""99551ad9-19f2-453f-8815-bfea99dfaf20"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""EastButton"",
                    ""type"": ""Button"",
                    ""id"": ""20e06efe-ba9c-4335-8785-f5dd8a8a0bec"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""NorthButton"",
                    ""type"": ""Button"",
                    ""id"": ""53e1d2ab-85bc-4459-b765-acdac82f9934"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SouthButton"",
                    ""type"": ""Button"",
                    ""id"": ""cc3d0ec4-c940-4bae-aba0-d3bbd0e40054"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""DPad"",
                    ""type"": ""Value"",
                    ""id"": ""5d1e0ea0-c55b-412c-8a46-480656a9e8d2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Joystick1"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e83c125a-7308-49e5-97f6-2f2cc4e4af7a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Joystick2"",
                    ""type"": ""PassThrough"",
                    ""id"": ""cfed8bd0-93c3-49bb-a01b-afdb23259b01"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""JoystickButton1"",
                    ""type"": ""Button"",
                    ""id"": ""68993cdb-f776-49ab-b0af-fb8b9719bffa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""JoystickButton2"",
                    ""type"": ""Button"",
                    ""id"": ""446eeb26-abf9-4bfc-bf8f-ccc96f04cc4b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""type"": ""Button"",
                    ""id"": ""71b6e43b-1719-41b8-a52c-08ded69a3a0e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Mouse"",
                    ""type"": ""Button"",
                    ""id"": ""3c3dc2af-d78b-42cb-bc24-0344797bac7c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pointer"",
                    ""type"": ""PassThrough"",
                    ""id"": ""8f9b8aed-d3ee-4049-bb68-c83db51099cc"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5e25293e-e19f-420d-9055-e41c48263140"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftTrigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c97d9b5b-be3e-4989-893c-7ee75b782535"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightTrigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d6ec1fed-bc10-4b6c-a875-2ee200afaf6c"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ef9a606b-aa9e-432c-a942-6de5eb49eac6"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0095fef6-45ea-431c-8253-29d73ce1306c"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b489601c-a5d2-4f95-8329-efa4919dbaa5"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fe989977-c008-40c9-b453-f508b4d9a226"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WestButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""83a6536f-dd7c-4750-84aa-402f6a42e091"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EastButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""76d9c77d-fdac-4abf-96c0-2cb5eb8860c4"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NorthButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e063af1a-905b-4bf6-aa14-919a2d024013"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SouthButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1597d1d3-71dc-416c-b22c-f9e2421bfd7e"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DPad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""87667bc1-ff22-4645-a972-35fc71a474ce"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Joystick1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""849e84c8-2065-451b-a8a3-13993b985700"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Joystick2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""00adebb6-8b9a-485c-8737-8b0260d23885"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JoystickButton1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6f4aea88-ed4b-4228-b040-481c1df3c6f2"",
                    ""path"": ""<Gamepad>/rightStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JoystickButton2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a0912c38-d7b5-43ca-b8a8-2c73a58bfaca"",
                    ""path"": ""<Keyboard>/anyKey"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Keyboard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f2d8d49a-ba1e-431e-8028-5d385936c045"",
                    ""path"": ""<Mouse>/backButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4e6d983a-a505-41ce-8cff-ae077e80a746"",
                    ""path"": ""<Mouse>/forwardButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""554e22cb-e23e-484a-8af5-4364aebb0177"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8f2ac747-ae36-4436-820f-63c97a49db5e"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1eafcea2-8944-4c6f-8a37-b13673e47bfb"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6759c82f-c7cf-4256-84a5-0a1438b7d77e"",
                    ""path"": ""<Pointer>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d4b2b9fb-bd57-401f-b00b-a23079772747"",
                    ""path"": ""<Pointer>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pointer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Input
            m_Input = asset.FindActionMap("Input", throwIfNotFound: true);
            m_Input_LeftTrigger = m_Input.FindAction("LeftTrigger", throwIfNotFound: true);
            m_Input_RightTrigger = m_Input.FindAction("RightTrigger", throwIfNotFound: true);
            m_Input_LeftButton = m_Input.FindAction("LeftButton", throwIfNotFound: true);
            m_Input_RightButton = m_Input.FindAction("RightButton", throwIfNotFound: true);
            m_Input_SelectButton = m_Input.FindAction("SelectButton", throwIfNotFound: true);
            m_Input_StartButton = m_Input.FindAction("StartButton", throwIfNotFound: true);
            m_Input_WestButton = m_Input.FindAction("WestButton", throwIfNotFound: true);
            m_Input_EastButton = m_Input.FindAction("EastButton", throwIfNotFound: true);
            m_Input_NorthButton = m_Input.FindAction("NorthButton", throwIfNotFound: true);
            m_Input_SouthButton = m_Input.FindAction("SouthButton", throwIfNotFound: true);
            m_Input_DPad = m_Input.FindAction("DPad", throwIfNotFound: true);
            m_Input_Joystick1 = m_Input.FindAction("Joystick1", throwIfNotFound: true);
            m_Input_Joystick2 = m_Input.FindAction("Joystick2", throwIfNotFound: true);
            m_Input_JoystickButton1 = m_Input.FindAction("JoystickButton1", throwIfNotFound: true);
            m_Input_JoystickButton2 = m_Input.FindAction("JoystickButton2", throwIfNotFound: true);
            m_Input_Keyboard = m_Input.FindAction("Keyboard", throwIfNotFound: true);
            m_Input_Mouse = m_Input.FindAction("Mouse", throwIfNotFound: true);
            m_Input_Pointer = m_Input.FindAction("Pointer", throwIfNotFound: true);
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

        // Input
        private readonly InputActionMap m_Input;
        private List<IInputActions> m_InputActionsCallbackInterfaces = new List<IInputActions>();
        private readonly InputAction m_Input_LeftTrigger;
        private readonly InputAction m_Input_RightTrigger;
        private readonly InputAction m_Input_LeftButton;
        private readonly InputAction m_Input_RightButton;
        private readonly InputAction m_Input_SelectButton;
        private readonly InputAction m_Input_StartButton;
        private readonly InputAction m_Input_WestButton;
        private readonly InputAction m_Input_EastButton;
        private readonly InputAction m_Input_NorthButton;
        private readonly InputAction m_Input_SouthButton;
        private readonly InputAction m_Input_DPad;
        private readonly InputAction m_Input_Joystick1;
        private readonly InputAction m_Input_Joystick2;
        private readonly InputAction m_Input_JoystickButton1;
        private readonly InputAction m_Input_JoystickButton2;
        private readonly InputAction m_Input_Keyboard;
        private readonly InputAction m_Input_Mouse;
        private readonly InputAction m_Input_Pointer;
        public struct InputActions
        {
            private @GameController m_Wrapper;
            public InputActions(@GameController wrapper) { m_Wrapper = wrapper; }
            public InputAction @LeftTrigger => m_Wrapper.m_Input_LeftTrigger;
            public InputAction @RightTrigger => m_Wrapper.m_Input_RightTrigger;
            public InputAction @LeftButton => m_Wrapper.m_Input_LeftButton;
            public InputAction @RightButton => m_Wrapper.m_Input_RightButton;
            public InputAction @SelectButton => m_Wrapper.m_Input_SelectButton;
            public InputAction @StartButton => m_Wrapper.m_Input_StartButton;
            public InputAction @WestButton => m_Wrapper.m_Input_WestButton;
            public InputAction @EastButton => m_Wrapper.m_Input_EastButton;
            public InputAction @NorthButton => m_Wrapper.m_Input_NorthButton;
            public InputAction @SouthButton => m_Wrapper.m_Input_SouthButton;
            public InputAction @DPad => m_Wrapper.m_Input_DPad;
            public InputAction @Joystick1 => m_Wrapper.m_Input_Joystick1;
            public InputAction @Joystick2 => m_Wrapper.m_Input_Joystick2;
            public InputAction @JoystickButton1 => m_Wrapper.m_Input_JoystickButton1;
            public InputAction @JoystickButton2 => m_Wrapper.m_Input_JoystickButton2;
            public InputAction @Keyboard => m_Wrapper.m_Input_Keyboard;
            public InputAction @Mouse => m_Wrapper.m_Input_Mouse;
            public InputAction @Pointer => m_Wrapper.m_Input_Pointer;
            public InputActionMap Get() { return m_Wrapper.m_Input; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(InputActions set) { return set.Get(); }
            public void AddCallbacks(IInputActions instance)
            {
                if (instance == null || m_Wrapper.m_InputActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_InputActionsCallbackInterfaces.Add(instance);
                @LeftTrigger.started += instance.OnLeftTrigger;
                @LeftTrigger.performed += instance.OnLeftTrigger;
                @LeftTrigger.canceled += instance.OnLeftTrigger;
                @RightTrigger.started += instance.OnRightTrigger;
                @RightTrigger.performed += instance.OnRightTrigger;
                @RightTrigger.canceled += instance.OnRightTrigger;
                @LeftButton.started += instance.OnLeftButton;
                @LeftButton.performed += instance.OnLeftButton;
                @LeftButton.canceled += instance.OnLeftButton;
                @RightButton.started += instance.OnRightButton;
                @RightButton.performed += instance.OnRightButton;
                @RightButton.canceled += instance.OnRightButton;
                @SelectButton.started += instance.OnSelectButton;
                @SelectButton.performed += instance.OnSelectButton;
                @SelectButton.canceled += instance.OnSelectButton;
                @StartButton.started += instance.OnStartButton;
                @StartButton.performed += instance.OnStartButton;
                @StartButton.canceled += instance.OnStartButton;
                @WestButton.started += instance.OnWestButton;
                @WestButton.performed += instance.OnWestButton;
                @WestButton.canceled += instance.OnWestButton;
                @EastButton.started += instance.OnEastButton;
                @EastButton.performed += instance.OnEastButton;
                @EastButton.canceled += instance.OnEastButton;
                @NorthButton.started += instance.OnNorthButton;
                @NorthButton.performed += instance.OnNorthButton;
                @NorthButton.canceled += instance.OnNorthButton;
                @SouthButton.started += instance.OnSouthButton;
                @SouthButton.performed += instance.OnSouthButton;
                @SouthButton.canceled += instance.OnSouthButton;
                @DPad.started += instance.OnDPad;
                @DPad.performed += instance.OnDPad;
                @DPad.canceled += instance.OnDPad;
                @Joystick1.started += instance.OnJoystick1;
                @Joystick1.performed += instance.OnJoystick1;
                @Joystick1.canceled += instance.OnJoystick1;
                @Joystick2.started += instance.OnJoystick2;
                @Joystick2.performed += instance.OnJoystick2;
                @Joystick2.canceled += instance.OnJoystick2;
                @JoystickButton1.started += instance.OnJoystickButton1;
                @JoystickButton1.performed += instance.OnJoystickButton1;
                @JoystickButton1.canceled += instance.OnJoystickButton1;
                @JoystickButton2.started += instance.OnJoystickButton2;
                @JoystickButton2.performed += instance.OnJoystickButton2;
                @JoystickButton2.canceled += instance.OnJoystickButton2;
                @Keyboard.started += instance.OnKeyboard;
                @Keyboard.performed += instance.OnKeyboard;
                @Keyboard.canceled += instance.OnKeyboard;
                @Mouse.started += instance.OnMouse;
                @Mouse.performed += instance.OnMouse;
                @Mouse.canceled += instance.OnMouse;
                @Pointer.started += instance.OnPointer;
                @Pointer.performed += instance.OnPointer;
                @Pointer.canceled += instance.OnPointer;
            }

            private void UnregisterCallbacks(IInputActions instance)
            {
                @LeftTrigger.started -= instance.OnLeftTrigger;
                @LeftTrigger.performed -= instance.OnLeftTrigger;
                @LeftTrigger.canceled -= instance.OnLeftTrigger;
                @RightTrigger.started -= instance.OnRightTrigger;
                @RightTrigger.performed -= instance.OnRightTrigger;
                @RightTrigger.canceled -= instance.OnRightTrigger;
                @LeftButton.started -= instance.OnLeftButton;
                @LeftButton.performed -= instance.OnLeftButton;
                @LeftButton.canceled -= instance.OnLeftButton;
                @RightButton.started -= instance.OnRightButton;
                @RightButton.performed -= instance.OnRightButton;
                @RightButton.canceled -= instance.OnRightButton;
                @SelectButton.started -= instance.OnSelectButton;
                @SelectButton.performed -= instance.OnSelectButton;
                @SelectButton.canceled -= instance.OnSelectButton;
                @StartButton.started -= instance.OnStartButton;
                @StartButton.performed -= instance.OnStartButton;
                @StartButton.canceled -= instance.OnStartButton;
                @WestButton.started -= instance.OnWestButton;
                @WestButton.performed -= instance.OnWestButton;
                @WestButton.canceled -= instance.OnWestButton;
                @EastButton.started -= instance.OnEastButton;
                @EastButton.performed -= instance.OnEastButton;
                @EastButton.canceled -= instance.OnEastButton;
                @NorthButton.started -= instance.OnNorthButton;
                @NorthButton.performed -= instance.OnNorthButton;
                @NorthButton.canceled -= instance.OnNorthButton;
                @SouthButton.started -= instance.OnSouthButton;
                @SouthButton.performed -= instance.OnSouthButton;
                @SouthButton.canceled -= instance.OnSouthButton;
                @DPad.started -= instance.OnDPad;
                @DPad.performed -= instance.OnDPad;
                @DPad.canceled -= instance.OnDPad;
                @Joystick1.started -= instance.OnJoystick1;
                @Joystick1.performed -= instance.OnJoystick1;
                @Joystick1.canceled -= instance.OnJoystick1;
                @Joystick2.started -= instance.OnJoystick2;
                @Joystick2.performed -= instance.OnJoystick2;
                @Joystick2.canceled -= instance.OnJoystick2;
                @JoystickButton1.started -= instance.OnJoystickButton1;
                @JoystickButton1.performed -= instance.OnJoystickButton1;
                @JoystickButton1.canceled -= instance.OnJoystickButton1;
                @JoystickButton2.started -= instance.OnJoystickButton2;
                @JoystickButton2.performed -= instance.OnJoystickButton2;
                @JoystickButton2.canceled -= instance.OnJoystickButton2;
                @Keyboard.started -= instance.OnKeyboard;
                @Keyboard.performed -= instance.OnKeyboard;
                @Keyboard.canceled -= instance.OnKeyboard;
                @Mouse.started -= instance.OnMouse;
                @Mouse.performed -= instance.OnMouse;
                @Mouse.canceled -= instance.OnMouse;
                @Pointer.started -= instance.OnPointer;
                @Pointer.performed -= instance.OnPointer;
                @Pointer.canceled -= instance.OnPointer;
            }

            public void RemoveCallbacks(IInputActions instance)
            {
                if (m_Wrapper.m_InputActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IInputActions instance)
            {
                foreach (var item in m_Wrapper.m_InputActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_InputActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public InputActions @Input => new InputActions(this);
        public interface IInputActions
        {
            void OnLeftTrigger(InputAction.CallbackContext context);
            void OnRightTrigger(InputAction.CallbackContext context);
            void OnLeftButton(InputAction.CallbackContext context);
            void OnRightButton(InputAction.CallbackContext context);
            void OnSelectButton(InputAction.CallbackContext context);
            void OnStartButton(InputAction.CallbackContext context);
            void OnWestButton(InputAction.CallbackContext context);
            void OnEastButton(InputAction.CallbackContext context);
            void OnNorthButton(InputAction.CallbackContext context);
            void OnSouthButton(InputAction.CallbackContext context);
            void OnDPad(InputAction.CallbackContext context);
            void OnJoystick1(InputAction.CallbackContext context);
            void OnJoystick2(InputAction.CallbackContext context);
            void OnJoystickButton1(InputAction.CallbackContext context);
            void OnJoystickButton2(InputAction.CallbackContext context);
            void OnKeyboard(InputAction.CallbackContext context);
            void OnMouse(InputAction.CallbackContext context);
            void OnPointer(InputAction.CallbackContext context);
        }
    }
}