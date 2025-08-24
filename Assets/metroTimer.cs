using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;
using System;
using System.Windows.Forms;

public class metroTimer : MonoBehaviour
{
    public float timeValue = 300;
    public TextMeshProUGUI timeText;
    [DllImport("user32.dll")]
    private static extern IntPtr GetActiveWindow();

    [DllImport("user32.dll")]
    static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    const int SW_HIDE = 0;

    PauseMenu pauseMenu;

    void Start()
    {
        pauseMenu = GetComponent<PauseMenu>();
    }

    void Update()
    {
        if (timeValue > 0) 
        {
            if (pauseMenu.GameIsPaused == false)
            { timeValue -= Time.deltaTime; }
        }
        else
        {
            timeValue = 0;
            AudioListener.volume = 0;
            var hwnd = GetActiveWindow();
            ShowWindow(hwnd, SW_HIDE);
            UnityEngine.Cursor.lockState = CursorLockMode.None;
            UnityEngine.Cursor.visible = true;
            UnityEngine.Application.Quit();
            System.Windows.Forms.MessageBox.Show("ѕоезд прибыл на станцию.", "Ќ≈ ѕ–»—ЋќЌя“№—я", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        DisplayTime(timeValue);
 
    }

    void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }   
        
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
