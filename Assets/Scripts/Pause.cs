using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject PauseMenu; /* The GameObject itself is called "PauseMenu" */

    bool pauseOn;

    void Start()
    {
        PauseMenu.SetActive(false);
        pauseOn = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pauseOn)
        {
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
            pauseOn = true;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && pauseOn)
        {
            Time.timeScale = 1;
            PauseMenu.SetActive(false);
            pauseOn = false;
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
        pauseOn = false;
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quiting Application");
    }

}