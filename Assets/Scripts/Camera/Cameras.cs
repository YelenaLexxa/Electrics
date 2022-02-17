using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameras : MonoBehaviour
{
    public GameObject Cam1;
    public GameObject Cam2;

    private bool isCam1;

    public void Start() 
    {
        Cam1.SetActive(true);
        Cam2.SetActive(false);

        isCam1 = true;
    }

    public void OnTriggerEnter(Collider col) 
    {
        if (col.gameObject.name == "Player") 
        {
            if (isCam1 == true)
            {
                Cam1.SetActive(false);
                Cam2.SetActive(true);
                isCam1 = false;
            }
            else if (isCam1 == false) 
            {
                Cam1.SetActive(true);
                Cam2.SetActive(false);
                isCam1 = true;
            }
        }
    }

}
