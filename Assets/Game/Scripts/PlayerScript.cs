using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D RB;
    public SpriteRenderer SR;
    public float Speed = 5;

    void Start()
    {
        
     
    }

    
    void Update()
    {
        
        Vector2 vel = new Vector2(0,0);
        
        
        if (Keyboard.current.wKey.isPressed)
        {
            vel.y = Speed;
        }

        if (Keyboard.current.aKey.isPressed)
        {
            vel.x = -Speed;
        }

        if (Keyboard.current.sKey.isPressed)
        {
            vel.y = -Speed;
        }

        if (Keyboard.current.dKey.isPressed)
        {
            vel.x = Speed;
        }

        
        RB.linearVelocity = vel;
    }

   
    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.CompareTag("Hazard"))
        {
            
            Die();
            
        }
        
       
        CoinScript coin = other.gameObject.GetComponent<CoinScript>();
        
        if (coin != null)
        {
           
            coin.GetBumped();
            GameManager.instance.AddScore();
        }
    }

    


    
    public void Die()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        SceneManager.LoadScene("Lose");
    }

    public void HidePlayer()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }
}