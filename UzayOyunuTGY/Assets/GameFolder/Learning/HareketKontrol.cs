using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UzayOyunuTGY.Learning
{
    public class HareketKontrol : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            // Uzay gemisini hareket ettir
            GetComponent<Rigidbody2D>().AddForce(Vector2.one * 5, ForceMode2D.Impulse);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}