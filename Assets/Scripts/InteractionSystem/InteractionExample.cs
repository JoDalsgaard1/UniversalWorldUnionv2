using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionExample : MonoBehaviour
{
    public Interactable currentNearestObject;
    [SerializeField] private InteractionPromptUI interactionPromptUI;
    [SerializeField] private PopupUI popupUI;
    [SerializeField] private SwitchVCam switchVCam;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentNearestObject != null)
        {
            if (!popupUI.IsDisplayed)
            {
                interactionPromptUI.SetUp(currentNearestObject.enterText);
                switchVCam.CanAim = true;
            }
        }
        if (currentNearestObject == null)
        {
            if (interactionPromptUI.IsDisplayed)
            {
                interactionPromptUI.Close();
            }
            //popupUI.Close();
            switchVCam.ZoomOut();
            switchVCam.CanAim = false;
        }
    }

    public void OnInteract()
    {
        print("Pressing E");

        //Interact with object
        if(currentNearestObject != null && popupUI.IsDisplayed == false)
        {
            currentNearestObject.Interact();
            switchVCam.ZoomIn();
        }
        else
        {
            popupUI.Close();
            switchVCam.ZoomOut();
        }
    }
}
