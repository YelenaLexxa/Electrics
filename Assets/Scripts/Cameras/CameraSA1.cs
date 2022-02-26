using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSA1 : MonoBehaviour
{
    public GameObject Cam1;
    public GameObject Cam2;
    public GameObject Cam3;
    public GameObject Cam4;
    public GameObject Cam5;

    private bool isCam1;
    private bool isCam2;
    private bool isCam3;
    private bool isCam4;
    private bool isCam5;

    public void Start()
    {
        Cam1.SetActive(true);
        Cam2.SetActive(false);
        Cam3.SetActive(false);
        Cam4.SetActive(false);
        Cam5.SetActive(false);

        isCam1 = true;
        isCam2 = false;
        isCam3 = false;
        isCam4 = false;
        isCam5 = false;
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            if (isCam1 == true)
            {
                Cam1.SetActive(true);
                Cam2.SetActive(false);
                Cam3.SetActive(false);
                Cam4.SetActive(false);
                Cam5.SetActive(false);

                isCam1 = false;
                isCam2 = true;
                isCam3 = false;
                isCam4 = false;
                isCam5 = false;

            }
            else if (isCam2 == true)
            {
                Cam1.SetActive(false);
                Cam2.SetActive(true);
                Cam3.SetActive(false);
                Cam4.SetActive(false);
                Cam5.SetActive(false);
            }
            else if (isCam3 == true)
            {
                Cam1.SetActive(false);
                Cam2.SetActive(false);
                Cam3.SetActive(true);
                Cam4.SetActive(false);
                Cam5.SetActive(false);
            }
            else if (isCam4 == true)
            {
                Cam1.SetActive(false);
                Cam2.SetActive(false);
                Cam3.SetActive(false);
                Cam4.SetActive(true);
                Cam5.SetActive(false);
            }
            else if (isCam5 == true)
            {
                Cam1.SetActive(false);
                Cam2.SetActive(false);
                Cam3.SetActive(false);
                Cam4.SetActive(false);
                Cam5.SetActive(true);
            }
        }
    }

}
