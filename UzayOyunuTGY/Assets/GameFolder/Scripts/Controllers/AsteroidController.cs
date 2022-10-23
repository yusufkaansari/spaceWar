using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UzayOyunuTGY.Combats;
using UzayOyunuTGY.Movements;

namespace UzayOyunuTGY.Controllers
{
    public class AsteroidController : MonoBehaviour
    {
        Rigidbody2D _rigidbody2D;
        Mover _mover;
        [SerializeField] ExplosionController _explosion;
        
        [SerializeField] public int _sizePoint;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _mover = GetComponent<Mover>();
        }
        private void Start()
        {
            _mover.SetMovementAsteroid(_rigidbody2D,-2f);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            SpaceshipController enemy = collision.gameObject.GetComponent<SpaceshipController>();

            if (enemy != null)
            {
                if (collision.gameObject.tag == "destroyable")
                {                                      
                    Transform tempTransform = enemy.gameObject.transform;
                    Destroy(enemy.gameObject);
                    _explosion.transform.localScale = _explosion.ExplosionScale(enemy.gameObject);
                    Instantiate(_explosion, tempTransform.transform.position, Quaternion.identity, GameObject.Find("Bullets").transform);
                    GameManager.Instance.SetGameOver();
                }
            }
        }        
    }
}

