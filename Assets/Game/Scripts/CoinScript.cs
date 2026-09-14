using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public GameObject coin;
    public void GetBumped()
    {
        Vector2 location = new Vector2(Random.Range(-8, 8), Random.Range(-4, 4));
        Instantiate(coin, location, Quaternion.identity);
        Destroy(gameObject);
    }
}
