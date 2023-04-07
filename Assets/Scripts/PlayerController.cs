using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Copyright (c) Sperma Games Inc.
//The game was made by the greatest developer of all time overnight.
//Who reads that gay btw. Mwah-ha-ha!

public class PlayerController : MonoBehaviour
{
    [Header("Game Handle")]
    public int score;
    public bool gameOver;
    [Header("Horizontal")]
    public float speed;
    public float moveInput;
    [Header("Vertical")]
    public float jumpForce;
    [Header("Other")]
    public TMP_Text textRestart;

    private Rigidbody2D rb;

    private void Start()
    {
        textRestart.enabled = false;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Move player by A and D keys (or <- and ->)
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // Calculate score
        if ((int)transform.position.y > score) score = (int)transform.position.y;


        if (rb.velocity.y < 0)
        {
            // If player falls
            rb.gravityScale = 2;
        }
        else
        { 
            // If no
            rb.gravityScale = 1;
        }

        if (gameOver && Input.GetKeyDown(KeyCode.Space)) RestartGame();
    }

    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    public void Kill()
    {
        textRestart.enabled = true;
        gameOver = true;
        transform.position = new Vector2(-99999, -99999);// Go chill at the corner of the map lol
    }

    public void RestartGame()
    {
        textRestart.enabled = false;
        gameOver = false;
        score = 0;
        Application.LoadLevel(Application.loadedLevel);
    }
}
