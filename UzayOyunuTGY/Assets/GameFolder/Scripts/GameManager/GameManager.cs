using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UzayOyunuTGY.Controllers;
using UzayOyunuTGY.Utilities;

public class GameManager : MonoBehaviour
{
    [SerializeField] int _difficulty=1;

    public int Difficulty
    {
        get { return _difficulty; }
        set { _difficulty = value; }
    }


    public static GameManager Instance { get; private set; }
    public event System.Action OnAsteroidDestroyed;
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

}
