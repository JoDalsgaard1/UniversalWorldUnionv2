using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class PauseGame : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu = null;      // If you want some UI to show while paused
    private AudioSource audioSource;
    bool isPaused;
    [SerializeField] private AudioClip pauseSound;
    [SerializeField] private AudioClip unpauseSound;
    [SerializeField] private SwitchToPauseCam switchToPauseCam;

    private void Start()
    {
        pauseMenu.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    public void OnPause()
    {
        isPaused = !isPaused;
        pauseMenu.SetActive(isPaused);
        print("Pausing " + isPaused);
        Time.timeScale = isPaused ? 0 : 1;
        AudioListener.pause = isPaused ? true : false;
        if (isPaused)
        {
            switchToPauseCam.PauseCam();
            Cursor.visible = true;
            audioSource.ignoreListenerPause = true;
            audioSource.PlayOneShot(pauseSound);
        }
        if (!isPaused)
        {
            switchToPauseCam.UnpauseCam();
            Cursor.visible = false;
            audioSource.ignoreListenerPause = false;
            audioSource.PlayOneShot(unpauseSound);
        }
    }
}
