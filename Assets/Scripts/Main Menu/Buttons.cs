using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{

    public void Play() 
    {
        SceneManager.LoadScene("SpawnRoom");
    }

    public void Quit() 
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

}
