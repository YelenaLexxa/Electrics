using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Electrics
{
    public class Scene_Manager : MonoBehaviour
    {
        public void Main_Menu()
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void Start_Over()
        {
            SceneManager.LoadScene("SampleScene");
        }

    }
}
