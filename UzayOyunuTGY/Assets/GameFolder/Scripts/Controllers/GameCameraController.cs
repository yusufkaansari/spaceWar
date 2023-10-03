using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UzayOyunuTGY.Utilities;

namespace UzayOyunuTGY.Controllers
{
    public class GameCameraController : MonoBehaviour
    {
        [SerializeField]
        Camera _gameCamera;
        EdgeCollider2D _edgeCollider;
   
        //These are the positions and dimensions of the Camera view in the Game view
        float m_ViewPositionX, m_ViewPositionY, m_ViewWidth, m_ViewHeight;
        private void Awake()
        {
            _edgeCollider = _gameCamera.gameObject.AddComponent<EdgeCollider2D>();
            _edgeCollider.points = new Vector2[5];
        }
        private void Start()
        {
            SetFullScreenCollider();
        }
        void SetFullScreenCollider()
        {
            Vector2 [] colliderpoints;
            colliderpoints = _edgeCollider.points;
            colliderpoints[0] = new Vector2(EkranHesaplayicisi.Sol - 0.128f, EkranHesaplayicisi.Alt);
            colliderpoints[1] = new Vector2(EkranHesaplayicisi.Sol, EkranHesaplayicisi.Ust);
            colliderpoints[2] = new Vector2(EkranHesaplayicisi.Sag, EkranHesaplayicisi.Ust);
            colliderpoints[3] = new Vector2(EkranHesaplayicisi.Sag + 0.128f, EkranHesaplayicisi.Alt);
            colliderpoints[4] = colliderpoints[0] - new Vector2(0,0.128f);

            _edgeCollider.points = colliderpoints;
        }
        void SetOrthographicCamera()
        {
            //This sets the Camera view rectangle to be in the bottom corner of the screen
            m_ViewPositionX = 0;
            m_ViewPositionY = 0;

            //This sets the Camera view rectangle to be smaller so you can compare the orthographic view of this Camera with the perspective view of the Main Camera
            m_ViewWidth = 0.5f;
            m_ViewHeight = 0.5f;

            //This enables the Camera (the one that is orthographic)
            _gameCamera.enabled = true;

            //If the Camera exists in the inspector, enable orthographic mode and change the size
            if (_gameCamera)
            {
                //This enables the orthographic mode
                _gameCamera.orthographic = true;
                //Set the size of the viewing volume you'd like the orthographic Camera to pick up (5)
                _gameCamera.orthographicSize = 9.0f;
                //Set the orthographic Camera Viewport size and position
                _gameCamera.rect = new Rect(m_ViewPositionX, m_ViewPositionY, m_ViewWidth, m_ViewHeight);
            }
        }
    }
}

