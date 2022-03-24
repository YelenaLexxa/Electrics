using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoHome : MonoBehaviour
{

    public void OnTriggerEnter(Collider col) 
    {
        if (col.gameObject.name == "Player") 
        {
            SceneManager.LoadScene("SpawnRoom");
        }
    }

}
