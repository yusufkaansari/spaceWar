using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UzayOyunuTGY.Controllers
{
    public class PcInputController
    {
        public float GetHorizontalX => Input.GetAxis("Horizontal");
        public float GetVerticalY => Input.GetAxis("Vertical");
        public bool SpaceButtonDown => Input.GetButtonDown("Jump");
    }
}

