using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SwitchToPauseCam : MonoBehaviour
{
    private CinemachineVirtualCamera virtualCamera;
    [SerializeField]
    private int priorityBoostAmount = 14;
    [SerializeField]
    private int inactivePriority = 7;

    private void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    public void PauseCam()
    {
        virtualCamera.Priority = priorityBoostAmount;
    }

    public void UnpauseCam()
    {
        virtualCamera.Priority = inactivePriority;
    }
}
