using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UzayOyunuTGY.Learning
{
    public class AstroidDestroyer : MonoBehaviour
    {
        [SerializeField] GameObject explosionPrefab;
        [SerializeField] GameObject astroidSpawner;

        //float timeCountdown=2f;
        float timeCountdown;
        float timeElapsed;

        private void Awake()
        {
            timeCountdown = Random.Range(1f, 4f);
        }
        void Update()
        {
            //DestroyDependOnTime();
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "destroyable")
            {
                GameObject tempTransform = collision.gameObject;
                Destroy(collision.gameObject);
                Instantiate(explosionPrefab, tempTransform.transform.position, Quaternion.identity, astroidSpawner.transform);
                Destroy(tempTransform);
            }
        }
        private void DestroyDependOnTime()
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed > timeCountdown)
            {
                // your code is here..
                // Uzay gemisine çarpýnca patlayacak o yüzden aþaðýdaki kod geçersiz
                Instantiate(explosionPrefab, this.transform.position, Quaternion.identity, astroidSpawner.transform);
                Destroy(gameObject);
                timeElapsed = 0;
            }
        }

    }
}
