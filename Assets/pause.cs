using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    public static bool isGamePaused = false;

    [SerializeField] GameObject Pause_Menu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                pauseMenu();
            }
        }
    }

    public void ResumeGame()
	{
        Pause_Menu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    void pauseMenu() 
    {
        Pause_Menu.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void OptionMenu()
    {
        SceneManager.LoadScene("OptionsMenu");
    }

    public void LoadMenu() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame() 
    {
        SceneManager.LoadScene("StartMenu");
    }
}
