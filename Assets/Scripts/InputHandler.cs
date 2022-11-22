

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class InputHandler : MonoBehaviour
{
    [SerializeField]
    float m_InputSensitivity = 1.5f;

    bool m_HasInput;
    Vector3 m_InputPosition;
    Vector3 m_PreviousInputPosition;

    private PlayerHandler playerHandler;

  

    void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }
 
    void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }
    private void Start()
    {
        playerHandler = GetComponent<PlayerHandler>();
    }

    void Update()
    {
#if UNITY_EDITOR || UNITY_WEBGL || UNITY_STANDALONE
        HandleMouseInput();
#else
        HandleTouchInput();
#endif

        ProcessInput();
    }


    private void HandleMouseInput()
    {
        m_InputPosition = Mouse.current.position.ReadValue();

        if (Mouse.current.leftButton.isPressed)
        {
            if (!m_HasInput)
            {
                m_PreviousInputPosition = m_InputPosition;
            }
            m_HasInput = true;
        }
        else
        {
            m_HasInput = false;
        }
    }

    private void HandleTouchInput()
    {
        if (Touch.activeTouches.Count > 0)
        {
            m_InputPosition = Touch.activeTouches[0].screenPosition;

            if (!m_HasInput)
            {
                m_PreviousInputPosition = m_InputPosition;
            }

            m_HasInput = true;
        }
        else
        {
            m_HasInput = false;
        }
    }


    private void ProcessInput()
    {
        if (m_HasInput)
        {
            float normalizedDeltaPosition = (m_InputPosition.x - m_PreviousInputPosition.x) / Screen.width * m_InputSensitivity;
            playerHandler.SetDeltaPosition(normalizedDeltaPosition);
        }
        else
        {
            playerHandler.CancelMovement();
        }

        m_PreviousInputPosition = m_InputPosition;
    }

}

