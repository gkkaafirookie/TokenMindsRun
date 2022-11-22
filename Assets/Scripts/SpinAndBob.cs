using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinAndBob : MonoBehaviour
{
    public bool UsePositionBasedOffset = true;
    public float PositionBasedScale = 2.0f;

    public bool Bob = true;
    public float BobSpeed = 5.0f;
    public float BobHeight = 0.2f;

    public bool Spin = true;
    public float SpinSpeed = 180.0f;

    Vector3 m_StartPosition;
    Quaternion m_StartRotation;

    public void OnEnable()
    {
        Setup();
    }

    public void Setup()
    {
        m_StartPosition = transform.position;
        m_StartRotation = transform.rotation;
    }

    public void Update()
    {
        float offset = (UsePositionBasedOffset) ? m_StartPosition.z * PositionBasedScale + Time.time : Time.time;

        if (Bob)
        {
            transform.position = m_StartPosition + Vector3.up * Mathf.Sin(offset * BobSpeed) * BobHeight;
        }

        if (Spin)
        {
            transform.rotation = m_StartRotation * Quaternion.AngleAxis(offset * SpinSpeed, Vector3.up);
        }
    }
}
