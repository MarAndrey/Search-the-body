using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDisplay : MonoBehaviour
{

    [SerializeField] private GameObject _mainDisplay;
    [SerializeField] private GameObject _exit;
    [SerializeField] private GameObject _settings;

    void Update()
    {
        OpenMainDisplay();
        MouseLocked();
    }

    public void OpenExitWindow()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _exit.SetActive(true);
        }
    }

    public void OnClickExit()
    { 
        _exit.SetActive(true);
    }

    public void OnClickResume()
    {
        _mainDisplay.SetActive(false);
    }

    public void OnClickSettings()
    {
        _settings.SetActive(true);
        _mainDisplay.SetActive(false);
    }

    void OpenMainDisplay()
    {
        if (_mainDisplay.activeSelf == false & Input.GetKeyDown(KeyCode.Escape))
        {
            _mainDisplay.SetActive(true);
        }
    }

    void MouseLocked()
    {
        if (_settings.activeSelf == true || _mainDisplay.activeSelf == true || _exit.activeSelf == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
        else 
        {
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
        }
    }
}
