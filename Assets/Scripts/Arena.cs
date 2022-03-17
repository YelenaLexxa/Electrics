using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Electrics
{
    public class Arena : MonoBehaviour
    {
        [SerializeField] private PlayerFight playerFight;
        [SerializeField] private Fight fight;

        public bool Attack;
        public Text BP;
        public int ButtlePoints = 7;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (ButtlePoints > 30)
            {
                ButtlePoints = 30;
            }
            if (Attack)
            {
                Enemy_Fight_Start();
                Bot_Fight_Start();
                Attack = false;
            }

            BP.text = "" + ButtlePoints;
        }

        public void Enemy_Fight_Start()
        {
            //Enemy Attack
            if (playerFight.BotFightIndex == 1)
            {
                if (fight.currentEnemyIndex == 1)
                {
                    playerFight.health_bot_1 = playerFight.health_bot_1 - fight.Total_Attack_Power_Enemy_1;
                    playerFight.Current_HP_Bots[playerFight.currentBot_1] = playerFight.health_bot_1;
                }

                if (fight.currentEnemyIndex == 2)
                {
                    playerFight.health_bot_1 = playerFight.health_bot_1 - fight.Total_Attack_Power_Enemy_2;
                    playerFight.Current_HP_Bots[playerFight.currentBot_1] = playerFight.health_bot_1;
                }
            }

            if (playerFight.BotFightIndex == 2)
            {
                if (fight.currentEnemyIndex == 1)
                {
                    playerFight.health_bot_2 = playerFight.health_bot_2 - fight.Total_Attack_Power_Enemy_1;
                    playerFight.Current_HP_Bots[playerFight.currentBot_2] = playerFight.health_bot_2;
                }

                if (fight.currentEnemyIndex == 2)
                {
                    playerFight.health_bot_2 = playerFight.health_bot_2 - fight.Total_Attack_Power_Enemy_2;
                    playerFight.Current_HP_Bots[playerFight.currentBot_2] = playerFight.health_bot_2;
                }
            }
        }

        public void Bot_Fight_Start()
        {
            //Bot Attack
            if (playerFight.BotFightIndex == 1)
            {
                if (fight.currentEnemyIndex == 1)
                {
                    fight.health_Enemy_1 = fight.health_Enemy_1 - playerFight.Total_Attack_Power_Bot_1;
                }

                if (fight.currentEnemyIndex == 2)
                {
                    fight.health_Enemy_2 = fight.health_Enemy_2 - playerFight.Total_Attack_Power_Bot_1;
                }
            }

            if (playerFight.BotFightIndex == 2)
            {
                if (fight.currentEnemyIndex == 1)
                {
                    fight.health_Enemy_1 = fight.health_Enemy_1 - playerFight.Total_Attack_Power_Bot_2;
                }

                if (fight.currentEnemyIndex == 2)
                {
                    fight.health_Enemy_2 = fight.health_Enemy_2 - playerFight.Total_Attack_Power_Bot_2;
                }
            }
            playerFight.Round_Int = playerFight.Round_Int + 1; 
            ButtlePoints = ButtlePoints + 4;
            playerFight.AdditionalAttack = 0;
        }
    }
}
