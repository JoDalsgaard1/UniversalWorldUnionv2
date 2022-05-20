using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopupUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI screenText;
    [SerializeField] private GameObject uiScreen;
    // Start is called before the first frame update
    void Start()
    {
        uiScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsDisplayed = false;
    public void SetUp(string objectText)
    {
        screenText.text = objectText;
        uiScreen.SetActive(true);
        //panelPos.x = newPos.x;
        //panelPos.y = newPos.y;
        //transform.position = panelPos;
        IsDisplayed = true;
        //Debug.Log(transform.position);
    }
    public void Close()
    {
        uiScreen.SetActive(false);
        IsDisplayed = false;
    }
}

