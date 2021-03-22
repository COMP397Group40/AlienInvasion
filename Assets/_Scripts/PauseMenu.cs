using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public bool isPaused = false;
    public PlayerBehaviour player;
    public SceneDataSO sceneData;
    private void Start()
    {
        player = FindObjectOfType<PlayerBehaviour>();
        pauseMenuUI.SetActive(false);
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

    public void OnLoadButtonPressed()
    {
        player.controller.enabled = false;
        player.transform.position = sceneData.playerPosition;
        player.transform.rotation = sceneData.playerRotation;
        player.controller.enabled = true;
        player.health = sceneData.playerHealth;
        player.healthBar.SetHealth(sceneData.playerHealth);
    }

    public void OnSaveButtonPressed()
    {
        sceneData.playerPosition = player.transform.position;
        sceneData.playerHealth = player.health;
        sceneData.playerRotation = player.transform.rotation;
        Debug.Log("saved");
    }

}
