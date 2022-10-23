using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UzayOyunuTGY.Controllers;
using UzayOyunuTGY.Spawners;
using UzayOyunuTGY.Utilities;

public class GameManager : MonoBehaviour
{
    int score;
    [SerializeField] int _difficulty=1;

    

    public int Difficulty
    {
        get { return _difficulty; }
        set { _difficulty = value; }
    }


    public static GameManager Instance { get; private set; }
    public event System.Action OnAsteroidDestroyed;
    public event System.Action<int> OnScoreChanged;
    public event System.Action OnGameStarted;
    public event System.Action OnGameOver;
    private void Awake()
    {
        SingletonThisGameObject();
        EkranHesaplayicisi.Initialization();
    }

    private void SingletonThisGameObject()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void CountAsteroid()
    {
        
        OnAsteroidDestroyed?.Invoke();
        
    }
    public void IncreaseScore(int sizePoint)
    {
        score += sizePoint;
        OnScoreChanged?.Invoke(score);
    }

    public void StartGame()
    {
        
        score = 0;
        OnGameStarted?.Invoke();
    }

    public void SetGameOver()
    {
        OnGameOver?.Invoke();
        
    }
}
