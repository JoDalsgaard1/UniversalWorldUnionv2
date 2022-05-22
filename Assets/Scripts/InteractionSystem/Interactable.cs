using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactable : MonoBehaviour
{
    [SerializeField] public bool isReadable = true;
    [SerializeField] public bool hasAnimation = false;
    [SerializeField] public bool isSceneTransport = false;
    [SerializeField] public string sceneName = "LVL-YIXIN";
    [SerializeField] public string enterText = "I am an interactive door";
    [SerializeField] public string exitText = "I am a non-interactive door";
    [SerializeField] public string interactText = "Opening door";

    public Vector3 objectPos;
    [SerializeField] private PopupUI popupUI;
    [SerializeField] private InteractionPromptUI interactionPromptUI;

    // Start is called before the first frame update
    void Start()
    {
        objectPos = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Add myself to the player
        if(other.GetComponent<InteractionExample>() != null)
        {
            Debug.Log(enterText);
            other.GetComponent<InteractionExample>().currentNearestObject = this;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<InteractionExample>() != null)
        {
            Debug.Log(exitText);
            other.GetComponent<InteractionExample>().currentNearestObject = null;
        }
    }

    public void Interact()
    {
        if (isReadable == true)
        {
            popupUI.SetUp(interactText);
            interactionPromptUI.Close();
            Debug.Log(interactText);
        }
        if (isSceneTransport == true)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }
    }
}
