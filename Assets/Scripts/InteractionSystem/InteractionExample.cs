using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionExample : MonoBehaviour
{
    public Interactable currentNearestObject;
    [SerializeField] private InteractionPromptUI interactionPromptUI;
    [SerializeField] private PopupUI popupUI;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentNearestObject != null)
        {
            if (!interactionPromptUI.IsDisplayed && !popupUI.IsDisplayed)
            {
                interactionPromptUI.SetUp(currentNearestObject.enterText);
            }
        }
        if (currentNearestObject == null)
        {
            if (interactionPromptUI.IsDisplayed)
            {
                interactionPromptUI.Close();
            }
        }
    }

    public void OnInteract()
    {
        print("Pressing E");

        //Interact with object
        if(currentNearestObject != null && popupUI.IsDisplayed == false)
        {
            currentNearestObject.Interact();
        }
        else
        {
            popupUI.Close();
        }
    }
}
