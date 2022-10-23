using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UzayOyunuTGY.Controllers;
using UzayOyunuTGY.Utilities;

namespace UzayOyunuTGY.Spawners
{
    public class SpaceshipSpawner : MonoBehaviour
    {
        [SerializeField]
        SpaceshipController spaceshipPrefab;

        private void Start()
        {
            GameManager.Instance.OnGameStarted += SpawnSpaceship;
            
        }
        private void OnDisable()
        {
            GameManager.Instance.OnAsteroidDestroyed -= SpawnSpaceship;
        }
        void SpawnSpaceship()
        {
            SpaceshipController _spaceship = Instantiate(spaceshipPrefab);
            _spaceship.transform.position = new Vector3(0, EkranHesaplayicisi.Alt + _spaceship.GetComponent<BoxCollider2D>().size.y);
        }
    }
}

