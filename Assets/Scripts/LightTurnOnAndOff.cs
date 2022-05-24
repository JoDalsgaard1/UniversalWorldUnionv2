using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTurnOnAndOff : MonoBehaviour
{
    public Component[] lights;
    
    // Start is called before the first frame update
    void Start()
    {
        lights = GetComponentsInChildren<Light>(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LightOn()
    {
        foreach (Light mylight in lights)
            mylight.enabled = true;
        Debug.Log(lights);
    }

    public void LightOff()
    {
        foreach (Light mylight in lights)
            mylight.enabled = false;
        Debug.Log(lights);
    }
}
