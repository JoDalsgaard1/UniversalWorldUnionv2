using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    [SerializeField] private bool isReadable = true;
    [SerializeField] private bool hasAnimation = false;
    [SerializeField] private bool isSceneTransport = false;
    [SerializeField] private string sceneName = "LVL-YIXIN";
    public string enterText = "I am an interactive door";
    [SerializeField] private string exitText = "I am a non-interactive door";
    [SerializeField] private string interactText = "Opening door";
    [SerializeField] private Sprite interactImage;
    private Animator animator;
    private bool hasBeenInteractedWith = false;

    public Vector3 objectPos;
    [SerializeField] private PopupUI popupUI;
    [SerializeField] private InteractionPromptUI interactionPromptUI;

    // Start is called before the first frame update
    void Start()
    {
        objectPos = transform.position;
        animator = GetComponent<Animator>();
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
            popupUI.SetUp(interactText, interactImage);
            interactionPromptUI.Close();
            Debug.Log(interactText);
        }
        if (isSceneTransport == true)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }
        if (hasAnimation == true && hasBeenInteractedWith == false)
        {
            animator.SetTrigger("Interact");
            hasBeenInteractedWith = true;
        }
    }
}
