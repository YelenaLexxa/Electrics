using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace Electrics
{
    public class Timer_Script : MonoBehaviour
    {
        public float GameSeconds;
        public float GameMinutes;
        public string stringSeconds;
        public string stringMinutes;

        public int Electric_Score = 0;
        public int Arena_Score = 0;

        //public Panel_Manager panel_Manager;
        public Text textTime;
        public Text Electric_Score_Text;
        public Text Arena_Score_Text;

        void Update()
        {
            GameSeconds = GameSeconds - Time.deltaTime;
            stringSeconds = Mathf.Round(GameSeconds).ToString();
            stringMinutes = Mathf.Round(GameMinutes).ToString();

            textTime.text = ("" + stringMinutes + " : " + stringSeconds);

            Electric_Score_Text.text = "" + Electric_Score;
            Arena_Score_Text.text = "" + Arena_Score;

            if (GameSeconds <= 0.0f)
            {
                GameMinutes = GameMinutes - 1.0f;
                GameSeconds = 60.0f;
            }

            if (Electric_Score >= 100 && Arena_Score == 7) 
            {
                Electric_Score = 100;
                Debug.Log("Winner");
                SceneManager.LoadScene("Winner");
            }

            if (GameSeconds == 0.0f && GameMinutes == 0.0f)
            {
                if (Electric_Score < 100 || Arena_Score < 7)
                {
                    Debug.Log("Game Over");
                    SceneManager.LoadScene("Game_Over");
                }
                if (Electric_Score >= 100 && Arena_Score == 7)
                {
                    Debug.Log("Winner");
                    SceneManager.LoadScene("Winner");
                }

            }
        }
    }
}

