using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public TextMeshProUGUI scoreText;

    public int score = 0;
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
    
    }

    void Update()
    {
        
    }

    public void AddScore(int value)
    {

            score += value;
            UpdateScoreText();
        
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

   
   
}
