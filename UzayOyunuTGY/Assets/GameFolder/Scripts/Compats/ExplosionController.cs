using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UzayOyunuTGY.Abstracts.Controllers;

namespace UzayOyunuTGY.Combats
{
    public class ExplosionController : LifeCycleController
    {
        private void Awake()
        {
            base.maxLifeTime = 1f;
        }

        public Vector3 ExplosionScale(GameObject _gameObject)
        {
            float collinderSize = _gameObject.gameObject.GetComponent<BoxCollider2D>().size.magnitude;
            Vector3 scale = new Vector3(collinderSize / 2 * 0.5f, collinderSize / 2 * 0.5f);
            return scale;
        }
    }
}

