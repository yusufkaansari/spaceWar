using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UzayOyunuTGY.Controllers
{
    public class AudioController : MonoBehaviour
    {
        [SerializeField]
        AudioClip asteroidDestroyed;

        [SerializeField]
        AudioClip spaceshipDestroyed;

        [SerializeField]
        AudioClip fire;

        AudioSource audioSource;

        private void Awake()
        {
            audioSource = gameObject.GetComponent<AudioSource>();
        }

        public void DestroyAsteroidPlay()
        {
            audioSource.PlayOneShot(asteroidDestroyed);
        }
        public void DestroySpaceshipPlay()
        {
            audioSource.PlayOneShot(spaceshipDestroyed);
        }
        public void FirePlay()
        {
            audioSource.PlayOneShot(fire,0.4f);
        }
    }
}

