using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Electrics
{
    public class Audio_Manager : MonoBehaviour
    {

        public AudioSource Game;
        public AudioSource Battle_sound;

        // Start is called before the first frame update
        void Start()
        {
            Battle_sound.Stop();
        }

        // Update is called once per frame
        void Update()
        {
            //if (_play)
            //{
            //    m_MyAudioSource.Play();
            //}
            //else {
            //    m_MyAudioSource.Stop();
            //}
        }

        public void Play()
        {
            Game.Play();
            Battle_sound.Stop();
        }
        public void Stop()
        {
            Game.Stop();
            Battle_sound.Play();
        }

    }
}

