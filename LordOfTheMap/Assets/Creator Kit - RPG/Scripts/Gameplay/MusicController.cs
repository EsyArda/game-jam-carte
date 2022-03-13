using UnityEngine;
using UnityEngine.Audio;
using System;

namespace RPGM.Gameplay
{
    public class MusicController : MonoBehaviour
    {
        public AudioMixerGroup audioMixerGroup;

        public AudioClip[] audioSources;
        public AudioClip audioClip;

        public float crossFadeTime = 3;

        AudioSource audioSourceA, audioSourceB;
        float audioSourceAVolumeVelocity, audioSourceBVolumeVelocity;

        public void CrossFade(AudioClip audioclip)
        {
            var t = audioSourceA;
            audioSourceA = audioSourceB;
            audioSourceB = t;
            audioSourceA.clip = audioclip;
            audioSourceA.Play();
        }

        void Update()
        {
            audioSourceA.volume = Mathf.SmoothDamp(audioSourceA.volume, 1f, ref audioSourceAVolumeVelocity, crossFadeTime, 1);
            audioSourceB.volume = Mathf.SmoothDamp(audioSourceB.volume, 0f, ref audioSourceBVolumeVelocity, crossFadeTime, 1);
        }

        void OnEnable()
        {
            var aleatoire = new System.Random();
            int rand = aleatoire.Next(1, 7);

            

            audioSourceA = gameObject.AddComponent<AudioSource>();
            audioSourceA.spatialBlend = 0;
            //audioSourceA.clip = audioClip;
            audioSourceA.clip = audioSources[UnityEngine.Random.Range(0, audioSources.Length)];
            audioSourceA.loop = true;
            audioSourceA.outputAudioMixerGroup = audioMixerGroup;
            audioSourceA.Play();

            audioSourceB = gameObject.AddComponent<AudioSource>();
            audioSourceB.spatialBlend = 0;
            audioSourceB.loop = true;
            audioSourceB.outputAudioMixerGroup = audioMixerGroup;
        }
    }
}