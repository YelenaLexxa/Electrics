using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Electrics
{
    public class PlayerFight : MonoBehaviour
    {
        [SerializeField] private Arena arena;
        [SerializeField] private Fight fight;
        [SerializeField] private Timer_Script timer_Script;


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

        public Image Target_Player_1;
        public Image Target_Player_2;

        public GameObject CnahgePanel;

        public GameObject EarthBot_Actions_Panel;
        public GameObject FireBot_Actions_Panel;
        public GameObject GrassBot_Actions_Panel;
        public GameObject PlasmaBot_Actions_Panel;
        public GameObject WaterBot_Actions_Panel;

        public GameObject Item_Menu_1;
        public GameObject Item_Menu_2;
        public GameObject Item_Menu_3;

        public GameObject NO_BP_Image;

        public Button EarthBotChoose;
        public Button FireBotChoose;
        public Button GrassBotChoose;
        public Button PlasmaBotChoose;
        public Button WaterBotChoose;

        //public Button EndTurn_Button;


        public int Attack_Power_Bot_1 = 0;
        public int Attack_Power_Bot_2 = 0;

        public int Total_Attack_Power_Bot_1 = 0;
        public int Total_Attack_Power_Bot_2 = 0;

        private int[] HP_Bots = { 12, 8, 10, 14, 10 }; //EarthBot, FireBot, GrassBot, PlasmaBot, WaterBot //for new

        public int[] Current_HP_Bots = { 12, 8, 10, 14, 10 }; //EarthBot, FireBot, GrassBot, PlasmaBot, WaterBot //for current fight

        public int current_Enemy = 7;

        public int health_bot_1;
        public int health_bot_2;

        public int AdditionalAttack = 0;

        public Text Round;
        public int Round_Int = 1;

        public GameObject Win;
        public GameObject Draw;
        public GameObject Lose;

        public bool _winRound;




        // Start is called before the first frame update
        void Start()
        {
            
            SetUp();
            NO_BP_Image.SetActive(false);

            Win.SetActive(false);
            Draw.SetActive(false);
            Lose.SetActive(false);

            Target_Player_1.enabled = false;
            Target_Player_2.enabled = false;
        }

        public void SetUp()
        {
            CnahgePanel.SetActive(false);

            health_bot_1 = HP_Bots[currentBot_1];
            health_bot_2 = HP_Bots[currentBot_2];
            Bot_Slider_1.maxValue = HP_Bots[currentBot_1];
            Bot_Slider_2.maxValue = HP_Bots[currentBot_2];
            Attack_Power_Bot_1 = Random.Range(5, 8);
            Attack_Power_Bot_2 = Random.Range(5, 6);
        }

        // Update is called once per frame
        void Update()
        {
            Round.text = "" + Round_Int;

            PrepareBots();

            if (health_bot_1 <= 0 && health_bot_2 <= 0)
            {
                Bot_1.interactable = false;
                Bot_2.interactable = false;
                BotFightIndex = 0;
                changeIndex = 0;
                Target_Player_1.enabled = false;
                Target_Player_2.enabled = false;
            }

            if (health_bot_1 <= 0 && health_bot_2 > 0)
            {
                Bot_1.interactable = false;
                BotFightIndex = 2;
                changeIndex = 2;
                Target_Player_1.enabled = false;
                Target_Player_2.enabled = true;
            }

            if (health_bot_2 <= 0 && health_bot_1 > 0)
            {
                Bot_2.interactable = false;
                BotFightIndex = 1;
                changeIndex = 1;
                Target_Player_2.enabled = false;
                Target_Player_1.enabled = true;
            }

            ChangeRobotButtons();
            Result();
        }
        public void UpdateHealth()
        {
            Bot_Slider_1.maxValue = HP_Bots[currentBot_1];
            Bot_Slider_2.maxValue = HP_Bots[currentBot_2];

            health_bot_1 = Current_HP_Bots[currentBot_1];
            health_bot_2 = Current_HP_Bots[currentBot_2];
        }
        public void chooseEarthBot()
        {
            

            if (arena.ButtlePoints < 2)
            {
                NO_BP_Image.SetActive(true);
                CnahgePanel.SetActive(false);
            }
            else {
                arena.ButtlePoints = arena.ButtlePoints - 2;
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
            
        }

        public void chooseFireBot()
        {
            if (arena.ButtlePoints < 2)
            {
                NO_BP_Image.SetActive(true);
                CnahgePanel.SetActive(false);
            }
            else
            {
                arena.ButtlePoints = arena.ButtlePoints - 2;
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
        }

        public void chooseGrassBot()
        {
            if (arena.ButtlePoints < 2)
            {
                NO_BP_Image.SetActive(true);
                CnahgePanel.SetActive(false);
            }
            else
            {
                arena.ButtlePoints = arena.ButtlePoints - 2;
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
        }

        public void choosePlasmaBot()
        {
            if (arena.ButtlePoints < 2)
            {
                NO_BP_Image.SetActive(true);
                CnahgePanel.SetActive(false);
            }
            else
            {
                arena.ButtlePoints = arena.ButtlePoints - 2;
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
        }

        public void chooseWaterBot()
        {
            if (arena.ButtlePoints < 2)
            {
                NO_BP_Image.SetActive(true);
                CnahgePanel.SetActive(false);
            }
            else
            {
                arena.ButtlePoints = arena.ButtlePoints - 2;
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

            Total_Attack_Power_Bot_1 = Attack_Power_Bot_1 + AdditionalAttack + SetAttackPower(currentBot_1, current_Enemy);
            Total_Attack_Power_Bot_2 = Attack_Power_Bot_2 + AdditionalAttack + SetAttackPower(currentBot_2, current_Enemy);

            
        }

        public void ChangeBot()
        {
            if (BotFightIndex != 0)
            {
                if (changeIndex == 1 || changeIndex == 2)
                {
                    CnahgePanel.SetActive(true);
                }
            }
        }

        public void change_Bot_1()
        {
            changeIndex = 1;
            BotFightIndex = 1;

            Target_Player_1.enabled = true;
            Target_Player_2.enabled = false;
        }

        public void change_Bot_2()
        {
            changeIndex = 2;
            BotFightIndex = 2;
            Target_Player_1.enabled = false;
            Target_Player_2.enabled = true;
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

        //public void EndTurn()
        //{
        //    arena.Attack = true;
        //}

        //Attack FireBot
        public void Inferno_Ball() // bp8
        {
            


            if (arena.ButtlePoints < 8)
            {
                NO_BP_Image.SetActive(true);
            }
            else {
                

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
            

           
        }

        public void Fire_Slash()
        {

            if (arena.ButtlePoints < 5)
            {
                NO_BP_Image.SetActive(true);
            }

            else {
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
        }

        public void Fire_Guard()
        {

            if (arena.ButtlePoints < 5)
            {
                NO_BP_Image.SetActive(true);
            }
            else {
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


                if (BotFightIndex == 1)
                {
                    health_bot_1 = health_bot_1 + Guard;
                    Current_HP_Bots[currentBot_1] = health_bot_1;
                }

                if (BotFightIndex == 2)
                {
                    health_bot_1 = health_bot_2 + Guard;
                    Current_HP_Bots[currentBot_2] = health_bot_2;
                }

                if (health_bot_1 > HP_Bots[currentBot_1])
                {
                    health_bot_1 = HP_Bots[currentBot_1];
                }
                if (health_bot_2 > HP_Bots[currentBot_2])
                {
                    health_bot_2 = HP_Bots[currentBot_2];
                }

                arena.Attack = true;
                FireBot_Actions_Panel.SetActive(false);
            }
        }


        //Attack WaterBot
        public void Bubble_Blast()
        {

            if (arena.ButtlePoints < 5)
            {
                NO_BP_Image.SetActive(true);
            }
            else {
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
        }

        public void Water_Slash()
        {

            if (arena.ButtlePoints < 3)
            {
                NO_BP_Image.SetActive(true);
            }
            else {
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

           
        }

        public void Dodge()
        {
            if (arena.ButtlePoints < 3)
            {
                NO_BP_Image.SetActive(true);
            }
            else {
                arena.ButtlePoints = arena.ButtlePoints - 3;//bp 3
                                                            //Dodge 50-70%
                int Dodge = Random.Range(50, 70);

                if (BotFightIndex == 1)
                {
                    Attack_Power_Bot_1 = (Random.Range(2, 3) * (Dodge / 100)) + Random.Range(2, 3);
                }

                if (BotFightIndex == 2)
                {
                    Attack_Power_Bot_2 = Random.Range(2, 3) * (Dodge / 100) + Random.Range(2, 3);
                }

                arena.Attack = true;
                WaterBot_Actions_Panel.SetActive(false);
            }
            
        }


        //Attack GrassBot
        public void Grass_Blade()
        {

            if (arena.ButtlePoints < 5)
            {
                NO_BP_Image.SetActive(true);
            }

            else {
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
        }

        public void Grass_Cut()
        {
            if (arena.ButtlePoints < 3)
            {
                NO_BP_Image.SetActive(true);
            }
            else {
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
        }

        public void Crit_Up()
        {
            if (arena.ButtlePoints < 5)
            {
                NO_BP_Image.SetActive(true);
            }
            else {
                arena.ButtlePoints = arena.ButtlePoints - 5;//bp 5

                int Crit_Up = Random.Range(1, 2);


                if (BotFightIndex == 1)
                {
                    Attack_Power_Bot_1 = Random.Range(2, 3) * Crit_Up;
                }

                if (BotFightIndex == 2)
                {
                    Attack_Power_Bot_2 = Random.Range(2, 3) * Crit_Up;
                }


                arena.Attack = true;
                GrassBot_Actions_Panel.SetActive(false);
            }
        }


        //Attack EarthBot 
        public void EarthQuake()
        {
            if (arena.ButtlePoints < 10)
            {
                NO_BP_Image.SetActive(true);
            }
            else{
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
            
        }

        public void Punch()
        {
            if (arena.ButtlePoints < 2)
            {
                NO_BP_Image.SetActive(true);
            }
            else{
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
        }

        public void Power_Up()
        {
            if (arena.ButtlePoints < 5)
            {
                NO_BP_Image.SetActive(true);
            }
            else {
                arena.ButtlePoints = arena.ButtlePoints - 5;//bp 5
                int Power_Up = Random.Range(30, 50);

                if (BotFightIndex == 1)
                {
                    Attack_Power_Bot_1 = (Random.Range(5, 8) * (Power_Up / 100)) + Random.Range(5, 8);
                }

                if (BotFightIndex == 2)
                {
                    Attack_Power_Bot_2 = (Random.Range(5, 8) * (Power_Up / 100)) + Random.Range(5, 8);
                }


                arena.Attack = true;
                EarthBot_Actions_Panel.SetActive(false);
            }
        }


        //Attack PlasmaBot 
        public void Plasma_Bomb()
        {

            if (arena.ButtlePoints < 5)
            {
                NO_BP_Image.SetActive(true);
            }
            else {
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
            
        }

        public void Sucker_Punch()
        {
            if (arena.ButtlePoints <3)
            {
                NO_BP_Image.SetActive(true);
            }
            else {
                if (BotFightIndex == 1)
                {
                    Attack_Power_Bot_1 = Random.Range(1, 3);
                }

                if (BotFightIndex == 2)
                {
                    Attack_Power_Bot_2 = Random.Range(1, 3);
                }


                arena.ButtlePoints = arena.ButtlePoints - 3;//bp 3
                //int Heals_Sucker_Punch = Random.Range(1, 2);
                arena.Attack = true;
                PlasmaBot_Actions_Panel.SetActive(false);
            }
            
        }

        public void Heal()
        {
            if (arena.ButtlePoints < 8)
            {
                NO_BP_Image.SetActive(true);
            }
            else {
                arena.ButtlePoints = arena.ButtlePoints - 8;//bp 8
                int Heal = Random.Range(4, 5);


                if (BotFightIndex == 1)
                {
                    Attack_Power_Bot_1 = 0;

                    health_bot_1 = health_bot_1 + Heal;
                    Current_HP_Bots[currentBot_1] = health_bot_1;

                }

                if (BotFightIndex == 2)
                {
                    Attack_Power_Bot_2 = 0;
                    health_bot_2 = health_bot_2 + Heal;
                    Current_HP_Bots[currentBot_2] = health_bot_2;
                }

                if (health_bot_1 > HP_Bots[currentBot_1])
                {
                    health_bot_1 = HP_Bots[currentBot_1];
                }
                if (health_bot_2 > HP_Bots[currentBot_2])
                {
                    health_bot_2 = HP_Bots[currentBot_2];
                }

                arena.Attack = true;
                PlasmaBot_Actions_Panel.SetActive(false);
            }
        }

        //Additional settings

        public void HealingCan()
        {
            if (arena.ButtlePoints < 5)
            {
                NO_BP_Image.SetActive(true);
            }
            else {
                

                int Heal = Random.Range(1, 6);

                if (BotFightIndex == 1)
                {
                    health_bot_1 = health_bot_1 + Heal;
                    Current_HP_Bots[currentBot_2] = health_bot_2;
                    arena.ButtlePoints = arena.ButtlePoints - 5;//bp 5
                }

                if (BotFightIndex == 2)
                {
                    health_bot_2 = health_bot_2 + Heal;
                    Current_HP_Bots[currentBot_2] = health_bot_2;
                    arena.ButtlePoints = arena.ButtlePoints - 5;//bp 5
                }

                if (health_bot_1 > HP_Bots[currentBot_1])
                {
                    health_bot_1 = HP_Bots[currentBot_1];
                }
                if (health_bot_2 > HP_Bots[currentBot_2])
                {
                    health_bot_2 = HP_Bots[currentBot_2];
                }
            }

            Main_Menu();
        }

        public void Taser()
        {
            if (arena.ButtlePoints < 4)
            {
                NO_BP_Image.SetActive(true);
            }
            else {
                if (BotFightIndex != 0)
                {
                    arena.ButtlePoints = arena.ButtlePoints - 4;//bp 4

                    int TaserPower = Random.Range(2, 3);

                    AdditionalAttack = AdditionalAttack + TaserPower;
                }
                

                //if (BotFightIndex == 1)
                //{
                //    Attack_Power_Bot_1 = Attack_Power_Bot_1 + TaserPower; 
                //}

                //if (BotFightIndex == 2)
                //{
                //    Attack_Power_Bot_2 = Attack_Power_Bot_2 + TaserPower;
                //}

               
            }
            Main_Menu();
        }

        public void HardCasing()
        {
            if (arena.ButtlePoints < 4)
            {
                NO_BP_Image.SetActive(true);
            }
            else {
                

                int HardCasingPower = Random.Range(1, 6);

                if (BotFightIndex == 1)
                {
                    health_bot_1 = health_bot_1 + HardCasingPower;
                    Current_HP_Bots[currentBot_1] = health_bot_1;
                    arena.ButtlePoints = arena.ButtlePoints - 4;//bp 4
                }

                if (BotFightIndex == 2)
                {
                    health_bot_2 = health_bot_2 + HardCasingPower;
                    Current_HP_Bots[currentBot_2] = health_bot_2;
                    arena.ButtlePoints = arena.ButtlePoints - 4;//bp 4
                }

                if (health_bot_1 > HP_Bots[currentBot_1])
                {
                    health_bot_1 = HP_Bots[currentBot_1];
                }
                if (health_bot_2 > HP_Bots[currentBot_2])
                {
                    health_bot_2 = HP_Bots[currentBot_2];
                }
            }
            Main_Menu();
        }

        public void Excalibur()
        {
            if (arena.ButtlePoints < 4)
            {
                NO_BP_Image.SetActive(true);
            }
            else {
                if (BotFightIndex != 0)
                {
                    arena.ButtlePoints = arena.ButtlePoints - 4;//bp 4

                    int ExcaliburPower = Random.Range(1, 4);

                    AdditionalAttack = AdditionalAttack + ExcaliburPower;
                }
                

                //if (BotFightIndex == 1)
                //{
                //    Attack_Power_Bot_1 = Attack_Power_Bot_1 + ExcaliburPower;
                //}

                //if (BotFightIndex == 2)
                //{
                //    Attack_Power_Bot_2 = Attack_Power_Bot_2 + ExcaliburPower;
                //}

                
            }

            Main_Menu();
        }

        public void Upgrade()
        {
            if (arena.ButtlePoints < 8)
            {
                NO_BP_Image.SetActive(true);
            }
            else {
                

                int UpgradeHeal = Random.Range(3, 5);
                int UpgradePower = Random.Range(3, 5);

                AdditionalAttack = AdditionalAttack + UpgradePower;

                if (BotFightIndex == 1)
                {
                    health_bot_1 = health_bot_1 + UpgradeHeal;
                    Current_HP_Bots[currentBot_1] = health_bot_1;
                    arena.ButtlePoints = arena.ButtlePoints - 8;//bp 8
                    // Attack_Power_Bot_1 = Attack_Power_Bot_1 + UpgradePower;
                }

                if (BotFightIndex == 2)
                {
                    health_bot_2 = health_bot_2 + UpgradeHeal;
                    Current_HP_Bots[currentBot_2] = health_bot_2;
                    arena.ButtlePoints = arena.ButtlePoints - 8;//bp 8
                    //Attack_Power_Bot_2 = Attack_Power_Bot_2 + UpgradePower;
                }

                if (health_bot_1 > HP_Bots[currentBot_1])
                {
                    health_bot_1 = HP_Bots[currentBot_1];
                }
                if (health_bot_2 > HP_Bots[currentBot_2])
                {
                    health_bot_2 = HP_Bots[currentBot_2];
                }
            }

            Main_Menu();

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
            EarthBot_Actions_Panel.SetActive(false);
            FireBot_Actions_Panel.SetActive(false);
            GrassBot_Actions_Panel.SetActive(false);
            PlasmaBot_Actions_Panel.SetActive(false);
            WaterBot_Actions_Panel.SetActive(false);

        }

        public void Close_NO_BP_Image()
        {
            NO_BP_Image.SetActive(false);
        }

        public void ChangeRobotButtons()
        {

            if (currentBot_1 == 0 || currentBot_2 == 0)
            {
                EarthBotChoose.interactable = false;
            }
            else {
                EarthBotChoose.interactable = true;
            }

            if (currentBot_1 == 1 || currentBot_2 == 1)
            {
                FireBotChoose.interactable = false;
            }
            else
            {
                FireBotChoose.interactable = true;
            }

            if (currentBot_1 == 2 || currentBot_2 == 2)
            {
                GrassBotChoose.interactable = false;
            }
            else
            {
                GrassBotChoose.interactable = true;
            }

            if (currentBot_1 == 3 || currentBot_2 == 3)
            {
                PlasmaBotChoose.interactable = false;
            }
            else
            {
                PlasmaBotChoose.interactable = true;
            }

            if (currentBot_1 == 4 || currentBot_2 == 4)
            {
                WaterBotChoose.interactable = false;
            }
            else
            {
                WaterBotChoose.interactable = true;
            }

            //public Button EarthBotChoose;
            //public Button FireBotChoose;
            //public Button GrassBotChoose;
            //public Button PlasmaBotChoose;
            //public Button WaterBotChoose;
        }

        public void RefreshButtle()
        {
            currentBot_1 = 0;
            currentBot_2 = 1;
            Total_Attack_Power_Bot_1 = 0;
            Total_Attack_Power_Bot_2 = 0;
            current_Enemy = 7;
            changeIndex = 0;
            Round_Int = 1;
            AdditionalAttack = 0;

            Current_HP_Bots =  new int [] { 12, 8, 10, 14, 10 };

            SetUp();

            NO_BP_Image.SetActive(false);
            Win.SetActive(false);
            Draw.SetActive(false);
            Lose.SetActive(false);
            EarthBot_Actions_Panel.SetActive(false);
            FireBot_Actions_Panel.SetActive(false);
            GrassBot_Actions_Panel.SetActive(false);
            PlasmaBot_Actions_Panel.SetActive(false);
            WaterBot_Actions_Panel.SetActive(false);
            Item_Menu_1.SetActive(false);
            Item_Menu_2.SetActive(false);
            Item_Menu_3.SetActive(false);

            fight.Attack_Power_Enemy_1 = 0;
            fight.Attack_Power_Enemy_2 = 0;

            fight.Total_Attack_Power_Enemy_1 = 0;
            fight.Total_Attack_Power_Enemy_2 = 0;

            Bot_1.interactable = true;
            Bot_2.interactable = true;

            fight.Enemy_1.interactable = true;
            fight.Enemy_2.interactable = true;

            fight.PrepareEnemy();

            fight.chooseEnemy_1();

            if (arena.ButtlePoints < 7)
            {
                arena.ButtlePoints = 7;
            }
        }

        public void Result()
        {
            if (health_bot_1 <= 0 && health_bot_2 <= 0 && fight.health_Enemy_1 <= 0 && fight.health_Enemy_2 <= 0)
            {
                Draw.SetActive(true);
                _winRound = false;
            }
            else {
                if (health_bot_1 <= 0 && health_bot_2 <= 0 && fight.health_Enemy_1 > 0)
                {
                    Lose.SetActive(true);
                    _winRound = false;
                }
                
                else
                {
                    if (health_bot_1 <= 0 && health_bot_2 <= 0 && fight.health_Enemy_2 > 0)
                    {
                        Lose.SetActive(true);
                        _winRound = false;
                    }
                    if (health_bot_1 > 0 && fight.health_Enemy_1 <= 0 && fight.health_Enemy_2 <= 0)
                    {
                        Win.SetActive(true);
                        _winRound = true;
                    }
                    else {
                        if (health_bot_2 > 0 && fight.health_Enemy_1 <= 0 && fight.health_Enemy_2 <= 0)
                        {
                            Win.SetActive(true);
                            _winRound = true;
                        }
                    }
                }
            }
        }
    }
}
