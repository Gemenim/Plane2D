using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] Plane _plane;
    [SerializeField] EmenyGenerator _generator;
    [SerializeField] StartScreen _startScreen;
    [SerializeField] EndScreen _endScreen;

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
    }

    private void OnEnable()
    {
        _startScreen.PlayButtonClicked += OnPlayButtonClick;
        _endScreen.RestartButtonClicked += OnRestartButtonClick;
        _plane.GameOver += OnGameOver; 
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClicked -= OnPlayButtonClick;
        _endScreen.RestartButtonClicked -= OnRestartButtonClick;
        _plane.GameOver -= OnGameOver;
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;
        _endScreen.Open();
    }

    private void OnRestartButtonClick()
    {
        _endScreen.Close();
        StartGame();
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1.0f;
        _plane.Reset();
    }
}
