using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    void Start()
    {
        // Pause menu canvas initially is not active on screen
        pauseMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {   
        // Access pause menu when user presses escape key
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GameIsPaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    // Resume game
    public void Resume() 
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;    // Resumes game, sets time scale to normal
        GameIsPaused = false;
    }

    // Pause game
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;    // Pauses game, stops time scale
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
