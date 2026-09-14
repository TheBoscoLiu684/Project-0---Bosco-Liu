using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static GameManager instance;
    public int Score = 0;
    public TextMeshProUGUI ScoreText;

    public float time = 120f;
    public TextMeshProUGUI TimerText;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            time -= Time.deltaTime;

            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.FloorToInt(time % 60);

            if (TimerText != null)
            {
                TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }

            if (time <= 0)
            {
                time = 0;
                SceneManager.LoadScene("Win");
            }
        }
    }

    public void AddScore()
    {
        Score++;
        ScoreText.text = "Score: " + Score;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Game")
        {
            GameObject scoreObject = GameObject.Find("Score");
            GameObject timerObject = GameObject.Find("Timer");
            if (scoreObject != null)
            {
                ScoreText = scoreObject.GetComponent<TextMeshProUGUI>();
            }
            if (timerObject != null)
            {
                TimerText = timerObject.GetComponent<TextMeshProUGUI>();
            }
            if (ScoreText != null)
            {
                ScoreText.text = "Score: " + Score;
            }
            if (TimerText != null)
            {
                TimerText.text = "02:00";
            }
        }
    }
}
