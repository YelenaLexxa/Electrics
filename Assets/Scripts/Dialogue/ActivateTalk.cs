using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTalk : MonoBehaviour
{

    public GameObject talkButton;

    public void Start() 
    {
        talkButton.SetActive(false);
    }
    
    public void OnTriggerEnter(Collider col) 
    {
        if (col.gameObject.name == "Player")
        {
            talkButton.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider col) 
    {
        if (col.gameObject.name == "Player")
        {
            talkButton.SetActive(false);
        }
    }

}
