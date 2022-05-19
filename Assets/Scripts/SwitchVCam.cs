using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class SwitchVCam : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;
    [SerializeField]
    private int priorityBoostAmount = 10;
    private InputAction aimAction;
    private CinemachineVirtualCamera virtualCamera;


    private void Awake()
    {
        aimAction = playerInput.actions["Aim"];
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    //private void OnEnable()
    //{
    //    aimAction.performed += _ => StartAim();
    //    aimAction.canceled += _ => CancelAim();
    //}

    //private void OnDisable()
    //{
    //    aimAction.performed -= _ => StartAim();
    //    aimAction.canceled -= _ => CancelAim();
    //}

    public bool CanAim = false;

    public void ZoomIn()
    {
        if (CanAim)
        {
            virtualCamera.Priority += priorityBoostAmount;
            Debug.Log("trying to zoom in");
        }
    }
    public void ZoomOut()
        {
            virtualCamera.Priority -= priorityBoostAmount;
            Debug.Log("trying to zoom out");
        }

    //private void CancelAim()
    //{
    //    virtualCamera.Priority -= priorityBoostAmount;
    //}
}
