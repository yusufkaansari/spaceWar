using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UzayOyunuTGY.Controllers;

namespace UzayOyunuTGY.Spawners
{
    public class AsteroidSpawner : MonoBehaviour
    {
        [SerializeField]
        List<AsteroidController> asteroidPrefabs = new List<AsteroidController>();

        List<AsteroidController> asteroidList = new List<AsteroidController>();
        private void Awake()
        {
            
            
        }
        private void Start()
        {
            Spawn(5);
            GameManager.Instance.OnAsteroidDestroyed += HandleOnOnAsteroidDestroyed;

        }

        private void OnDisable()
        {
            GameManager.Instance.OnAsteroidDestroyed -= HandleOnOnAsteroidDestroyed;
        }

        private void HandleOnOnAsteroidDestroyed()
        {
            if (asteroidList.Count!=0)
            {
                asteroidList.RemoveAt(0);
            }

            if (asteroidList.Count <= GameManager.Instance.Difficulty)
            {
                GameManager.Instance.Difficulty++;
                Spawn(GameManager.Instance.Difficulty * 5);
            }

        }

        private void Update()
        {
            
        }
        void Spawn(int count)
        {
            Vector3 position = new Vector3();
            for (int i = 0; i < count; i++)
            {
                position.z = -Camera.main.transform.position.z;
                position = Camera.main.ScreenToWorldPoint(position);
                position.x = Random.Range(-ScreenSize.GetScreenToWorldWidth / 2, ScreenSize.GetScreenToWorldWidth / 2);
                position.y = (ScreenSize.GetScreenToWorldHeight / 2) - 1;

                AsteroidController asteroid = Instantiate(asteroidPrefabs[Random.Range(0, 3)], position, Quaternion.identity);
                asteroid.transform.parent = this.transform;

                asteroidList.Add(asteroid);
                
            }
        }


    }
}

