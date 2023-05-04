using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Speed : MonoBehaviour
{
    public static Speed Inst { get; private set; }
    public float startSpeed;
    public float increaseBy;
    public float gameSpeed { get; private set; }
    public SquareController squareController;
    Spawn spawn;
    public TextMeshProUGUI scoreText;
    public Button restartButton;
    public Button menuButton;
    public Button continueButton;
    float holdingSpeed;
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
        enabled = true;
        squareController.allPointsFloat = 0f;
        gameSpeed = startSpeed;
        squareController.gameObject.SetActive(true);
        spawn.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(false);
        menuButton.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(false);
        ForRestart[] res = FindObjectsOfType<ForRestart>();

        foreach (var obstacle in res) {
            Destroy(obstacle.gameObject);
        }

    }

    public void GameOver()
    {
        gameSpeed = 0f;
        enabled = false;

        squareController.gameObject.SetActive(false);
        spawn.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(true);
        menuButton.gameObject.SetActive(true);
        continueButton.gameObject.SetActive(false);
    }

    public void Continue()
    {
        enabled = true;
        gameSpeed = holdingSpeed;
        squareController.gameObject.SetActive(true);
        spawn.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(false);
        menuButton.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(false);
    }

    public void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            holdingSpeed = gameSpeed;
            gameSpeed = 0f;
            enabled = false;
            spawn.gameObject.SetActive(false);
            restartButton.gameObject.SetActive(true);
            menuButton.gameObject.SetActive(true);
            continueButton.gameObject.SetActive(true);
        }
        
    }

    private void Update()
    {
        gameSpeed += increaseBy * Time.deltaTime;
        scoreText.text = squareController.allPointsFloat.ToString();
        Pause();
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}

