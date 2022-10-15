using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UzayOyunuTGY.Learning
{
    public class ExplosionDestroyer : MonoBehaviour
    {
        float timeCountdown = 1f;
        float timeElapsed;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed > timeCountdown)
            {
                // your code is here..
                Destroy(gameObject);
                timeElapsed = 0;
            }
        }
    }
}
