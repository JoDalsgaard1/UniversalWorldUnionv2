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
    // Start is called before the first frame update
    void Start()
    {
        uiScreen.SetActive(false);
        objectImage = imageRenderer.GetComponent<Image>();
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
        uiScreen.SetActive(false);
        imageScreen.SetActive(false);
        IsDisplayed = false;
    }
}

