using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCon : MonoBehaviour
{
    [SerializeField]
    CinemachineFreeLook freeLookCamera;
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            freeLookCamera.m_XAxis.m_MaxSpeed = 400;
            freeLookCamera.m_YAxis.m_MaxSpeed = 5;
        }
        if (Input.GetMouseButtonUp(1))
        {
            freeLookCamera.m_XAxis.m_MaxSpeed = 0;
            freeLookCamera.m_YAxis.m_MaxSpeed = 0;
        }
    }
}