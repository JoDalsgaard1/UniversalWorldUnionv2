using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionExample : MonoBehaviour
{
    public Interactable currentNearestObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnInteract()
    {
        print("Pressing E (or whatever you set it to)");

        //Interact with object
        if(currentNearestObject != null)
        {
            currentNearestObject.Interact();
        }
    }
}
