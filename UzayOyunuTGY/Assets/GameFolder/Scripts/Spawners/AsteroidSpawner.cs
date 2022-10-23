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
            
            //Spawn(1);
            GameManager.Instance.OnAsteroidDestroyed += HandleOnOnAsteroidDestroyed;
            GameManager.Instance.OnGameStarted += SpawnAsteroid;
            GameManager.Instance.OnGameOver += DestroyAllAsteroids;
            
        }
        private void OnDisable()
        {
            GameManager.Instance.OnAsteroidDestroyed -= HandleOnOnAsteroidDestroyed;
            GameManager.Instance.OnGameStarted -= SpawnAsteroid;
        }
        void SpawnAsteroid()
        {
            Spawn(1);
        }
        void DestroyAllAsteroids()
        {
            foreach (var astroid in asteroidList)
            {
                Destroy(astroid.gameObject);
            }
            asteroidList.Clear();
        }
        private void HandleOnOnAsteroidDestroyed()
        {
            if (asteroidList.Count!=0)
            {
                asteroidList.RemoveAt(0);
            }
            if(asteroidList.Count==0)
            {
                GameManager.Instance.Difficulty++;
                Spawn(GameManager.Instance.Difficulty * 1);
            }

            //if (asteroidList.Count < GameManager.Instance.Difficulty)
            //{
            //    GameManager.Instance.Difficulty++;
            //    Spawn(GameManager.Instance.Difficulty * 1);
            //}

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

