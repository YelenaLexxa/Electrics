using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindButtle : MonoBehaviour
{
    public GameObject MainPanel;
    public GameObject FightManager;
    // Start is called before the first frame update
    void Start()
    {
        MainPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Arena")
        {
            MainPanel.SetActive(true);
            FightManager.SetActive(true);
        }
    }

    public void Exit_Fight()
    {
        MainPanel.SetActive(false);
        FightManager.SetActive(false);
    }
}