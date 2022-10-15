using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UzayOyunuTGY.Combats;
using UzayOyunuTGY.Enums;
using UzayOyunuTGY.Movements;
using UzayOyunuTGY.Utilities;

namespace UzayOyunuTGY.Controllers
{
    public class SpaceshipController : MonoBehaviour
    {
        [SerializeField] int moveForce = 4;

        Rigidbody2D _rigidbody2D;
        Mover _mover;
        PcInputController _input;
        Vector3 _position;

        LaunchProjectile _launchProjectile;
        private void Awake()
        {
            // cash progress
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _mover = GetComponent<Mover>();
            _launchProjectile = GetComponent<LaunchProjectile>();
            _input = new PcInputController();
        }
        private void Update()
        {
            //input progress
            if (_input.SpaceButtonDown)
            {
                _launchProjectile.LaunchAction();
            }
        }

        private void FixedUpdate()
        {
            //physics progress

            if (_input.GetHorizontalX !=0)
            {
                _mover.MoveXDirection(_rigidbody2D, _input.GetHorizontalX, moveForce);
            }

            if (_input.GetVerticalY != 0)
            {
                _mover.MoveYDirection(_rigidbody2D, _input.GetVerticalY, moveForce);
            }

        }

        

    }
}

