using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UzayOyunuTGY.Controllers;

namespace UzayOyunuTGY.Combats
{
    public class LaunchProjectile : MonoBehaviour
    {
        [SerializeField] ProjectileController projectilePrefab;
        [SerializeField] Transform projectileTransform;

        public void LaunchAction()
        {
            GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>().FirePlay();
            ProjectileController newProjectile = Instantiate(projectilePrefab, projectileTransform.position, Quaternion.identity);
            newProjectile.transform.parent = GameObject.Find("Bullets").transform;
        }
    }
}

