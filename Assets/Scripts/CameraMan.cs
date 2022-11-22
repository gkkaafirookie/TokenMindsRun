using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class CameraMan : Singleton<CameraMan>
{
   

    [SerializeField]
    CameraAnglePreset m_CameraAnglePreset = CameraAnglePreset.Behind;

    [SerializeField]
    Vector3 m_Offset;

    [SerializeField]
    Vector3 m_LookAtOffset;

    [SerializeField]
    bool m_LockCameraPosition;

    [SerializeField]
    bool m_SmoothCameraFollow;

    [SerializeField]
    float m_SmoothCameraFollowStrength = 10.0f;

    enum CameraAnglePreset
    {
        Behind,
        Overhead,
        Side,
        FirstPerson,
        Custom,
    }

    Vector3[] m_PresetOffsets = new Vector3[]
    {
            new Vector3(0.0f, 5.0f, -9.0f), // Behind
            new Vector3(0.0f, 9.0f, -5.0f), // Overhead
            new Vector3(5.0f, 5.0f, -8.0f), // Side
            new Vector3(0.0f, 1.0f, 0.0f),  // FirstPerson
            Vector3.zero                    // Custom
    };

    Vector3[] m_PresetLookAtOffsets = new Vector3[]
    {
            new Vector3(0.0f, 2.0f, 6.0f),  // Behind
            new Vector3(0.0f, 0.0f, 4.0f),  // Overhead
            new Vector3(-0.5f, 1.0f, 2.0f), // Side
            new Vector4(0.0f, 1.0f, 2.0f),  // FirstPerson
            Vector3.zero                    // Custom
    };

    bool[] m_PresetLockCameraPosition = new bool[]
    {
            false, // Behind
            false, // Overhead
            true,  // Side
            false, // FirstPerson
            false  // Custom
    };

    Vector3 m_PrevLookAtOffset;

    static readonly Vector3 k_CenteredScale = new Vector3(0.0f, 1.0f, 1.0f);


    /// <summary>
    /// Reset the camera to its starting position relative
    /// to the player.
    /// </summary>
    public void ResetCamera()
    {
        SetCameraPositionAndOrientation(false);
    }

    Vector3 GetCameraOffset()
    {
        return m_PresetOffsets[(int)m_CameraAnglePreset] + m_Offset;
    }

    Vector3 GetCameraLookAtOffset()
    {
        return m_PresetLookAtOffsets[(int)m_CameraAnglePreset] + m_LookAtOffset;
    }

    bool GetCameraLockStatus()
    {
        if (m_LockCameraPosition)
        {
            return true;
        }

        return m_PresetLockCameraPosition[(int)m_CameraAnglePreset];
    }

    Vector3 GetPlayerPosition()
    {
        Vector3 playerPosition = Vector3.up;
        if (PlayerHandler.Instance != null)
        {
            playerPosition = PlayerHandler.Instance.GetPlayerTop();
        }

        if (GetCameraLockStatus())
        {
            playerPosition = Vector3.Scale(playerPosition, k_CenteredScale);
        }

        return playerPosition;
    }

    void LateUpdate()
    {
        SetCameraPositionAndOrientation(m_SmoothCameraFollow);
    }

    void SetCameraPositionAndOrientation(bool smoothCameraFollow)
    {
        Vector3 playerPosition = GetPlayerPosition();

        Vector3 offset = playerPosition + GetCameraOffset();
        Vector3 lookAtOffset = playerPosition + GetCameraLookAtOffset();

        if (smoothCameraFollow)
        {
            float lerpAmound = Time.deltaTime * m_SmoothCameraFollowStrength;

            transform.position = Vector3.Lerp(transform.position, offset, lerpAmound);
            transform.LookAt(Vector3.Lerp(transform.position + transform.forward, lookAtOffset, lerpAmound));

            transform.position = new Vector3(transform.position.x, transform.position.y, offset.z);
        }
        else
        {
            transform.position = playerPosition + GetCameraOffset();
            transform.LookAt(lookAtOffset);
        }
    }
}

