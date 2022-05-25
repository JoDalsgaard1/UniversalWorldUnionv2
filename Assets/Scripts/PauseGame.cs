using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseGame : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu = null;      // If you want some UI to show while paused

    bool isPaused;
    private PlayerInput playerInput;

    private void Start()
    {

    }

    public void OnPause()
    {
        isPaused = !isPaused;
        print("Pausing " + isPaused);
        Time.timeScale = isPaused ? 0 : 1;
        //pauseMenu.SetActive(isPaused);
    }
}
