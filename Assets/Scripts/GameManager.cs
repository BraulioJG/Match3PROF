using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float gameTime = 10;
    public float matchSeconds = 10;
    public float secondsForMatchStart = 5;
    public float currentSecondsForMatchStart = 5;
    public GameObject gameOver;
    public GameObject start;
    public AudioClip backgroundMusic;
    public AudioClip gameStartSound;

    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public enum GameState
    {
        Start,
        InGame,
        GameOver
    }

    public GameState gameState;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        } else if(Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public int points = 0;
    public UnityEvent OnPointsUpdated;

    public void Update()
    {
        if (gameState == GameState.Start)
        {
            start.SetActive(true);
            gameOver.SetActive(false);
            audioSource.clip = gameStartSound;
        }

        if (gameState == GameState.InGame)
        {
            gameOver.SetActive(false);
            audioSource.clip = backgroundMusic;
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            currentSecondsForMatchStart = currentSecondsForMatchStart - Time.deltaTime;
            start.SetActive(false);
            if (currentSecondsForMatchStart <= 0)
            {
                matchSeconds = matchSeconds - Time.deltaTime;
            }

            if (matchSeconds <= 0)
            {
                gameState = GameState.GameOver;
            }
        }

        if(gameState == GameState.GameOver)
        {
            if (audioSource.clip == backgroundMusic && audioSource.isPlaying)
            {
                audioSource.Stop();
                audioSource.clip = gameStartSound;
                audioSource.Play();
            }
            
            gameOver.SetActive(true);
        }
    }

    public void AddPoints(int newPoints)
    {
        points += newPoints;
        OnPointsUpdated?.Invoke();
    }
}
