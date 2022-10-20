using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UzayOyunuTGY.Controllers
{
    public class BackgroundController : MonoBehaviour
    {
        MeshRenderer _meshRenderer;
        float scrollSpeed = 0.1f;
        private void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }
        private void Update()
        {
            float offset = scrollSpeed * Time.time;
            _meshRenderer.material.SetTextureOffset("_MainTex", new Vector2(0, offset));
        }
    }
}

