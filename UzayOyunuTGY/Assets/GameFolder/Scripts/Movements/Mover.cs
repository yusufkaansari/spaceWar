using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UzayOyunuTGY.Enums;

namespace UzayOyunuTGY.Movements
{
    public class Mover : MonoBehaviour
    {       

        float _multiplierconst = 30;

        public void MoveXDirection(Rigidbody2D _rigidbody2D,float _directionAxis, int _moveForce)
        {

            _rigidbody2D.velocity = new Vector2(_directionAxis * _moveForce * Time.deltaTime * _multiplierconst, _rigidbody2D.velocity.y);
        }
        public void MoveYDirection(Rigidbody2D _rigidbody2D, float _directionAxis, int _moveForce)
        {

            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x,_directionAxis * _moveForce * Time.deltaTime * _multiplierconst);
        }
        public void MoveUp(Rigidbody2D _rigidbody2D,int speed)
        {
            _rigidbody2D.AddForce(new Vector2(0, speed), ForceMode2D.Impulse);
        }
        public void SetMovementAsteroid(Rigidbody2D _rigidbody2D,float _multiplierconstTorque)
        {
            float direction = Random.Range(0f, 1.0f);
            if (direction < 0.5)
            {
                _rigidbody2D.AddForce(new Vector2(Random.Range(-2.5f, -1f), Random.Range(-2.5f, -1f)), ForceMode2D.Impulse);
                _rigidbody2D.AddTorque(direction * _multiplierconstTorque);
            }
            else
            {
                _rigidbody2D.AddForce(new Vector2(Random.Range(1.0f, 2.5f), Random.Range(-2.5f, -1f)), ForceMode2D.Impulse);
                _rigidbody2D.AddTorque(direction * -(_multiplierconstTorque));
            }
        }
    }
}


