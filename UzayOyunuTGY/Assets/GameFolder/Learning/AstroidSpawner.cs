using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UzayOyunuTGY.Learning
{
    public class AstroidSpawner : MonoBehaviour
    {
        [SerializeField]
        GameObject asteroidPrefab;

        //GeriSayimSayaci geriSayimSayaci;

        [SerializeField]
        float geriSayimSuresi = 2f;

        float timeElapsed;

        // Start is called before the first frame update
        void Start()
        {
            /*
            geriSayimSayaci = gameObject.AddComponent<GeriSayimSayaci>();
            geriSayimSayaci.ToplamSure = geriSayimSuresi;
            geriSayimSayaci.Calistir();
            */

        }

        // Update is called once per frame
        void Update()
        {
            /*
            if(geriSayimSayaci.Bitti)
            {
                //Spawn Game Object
                SpawnAsteroid();
                geriSayimSayaci.Calistir();
        
            }
            */

            timeElapsed += Time.deltaTime;
            if (timeElapsed > geriSayimSuresi)
            {
                SpawnAsteroid();
                timeElapsed = 0;
            }
        }

        void SpawnAsteroid()
        {
            Instantiate(asteroidPrefab, this.transform);
        }
    }
}