using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MultiplePagesHandler : MonoBehaviour
{
    [SerializeField] private MultiPageUI multiPageUI;
    [SerializeField] private TextMeshProUGUI page1TMP;
    [SerializeField] private TextMeshProUGUI page2TMP;
    [SerializeField] private TextMeshProUGUI page3TMP;
    [SerializeField] private TextMeshProUGUI page4TMP;
    [SerializeField] private TextMeshProUGUI page5TMP;
    [TextArea(10, 20)] public string page1Text = "some text for page 1";
    [TextArea(10, 20)] public string page2Text = "some text for page 2";
    [TextArea(10, 20)] public string page3Text = "some text for page 3";
    [TextArea(10, 20)] public string page4Text = "some text for page 4";
    [TextArea(10, 20)] public string page5Text = "some text for page 5";
    //private AudioSource audioSource;
    //[SerializeField] private AudioClip changePageSound;
    //[SerializeField] private AudioClip closeSound;


    // Start is called before the first frame update
    //void Start()
    //{
    //    audioSource = GetComponent<AudioSource>();
    //}

    public void Initiate()
    {
        page1TMP.text = page1Text;
        page2TMP.text = page2Text;
        page3TMP.text = page3Text;
        page4TMP.text = page4Text;
        page5TMP.text = page5Text;
        multiPageUI.Setup();
    }


}
