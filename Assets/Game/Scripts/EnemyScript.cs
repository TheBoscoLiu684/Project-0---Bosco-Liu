using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform target;
    public float speed = 0.5f;
    public float timer = 5f;
    void Start()
    {
        FindPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            FindPlayer();
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed*Time.deltaTime);

        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            speed += 0.2f;
            timer = 5f;
        }
    }

    void FindPlayer()
    {
        GameObject player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            target = player.transform;
        }
    }

}
