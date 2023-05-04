using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadFirst() {
        SceneManager.LoadScene(1);
    }
    public void LoadSecond()
    {
        SceneManager.LoadScene(2);
    }
}
