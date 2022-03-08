using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject PauseMenu; /* The GameObject itself is called "PauseMenu" */
    public GameObject PauseButton;

    bool pauseOn;

    void Start()
    {
        PauseButton.SetActive(true);
        PauseMenu.SetActive(false);
        pauseOn = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pauseOn)
        {
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
            PauseButton.SetActive(false);
            pauseOn = true;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && pauseOn)
        {
            Time.timeScale = 1;
            PauseMenu.SetActive(false);
            PauseButton.SetActive(true);
            pauseOn = false;
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
        PauseButton.SetActive(false);
        pauseOn = false;
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quiting Application");
    }

    public void OpenMenu()
    {
        Time.timeScale = 0;
        PauseMenu.SetActive(true);
        PauseButton.SetActive(false);
        pauseOn = true;
    }

}