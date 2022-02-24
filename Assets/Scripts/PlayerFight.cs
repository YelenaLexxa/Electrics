using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Electrics
{
    public class PlayerFight : MonoBehaviour
    {
        [SerializeField] private Arena arena;
        

        public Sprite[] BotsImages = new Sprite[5];
        public Sprite[] BotsHelthBarImages = new Sprite[5];

        public Button Bot_1;
        public Button Bot_2;

        public Image Bot_HB_1;
        public Image Bot_HB_2;

        public Slider Bot_Slider_1;
        public Slider Bot_Slider_2;

        public int currentBot_1 = 0;
        public int currentBot_2 = 1;

        public int changeIndex = 0;
        public int BotFightIndex;

        public GameObject CnahgePanel;

        public GameObject EarthBot_Actions_Panel;
        public GameObject FireBot_Actions_Panel;
        public GameObject GrassBot_Actions_Panel;
        public GameObject PlasmaBot_Actions_Panel;
        public GameObject WaterBot_Actions_Panel;

        public GameObject Item_Menu_1;
        public GameObject Item_Menu_2;
        public GameObject Item_Menu_3;


        public int Attack_Power_Bot_1 = 0;
        public int Attack_Power_Bot_2 = 0;

        public int Total_Attack_Power_Bot_1 = 0;
        public int Total_Attack_Power_Bot_2 = 0;

        private int[] HP_Bots = { 12, 8, 10, 14, 10 }; //EarthBot, FireBot, GrassBot, PlasmaBot, WaterBot

        public int current_Enemy = 7;

        public int health_bot_1;
        public int health_bot_2;



        // Start is called before the first frame update
        void Start()
        {
            SetUp();
        }

        public void SetUp()
        {
            CnahgePanel.SetActive(false);
            Bot_Slider_1.maxValue = HP_Bots[currentBot_1];
            Bot_Slider_2.maxValue = HP_Bots[currentBot_2];
            health_bot_1 = HP_Bots[currentBot_1];
            health_bot_2 = HP_Bots[currentBot_2];
            Attack_Power_Bot_1 = Random.Range(5, 8);
            Attack_Power_Bot_2 = Random.Range(5, 6);
        }

        // Update is called once per frame
        void Update()
        {
            PrepareBots();
        }
        public void UpdateHealth()
        {
            Bot_Slider_1.maxValue = HP_Bots[currentBot_1];
            Bot_Slider_2.maxValue = HP_Bots[currentBot_2];

            health_bot_1 = HP_Bots[currentBot_1];
            health_bot_2 = HP_Bots[currentBot_2];
        }
        public void chooseEarthBot()
        {
            if (changeIndex == 1)
            {
                currentBot_1 = 0;
            }
            if (changeIndex == 2)
            {
                currentBot_2 = 0;
            }

            changeIndex = 0;
            UpdateHealth();
            CnahgePanel.SetActive(false);
        }

        public void chooseFireBot()
        {
            if (changeIndex == 1)
            {
                currentBot_1 = 1;
            }
            if (changeIndex == 2)
            {
                currentBot_2 = 1;
            }
            changeIndex = 0;
            UpdateHealth();
            CnahgePanel.SetActive(false);
        }

        public void chooseGrassBot()
        {
            if (changeIndex == 1)
            {
                currentBot_1 = 2;
            }
            if (changeIndex == 2)
            {
                currentBot_2 = 2;
            }
            changeIndex = 0;
            UpdateHealth();
            CnahgePanel.SetActive(false);
        }

        public void choosePlasmaBot()
        {
            if (changeIndex == 1)
            {
                currentBot_1 = 3;
            }
            if (changeIndex == 2)
            {
                currentBot_2 = 3;
            }
            changeIndex = 0;
            UpdateHealth();
            CnahgePanel.SetActive(false);
        }

        public void chooseWaterBot()
        {
            if (changeIndex == 1)
            {
                currentBot_1 = 4;
            }
            if (changeIndex == 2)
            {
                currentBot_2 = 4;
            }
            changeIndex = 0;
            UpdateHealth();
            CnahgePanel.SetActive(false);
        }

        //public int Attack_Bots(int index)
        //{
        //    int EarthBot = Random.Range(1, 8);b


        //    int FireBot = Random.Range(3, 6);
        //    int GrassBot = Random.Range(2, 4);
        //    int PlasmaBot = Random.Range(1, 4);
        //    int WaterBot = Random.Range(2, 4);
        //    //int BossBot = Random.Range(5, 10);

        //    int[] Attack_Power = { EarthBot, FireBot, GrassBot, PlasmaBot, WaterBot };

        //    return Attack_Power[index];
        //}


        public int SetAttackPower(int indexBotPlayer, int indexBotEnemy)
        {
            int additionalDamage = 0;

            if (indexBotPlayer == 0) //EarthBot
            {
                if (indexBotEnemy == 3) //PlasmaBot
                {
                    additionalDamage = 2;
                }
            }

            if (indexBotPlayer == 1) //FireBot
            {
                if (indexBotEnemy == 0) //EarthBot
                {
                    additionalDamage = 2;
                }
            }

            if (indexBotPlayer == 2) //GrassBot
            {
                if (indexBotEnemy == 4) //WaterBot
                {
                    additionalDamage = 2;
                }
            }

            if (indexBotPlayer == 3) //PlasmaBot
            {
                if (indexBotEnemy == 2) //GrassBot
                {
                    additionalDamage = 2;
                }
            }

            if (indexBotPlayer == 4) //WaterBot
            {
                if (indexBotEnemy == 1) //FireBot
                {
                    additionalDamage = 2;
                }
            }

            return additionalDamage;
        }

        public void PrepareBots()
        {
            //setup Bots
            Bot_1.GetComponent<Image>().sprite = BotsImages[currentBot_1];
            Bot_2.GetComponent<Image>().sprite = BotsImages[currentBot_2];

            Bot_HB_1.sprite = BotsHelthBarImages[currentBot_1];
            Bot_HB_2.sprite = BotsHelthBarImages[currentBot_2];

            //Bot_Slider_1.maxValue = HP_Bots[currentBot_1];
            //Bot_Slider_2.maxValue = HP_Bots[currentBot_2];

            //health_bot_1 = HP_Bots[currentBot_1];
            //health_bot_2 = HP_Bots[currentBot_2];

            Bot_Slider_1.value = health_bot_1;
            Bot_Slider_2.value = health_bot_2;

            Total_Attack_Power_Bot_1 = Attack_Power_Bot_1 + SetAttackPower(currentBot_1, current_Enemy);
            Total_Attack_Power_Bot_2 = Attack_Power_Bot_2 + SetAttackPower(currentBot_2, current_Enemy);

            
        }

        public void ChangeBot()
        {
            if (changeIndex == 1 || changeIndex == 2)
            {
                CnahgePanel.SetActive(true);
            }

        }

        public void change_Bot_1()
        {
            changeIndex = 1;
            BotFightIndex = 1;
        }

        public void change_Bot_2()
        {
            changeIndex = 2;
            BotFightIndex = 2;
        }

        public void chooseAttack()
        {
            if (BotFightIndex == 1)
            {
                if (currentBot_1 == 0)
                {
                    EarthBot_Actions_Panel.SetActive(true);
                }

                if (currentBot_1 == 1)
                {
                    FireBot_Actions_Panel.SetActive(true);
                }

                if (currentBot_1 == 2)
                {
                    GrassBot_Actions_Panel.SetActive(true);
                }

                if (currentBot_1 == 3)
                {
                    PlasmaBot_Actions_Panel.SetActive(true);
                }

                if (currentBot_1 == 4)
                {
                    WaterBot_Actions_Panel.SetActive(true);
                }
            }

            if (BotFightIndex == 2)
            {
                if (currentBot_2 == 0)
                {
                    EarthBot_Actions_Panel.SetActive(true);
                }

                if (currentBot_2 == 1)
                {
                    FireBot_Actions_Panel.SetActive(true);
                }

                if (currentBot_2 == 2)
                {
                    GrassBot_Actions_Panel.SetActive(true);
                }

                if (currentBot_2 == 3)
                {
                    PlasmaBot_Actions_Panel.SetActive(true);
                }

                if (currentBot_2 == 4)
                {
                    WaterBot_Actions_Panel.SetActive(true);
                }
            }
        }

        //Attack FireBot
        public void Inferno_Ball() // bp8
        {
            if (BotFightIndex == 1)
            {
                Attack_Power_Bot_1 = Random.Range(5, 6);
            }

            if (BotFightIndex == 2)
            {
                Attack_Power_Bot_2 = Random.Range(5, 6);
            }

            arena.ButtlePoints = arena.ButtlePoints - 8;//bp 8

            FireBot_Actions_Panel.SetActive(false);
            arena.Attack = true;
        }

        public void Fire_Slash()
        {
            if (BotFightIndex == 1)
            {
                Attack_Power_Bot_1 = Random.Range(3, 4);
            }

            if (BotFightIndex == 2)
            {
                Attack_Power_Bot_2 = Random.Range(3, 4);
            }

            arena.ButtlePoints = arena.ButtlePoints - 5;//bp 5
            arena.Attack = true;
            FireBot_Actions_Panel.SetActive(false);
        }

        public void Fire_Guard()
        {
            if (BotFightIndex == 1)
            {
                Attack_Power_Bot_1 = 0;
            }

            if (BotFightIndex == 2)
            {
                Attack_Power_Bot_2 = 0;
            }
            arena.ButtlePoints = arena.ButtlePoints - 5;//bp 5
            //block 1-3
            int Guard = Random.Range(1, 3);
            arena.Attack = true;
            FireBot_Actions_Panel.SetActive(false);
        }


        //Attack WaterBot
        public void Bubble_Blast()
        {
            if (BotFightIndex == 1)
            {
                Attack_Power_Bot_1 = Random.Range(3, 4);
            }

            if (BotFightIndex == 2)
            {
                Attack_Power_Bot_2 = Random.Range(3, 4);
            }
            arena.ButtlePoints = arena.ButtlePoints - 5;//bp 5
            arena.Attack = true;
            WaterBot_Actions_Panel.SetActive(false);
        }

        public void Water_Slash()
        {
            if (BotFightIndex == 1)
            {
                Attack_Power_Bot_1 = Random.Range(2, 3);
            }

            if (BotFightIndex == 2)
            {
                Attack_Power_Bot_2 = Random.Range(2, 3);
            }
            arena.ButtlePoints = arena.ButtlePoints - 3;//bp 3
            arena.Attack = true;
            WaterBot_Actions_Panel.SetActive(false);
        }

        public void Dodge()
        {
            if (BotFightIndex == 1)
            {
                Attack_Power_Bot_1 = 0;
            }

            if (BotFightIndex == 2)
            {
                Attack_Power_Bot_2 = 0;
            }
            arena.ButtlePoints = arena.ButtlePoints - 3;//bp 3
            //Dodge 50-70%
            int Dodge = Random.Range(50, 70);
            arena.Attack = true;
            WaterBot_Actions_Panel.SetActive(false);
        }


        //Attack GrassBot
        public void Grass_Blade()
        {
            if (BotFightIndex == 1)
            {
                Attack_Power_Bot_1 = Random.Range(3, 4);
            }

            if (BotFightIndex == 2)
            {
                Attack_Power_Bot_2 = Random.Range(3, 4);
            }

            arena.ButtlePoints = arena.ButtlePoints - 5;//bp 5
            arena.Attack = true;
            GrassBot_Actions_Panel.SetActive(false);
        }

        public void Grass_Cut()
        {
            if (BotFightIndex == 1)
            {
                Attack_Power_Bot_1 = Random.Range(2, 3);
            }

            if (BotFightIndex == 2)
            {
                Attack_Power_Bot_2 = Random.Range(2, 3);
            }
            arena.ButtlePoints = arena.ButtlePoints - 3;//bp 3
            arena.Attack = true;
            GrassBot_Actions_Panel.SetActive(false);
        }

        public void Crit_Up()
        {
            if (BotFightIndex == 1)
            {
                Attack_Power_Bot_1 = 0;
            }

            if (BotFightIndex == 2)
            {
                Attack_Power_Bot_2 = 0;
            }
            arena.ButtlePoints = arena.ButtlePoints - 5;//bp 5
            // nextattack +2
            int Crit_Up = 50;
            arena.Attack = true;
            GrassBot_Actions_Panel.SetActive(false);
        }


        //Attack EarthBot 
        public void EarthQuake()
        {
            if (BotFightIndex == 1)
            {
                Attack_Power_Bot_1 = Random.Range(5, 8);
            }

            if (BotFightIndex == 2)
            {
                Attack_Power_Bot_2 = Random.Range(5, 8);
            }


            arena.ButtlePoints = arena.ButtlePoints - 10;//bp 10
            arena.Attack = true;
            EarthBot_Actions_Panel.SetActive(false);
        }

        public void Punch()
        {
            if (BotFightIndex == 1)
            {
                Attack_Power_Bot_1 = Random.Range(1, 2);
            }

            if (BotFightIndex == 2)
            {
                Attack_Power_Bot_2 = Random.Range(1, 2);
            }

            arena.ButtlePoints = arena.ButtlePoints - 2;//bp 2
            arena.Attack = true;
            EarthBot_Actions_Panel.SetActive(false);
        }

        public void Power_Up()
        {
            if (BotFightIndex == 1)
            {
                Attack_Power_Bot_1 = 0;
            }

            if (BotFightIndex == 2)
            {
                Attack_Power_Bot_2 = 0;
            }

            arena.ButtlePoints = arena.ButtlePoints - 5;//bp 5
            int Power_Up = Random.Range(30, 50);
            arena.Attack = true;
            EarthBot_Actions_Panel.SetActive(false);
        }


        //Attack PlasmaBot 
        public void Plasma_Bomb()
        {
            if (BotFightIndex == 1)
            {
                Attack_Power_Bot_1 = Random.Range(3, 4);
            }

            if (BotFightIndex == 2)
            {
                Attack_Power_Bot_2 = Random.Range(3, 4);
            }

            arena.ButtlePoints = arena.ButtlePoints - 5;//bp 5
            arena.Attack = true;
            PlasmaBot_Actions_Panel.SetActive(false);
        }

        public void Sucker_Punch()
        {
            if (BotFightIndex == 1)
            {
                Attack_Power_Bot_1 = Random.Range(1, 3);
            }

            if (BotFightIndex == 2)
            {
                Attack_Power_Bot_2 = Random.Range(1, 3);
            }


            arena.ButtlePoints = arena.ButtlePoints - 3;//bp 3
            int Heals_Sucker_Punch = Random.Range(1, 2);
            arena.Attack = true;
            PlasmaBot_Actions_Panel.SetActive(false);
        }

        public void Heal()
        {
            if (BotFightIndex == 1)
            {
                Attack_Power_Bot_1 = 0;
            }

            if (BotFightIndex == 2)
            {
                Attack_Power_Bot_2 = 0;
            }
            arena.ButtlePoints = arena.ButtlePoints - 8;//bp 8
            int Heal = Random.Range(4, 5);
            arena.Attack = true;
            PlasmaBot_Actions_Panel.SetActive(false);
        }

        //Choose_Item_Menu Buttons
        public void Choose_Item_Menu_1()
        {
            Item_Menu_1.SetActive(true);
            Item_Menu_2.SetActive(false);
            Item_Menu_3.SetActive(false);
        }

        public void Choose_Item_Menu_2()
        {
            Item_Menu_1.SetActive(false);
            Item_Menu_2.SetActive(true);
            Item_Menu_3.SetActive(false);
        }

        public void Choose_Item_Menu_3()
        {
            Item_Menu_1.SetActive(false);
            Item_Menu_2.SetActive(false);
            Item_Menu_3.SetActive(true);
        }

        public void Main_Menu()
        {
            Item_Menu_1.SetActive(false);
            Item_Menu_2.SetActive(false);
            Item_Menu_3.SetActive(false);
        }
    }
}
