using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class TimerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float time;
    public TextMeshProUGUI timerText;
    void Start()
    {
        time = 120f;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        if(time <= 0)
        {
            PlayerScript player = FindFirstObjectByType<PlayerScript>();
            player.HidePlayer();
            SceneManager.LoadScene("Win");
        }
    }
}
