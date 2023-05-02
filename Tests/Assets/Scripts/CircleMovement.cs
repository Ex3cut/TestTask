using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class CircleMovement : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] Text score;
    int scoreInt;
    void Start()
    {
        GetComponent<Rigidbody2D>().simulated = false;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;   
    }
    public void Push(Vector2 dir)
    {
        transform.parent = null;
        GetComponent<Rigidbody2D>().simulated = true;
        GetComponent<Rigidbody2D>().velocity = dir.normalized * speed;
    }
    private void Update()
    {
        score.text = scoreInt.ToString();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Points")
        {
            scoreInt += 1;
        }
        if (collision.gameObject.tag == "Pain")
        {
            scoreInt -= 10;
        }
    }
}
