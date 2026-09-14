using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

   
    public TextMeshProUGUI scoreText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + GameManager.instance.Score;
    }

    public void ClickRetry()
    {
        GameManager.instance.Score = 0;
        GameManager.instance.time = 120f;
        SceneManager.LoadScene("Game");
    }
    public void ClickMenu()
    {
        GameManager.instance.Score = 0;
        GameManager.instance.time = 120f;
        SceneManager.LoadScene("Menu");
    }

}
