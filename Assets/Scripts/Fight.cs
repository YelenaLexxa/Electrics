using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Electrics
{
    public class Fight : MonoBehaviour
    {
        [SerializeField] private PlayerFight playerFight;
        public Sprite[] BotsImages = new Sprite[5];
        public Sprite[] BotsHelthBarImages = new Sprite[5];

        public Button Enemy_1;
        public Button Enemy_2;

        public Image Enemy_HB_1;
        public Image Enemy_HB_2;

        public Slider Enemy_Slider_1;
        public Slider Enemy_Slider_2;

        public int getEnemy_1;
        public int getEnemy_2;

        private int Enemy_changeIndex;

        private int[] HP_Enemy = { 12, 8, 10, 14, 10 };

        public int Attack_Power_Enemy_1 = 0;
        public int Attack_Power_Enemy_2 = 0;

        public int Total_Attack_Power_Enemy_1 = 0;
        public int Total_Attack_Power_Enemy_2 = 0;

        private int adittionalAttack;

        public int health_Enemy_1;
        public int health_Enemy_2;

        public int currentEnemyIndex;

        // Start is called before the first frame update
        void Start()
        {
            PrepareEnemy();
        }

        // Update is called once per frame
        void Update()
        {
            SetUpAttack();
            Enemy_Slider_1.value = health_Enemy_1;
            Enemy_Slider_2.value = health_Enemy_2;

            if (health_Enemy_1 <= 0)
            {
                Enemy_1.interactable = false;
            }

            if (health_Enemy_2 <= 0)
            {
                Enemy_2.interactable = false;
            }

        }

        public int Attack_Enemy(int index)
        {
            int EarthBot = Random.Range(1, 8);
            int FireBot = Random.Range(3, 6);
            int GrassBot = Random.Range(2, 4);
            int PlasmaBot = Random.Range(1, 4);
            int WaterBot = Random.Range(2, 4);
            //int BossBot = Random.Range(5, 10);

            int[] Attack_Power = { EarthBot, FireBot, GrassBot, PlasmaBot, WaterBot };

            return Attack_Power[index];
        }

        public int SetAttackPower(int indexBotEnemy, int indexBotPlayer)
        {
            int additionalDamage = 0;

            if (indexBotEnemy == 0) //EarthBot
            {
                if (indexBotPlayer == 3) //PlasmaBot
                {
                    additionalDamage = 2;
                }
            }

            if (indexBotEnemy == 1) //FireBot
            {
                if (indexBotPlayer == 0) //EarthBot
                {
                    additionalDamage = 2;
                }
            }

            if (indexBotEnemy == 2) //GrassBot
            {
                if (indexBotPlayer == 4) //WaterBot
                {
                    additionalDamage = 2;
                }
            }

            if (indexBotEnemy == 3) //PlasmaBot
            {
                if (indexBotPlayer == 2) //GrassBot
                {
                    additionalDamage = 2;
                }
            }

            if (indexBotEnemy == 4) //WaterBot
            {
                if (indexBotPlayer == 1) //FireBot
                {
                    additionalDamage = 2;
                }
            }

            return additionalDamage;
        }

        public void PrepareEnemy()
        {
            //setup enemy
            getEnemy_1 = Random.Range(0, 4);
            getEnemy_2 = Random.Range(0, 4);

            Enemy_1.GetComponent<Image>().sprite = BotsImages[getEnemy_1];
            Enemy_2.GetComponent<Image>().sprite = BotsImages[getEnemy_2];

            Enemy_HB_1.sprite = BotsHelthBarImages[getEnemy_1];
            Enemy_HB_2.sprite = BotsHelthBarImages[getEnemy_2];

            Enemy_Slider_1.maxValue = HP_Enemy[getEnemy_1];
            Enemy_Slider_2.maxValue = HP_Enemy[getEnemy_2];

            health_Enemy_1 = HP_Enemy[getEnemy_1];
            health_Enemy_2 = HP_Enemy[getEnemy_2];

            Enemy_Slider_1.value = health_Enemy_1;
            Enemy_Slider_2.value = health_Enemy_2;

            Attack_Power_Enemy_1 = Attack_Enemy(getEnemy_1);
            Attack_Power_Enemy_2 = Attack_Enemy(getEnemy_2);

            
        }

        public void SetUpAttack()
        {
            if (playerFight.BotFightIndex == 1)
            {
                adittionalAttack = playerFight.currentBot_1;
            }

            if (playerFight.BotFightIndex == 2)
            {
                adittionalAttack = playerFight.currentBot_2;
            }

            Total_Attack_Power_Enemy_1 = Attack_Power_Enemy_1 + SetAttackPower(getEnemy_1, adittionalAttack);
            Total_Attack_Power_Enemy_2 = Attack_Power_Enemy_2 + SetAttackPower(getEnemy_2, adittionalAttack);
        }

        public void chooseEnemy_1()
        {
            playerFight.current_Enemy = getEnemy_1;
            currentEnemyIndex = 1;
        }

        public void chooseEnemy_2()
        {
            playerFight.current_Enemy = getEnemy_2;
            currentEnemyIndex = 2;
        }
    }
}

