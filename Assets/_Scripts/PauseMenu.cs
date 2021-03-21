using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public bool isPaused;
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    isPaused = !isPaused;
        //}
        //if (isPaused)
        //{
        //    ActivateMenu();
        //} else
        //{
        //    DeactivateMenu();
        //}
    }
    void ToggleControlPanel()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            ActivateMenu();
        }
        else
        {
            DeactivateMenu();
        }
    }
    public void OnControlButtonPressed()
    {
        ToggleControlPanel();
    }
    void ActivateMenu()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        pauseMenuUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void DeactivateMenu()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);
        isPaused = false;
    }

}
