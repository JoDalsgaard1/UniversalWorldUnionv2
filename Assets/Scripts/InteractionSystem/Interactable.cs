using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    [SerializeField] private bool isReadable = true;
    [SerializeField] private bool hasMultiplePages = false;
    [SerializeField] private bool hasAnimation = false;
    [SerializeField] private bool isSceneTransport = false;
    [SerializeField] private string sceneName = "LVL-YIXIN";
    public string enterText = "Open door";
    [SerializeField] private string exitText = "I am a non-interactive door";
    [TextArea(10,20)] public string interactText = "Opening door";
    [SerializeField] private Sprite interactImage;
    private Animator animator;
    private bool hasBeenInteractedWith = false;
    private AudioSource audioSource;
    [SerializeField] private AudioClip interactSound;
    [SerializeField] private AudioClip endInteractSound;

    public Vector3 objectPos;
    [SerializeField] private PopupUI popupUI;
    [SerializeField] private InteractionPromptUI interactionPromptUI;
    [SerializeField] private MultiplePagesHandler multiplePagesHandler;
    [SerializeField] private MultiPageUI multiPageUI;

    // Start is called before the first frame update
    void Start()
    {
        objectPos = transform.position;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
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
        if (other.GetComponent<InteractionExample>() != null && other.GetComponent<InteractionExample>().currentNearestObject == this)
        {
            if (popupUI.IsDisplayed)
            {
                popupUI.Close();
            }
            if (multiPageUI.IsDisplayed)
            {
                multiPageUI.Close();
            }
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
            audioSource.PlayOneShot(interactSound);
        }
        if (hasMultiplePages == true)
        {
            multiplePagesHandler.Initiate();
            audioSource.PlayOneShot(interactSound);
            interactionPromptUI.Close();
        }
        if (isSceneTransport == true)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
        if (hasAnimation == true && hasBeenInteractedWith == false)
        {
            animator.SetTrigger("Interact");
            hasBeenInteractedWith = true;
            audioSource.PlayOneShot(interactSound);
        }
    }
}
