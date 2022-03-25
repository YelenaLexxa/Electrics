using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Electrics
{
    public class FindButtle : MonoBehaviour
    {

        [SerializeField] private PlayerFight playerFight;
        [SerializeField] private Arena arena;
        //[SerializeField] private Timer_Script timer_Script;
        [SerializeField] private Audio_Manager audio_Manager;
        

        public GameObject MainPanel;
        public GameObject FightManager;
        private bool _Arena;
        private bool _Arena_2;
        private bool _Arena_3;
        private bool _Arena_4;
        private bool _Arena_5;
        private bool _Arena_6;
        private bool _Arena_7;

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
                audio_Manager.Stop();

                if (!_Arena)
                {
                    _Arena = true;
                }
            }

            if (col.tag == "Arena_2")
            {
                MainPanel.SetActive(true);
                FightManager.SetActive(true);
                audio_Manager.Stop();
                if (!_Arena_2)
                {
                    _Arena_2 = true;
                }
            }

            if (col.tag == "Arena_3")
            {
                MainPanel.SetActive(true);
                FightManager.SetActive(true);
                audio_Manager.Stop();
                if (!_Arena_3)
                {
                    _Arena_3 = true;
                }
            }

            if (col.tag == "Arena_4")
            {
                MainPanel.SetActive(true);
                FightManager.SetActive(true);
                audio_Manager.Stop();
                if (!_Arena_4)
                {
                    _Arena_4 = true;
                }
            }

            if (col.tag == "Arena_5")
            {
                MainPanel.SetActive(true);
                FightManager.SetActive(true);
                audio_Manager.Stop();
                if (!_Arena_5)
                {
                    _Arena_5 = true;
                }
            }

            if (col.tag == "Arena_6")
            {
                MainPanel.SetActive(true);
                FightManager.SetActive(true);
                audio_Manager.Stop();
                if (!_Arena_6)
                {
                    _Arena_6 = true;
                }
            }


            if (col.tag == "Arena_7")
            {
                MainPanel.SetActive(true);
                FightManager.SetActive(true);
                audio_Manager.Stop();
                if (!_Arena_7)
                {
                    _Arena_7 = true;
                }
            }
        }

        public void Exit_Fight()
        {
            if (playerFight._winRound == true)
            {
                arena.ButtlePoints = arena.ButtlePoints + 2;
               
            }
            MainPanel.SetActive(false);
            //FightManager.SetActive(false);

            playerFight.RefreshButtle();
            playerFight._winRound = false;
            audio_Manager.Play();
        }
    }
}