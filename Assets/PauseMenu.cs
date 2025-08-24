using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool GameIsPaused;

    public GameObject PauseMenuUI;
    public GameObject StartMenuUI;

    public GameObject Timer;

    public GameObject cam1;
    public GameObject cam2;

    void Start()
    {
        PauseMenuUI.SetActive(false);
        StartMenuUI.SetActive(true);
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        AudioListener.pause = true;
        Timer.SetActive(false);
        camera2();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        camera1();
        PauseMenuUI.SetActive(false);
        StartMenuUI.SetActive(false);
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        AudioListener.pause = false;
        Timer.SetActive(true);
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        AudioListener.pause = true;
        Timer.SetActive(false);
        camera2();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        camera1();
        PauseMenuUI.SetActive(false);
        StartMenuUI.SetActive(false);
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        AudioListener.pause = false;
        Timer.SetActive(true);
    }

    void camera1()
    {
        cam1.SetActive(true);
        cam2.SetActive(false);
    }

    void camera2()
    {
        cam2.SetActive(true);
        cam1.SetActive(false);
    }
}
