using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Speed : MonoBehaviour
{
    public static Speed Inst { get; private set; }
    public float startSpeed = 5f;
    public float increaseBy = 0.1f;
    public float gameSpeed { get; private set; }
    SquareController squareController;
    Spawn spawn;
    private void Awake()
    {
        if (Inst != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Inst = this;
        }
    }
    private void OnDestroy()
    {
        if (Inst == this)
        {
            Inst = null;
        }
    }
    private void Start()
    {
        squareController = FindObjectOfType<SquareController>();
        spawn = FindObjectOfType<Spawn>();

        NewGame();
    }

    public void NewGame()
    {
        gameSpeed = startSpeed;
    }

    public void GameOver()
    {
        gameSpeed = 0f;
        enabled = false;

        squareController.gameObject.SetActive(false);
        spawn.gameObject.SetActive(false);
    }

    private void Update()
    {
        gameSpeed += increaseBy * Time.deltaTime;
    }


}

