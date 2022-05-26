using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{
    Button myButton;
    
    // Start is called before the first frame update
    void Start()
    {
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(ExitFunction);
    }

    // Update is called once per frame
    void ExitFunction()
    {
        Debug.Log("exit function");
        Application.Quit();
    }
}
