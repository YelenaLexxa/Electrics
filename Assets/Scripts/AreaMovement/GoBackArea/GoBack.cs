using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBack : MonoBehaviour
{

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            SceneManager.LoadScene("SafeArea01");
        }
    }

}
