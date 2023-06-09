using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class SquareController : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    private int doubleJump = 2;
    public Speed allPoints;
    public float allPointsFloat;

    private int jumped;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && jumped < doubleJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumped++;
        }
        allPoints.scoreText.text = allPointsFloat.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumped = 0;
        }
        if (collision.gameObject.CompareTag("Pain2"))
        {
            FindObjectOfType<Speed>().GameOver();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlusPoints"))
        {
            allPointsFloat += 10;
            Destroy(collision.gameObject);
        }
    }
}
