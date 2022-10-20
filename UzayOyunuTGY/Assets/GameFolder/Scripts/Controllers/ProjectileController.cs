using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UzayOyunuTGY.Abstracts.Controllers;
using UzayOyunuTGY.Combats;
using UzayOyunuTGY.Movements;

namespace UzayOyunuTGY.Controllers
{
    public class ProjectileController : LifeCycleController
    {
        [SerializeField] ExplosionController _explosion;
        [SerializeField] int speed=10;
        Rigidbody2D _rigidbody2D;
        Mover _mover;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _mover = GetComponent<Mover>();
        }
        private void Start()
        {
            _mover.MoveUp(_rigidbody2D, speed);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            AsteroidController enemy = collision.GetComponent<AsteroidController>();

            if (enemy != null)
            {
                if (collision.gameObject.tag == "destroyable")
                {
                    GameManager.Instance.CountAsteroid();
                    Transform tempTransform = enemy.gameObject.transform;
                    Destroy(enemy.gameObject);
                    _explosion.transform.localScale =_explosion.ExplosionScale(enemy.gameObject);
                    Instantiate(_explosion, tempTransform.transform.position, Quaternion.identity, GameObject.Find("Bullets").transform);
                }
            }
            DestroyObject(this.gameObject);
        }
        void DestroyObject(GameObject gameObject)
        {
            Destroy(gameObject);
        }
    }
}

