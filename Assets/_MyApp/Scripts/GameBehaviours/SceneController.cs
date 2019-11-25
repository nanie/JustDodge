using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private static SceneController instance;

    public static SceneController Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("SceneManager");
                instance = go.AddComponent<SceneController>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void GoToMainGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void GoToScoreBoard()
    {
        SceneManager.LoadScene("Score");
    }
}
