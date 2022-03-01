using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextArea : MonoBehaviour
{

    public void OnTriggerEnter(Collider col) 
    {
        SceneManager.LoadScene("SampleScene");
    }

}
