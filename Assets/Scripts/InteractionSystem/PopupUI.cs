using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;

public class PopupUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI screenText;
    [SerializeField] private GameObject uiScreen;
    [SerializeField] private GameObject imageScreen;
    [SerializeField] private GameObject imageRenderer;
    private Image objectImage;
    private AudioSource audioSource;
    [SerializeField] private AudioClip closeSound;
    // Start is called before the first frame update
    void Start()
    {
        uiScreen.SetActive(false);
        imageScreen.SetActive(false);
        objectImage = imageRenderer.GetComponent<Image>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsDisplayed = false;
    public void SetUp(string objectText, Sprite interactImage)
    {
        screenText.text = objectText;
        objectImage.sprite = interactImage;
        uiScreen.SetActive(true);
        imageScreen.SetActive(true);
        //panelPos.x = newPos.x;
        //panelPos.y = newPos.y;
        //transform.position = panelPos;
        IsDisplayed = true;
        //Debug.Log(transform.position);
    }
    public void Close()
    {
        audioSource.PlayOneShot(closeSound);
        uiScreen.SetActive(false);
        imageScreen.SetActive(false);
        IsDisplayed = false;
    }
}

