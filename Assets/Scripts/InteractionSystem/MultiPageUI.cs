using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

public class MultiPageUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI page1Text;
    [SerializeField] private TextMeshProUGUI page2Text;
    [SerializeField] private TextMeshProUGUI page3Text;
    [SerializeField] private TextMeshProUGUI page4Text;
    [SerializeField] private TextMeshProUGUI page5Text;
    private AudioSource audioSource;
    [SerializeField] private AudioClip turnPageSound;
    [SerializeField] private AudioClip closeSound;
    [SerializeField] private GameObject screens;
    [SerializeField] private SwitchToPauseCam switchToPauseCam;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        screens.SetActive(false);
        page1Text.enabled = false;
        page2Text.enabled = false;
        page3Text.enabled = false;
        page4Text.enabled = false;
        page5Text.enabled = false;
    }
    public bool IsDisplayed = false;
    public void Setup()
    {
        IsDisplayed = true;
        screens.SetActive(true);
        Cursor.visible = true;
        print("");
    }
    
    public void button1Click()
    {
        page1Text.enabled = true;
        page2Text.enabled = false;
        page3Text.enabled = false;
        page4Text.enabled = false;
        page5Text.enabled = false;
        audioSource.PlayOneShot(turnPageSound);
    }
    public void button2Click()
    {
        page1Text.enabled = false;
        page2Text.enabled = true;
        page3Text.enabled = false;
        page4Text.enabled = false;
        page5Text.enabled = false;
        audioSource.PlayOneShot(turnPageSound);
    }
    public void button3Click()
    {
        page1Text.enabled = false;
        page2Text.enabled = false;
        page3Text.enabled = true;
        page4Text.enabled = false;
        page5Text.enabled = false;
        audioSource.PlayOneShot(turnPageSound);
    }
    public void button4Click()
    {
        page1Text.enabled = false;
        page2Text.enabled = false;
        page3Text.enabled = false;
        page4Text.enabled = true;
        page5Text.enabled = false;
        audioSource.PlayOneShot(turnPageSound);
    }
    public void button5Click()
    {
        page1Text.enabled = false;
        page2Text.enabled = false;
        page3Text.enabled = false;
        page4Text.enabled = false;
        page5Text.enabled = true;
        audioSource.PlayOneShot(turnPageSound);
    }
    public void Close()
    {
        IsDisplayed = false;
        screens.SetActive(false);
        Cursor.visible = false;
        audioSource.PlayOneShot(closeSound);
    }
}
