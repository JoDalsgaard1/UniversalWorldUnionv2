using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionPromptUI : MonoBehaviour
{
    private Camera mainCam;
    [SerializeField] private TextMeshProUGUI _promptText;
    [SerializeField] private GameObject uiPanel;
    //Vector3 panelPos;
    
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
        uiPanel.SetActive(false);
        //panelPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var rotation = mainCam.transform.rotation;
        transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up);
    }

    public bool IsDisplayed = false;

    public void SetUp(string promptText)
    {
        _promptText.text = promptText;
        uiPanel.SetActive(true);
        //panelPos.x = newPos.x;
        //panelPos.y = newPos.y;
        //transform.position = panelPos;
        IsDisplayed = true;
        //Debug.Log(transform.position);
    }

    public void Close()
    {
        uiPanel.SetActive(false);
        IsDisplayed = false;
    }
}
