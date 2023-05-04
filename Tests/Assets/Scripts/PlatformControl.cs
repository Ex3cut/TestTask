using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformControl : MonoBehaviour
{
    [SerializeField]public float speed;
    [SerializeField] Vector2 pushDir;
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        GetComponent<Rigidbody2D>().velocity = Vector2.right * x * speed;

        if (Input.GetKeyDown(KeyCode.W))
        {
            pushDir.x += 1;
            if (pushDir.x > 10) pushDir.x = 10;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            pushDir.x -= 1;
            if (pushDir.x < -10) pushDir.x = -10;
        }

        if (transform.childCount > 0 && Input.GetKeyDown(KeyCode.Space))
        {
            CircleMovement circle = GetComponentInChildren<CircleMovement>();
            circle.Push(pushDir);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
}
