using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public TextMeshProUGUI scoreText;
    public float gameTime = 60f;

    private int score = 0;
    private float timer;
    private bool isGameOver = false;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        timer = gameTime;
    }

    void Update()
    {
        if (!isGameOver)
        {
            timer -= Time.deltaTime;
            UpdateTimerText();

            if (timer <= 0f)
            {
                EndGame();
            }
        }
    }

    public void AddScore(int value)
    {
        if (!isGameOver)
        {
            score += value;
            UpdateScoreText();
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);
        scoreText.text = "Time: " + minutes.ToString("D2") + ":" + seconds.ToString("D2");
    }

    void EndGame()
    {
        isGameOver = true;
        // Display game over message or perform other actions
    }
}
