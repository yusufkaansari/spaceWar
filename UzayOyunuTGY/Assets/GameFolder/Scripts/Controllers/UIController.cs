using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UzayOyunuTGY.Controllers
{
    public class UIController : MonoBehaviour
    {
        [SerializeField]
        GameObject gameNameText;

        [SerializeField]
        GameObject gameOverText;

        [SerializeField]
        Text scoreText;

        [SerializeField]
        GameObject playButton;

        private void Start()
        {
            gameOverText.gameObject.SetActive(false);
            scoreText.gameObject.SetActive(false);
            GameManager.Instance.OnGameStarted += GameStarted;
            GameManager.Instance.OnScoreChanged += HandleOnScoreChanged;
            GameManager.Instance.OnGameOver += HandleOnGameOver;
        }
        private void OnDisable()
        {
            GameManager.Instance.OnGameStarted -= GameStarted;
            GameManager.Instance.OnScoreChanged -= HandleOnScoreChanged;
        }
        void GameStarted()
        {
            playButton.gameObject.SetActive(false);
            scoreText.gameObject.SetActive(true);
            gameNameText.gameObject.SetActive(false);
            gameOverText.gameObject.SetActive(false);
            scoreText.text = $"SCORE: 0";
        }
        void HandleOnScoreChanged(int score = 0)
        {
            scoreText.text = $"SCORE: {score}";
        }
        void HandleOnGameOver()
        {
            gameOverText.gameObject.SetActive(true);
            playButton.gameObject.SetActive(true);
            gameNameText.gameObject.SetActive(true);
            
        }

    }
}

