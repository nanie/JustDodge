using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    private static SceneController instance;

    public static SceneController Instance
    {
        get
        {
            //If is called in a scene where it isn't added it creates the gameobject
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
        //Prevent more than one SceneController
        if (instance!=null && instance != this)
        {
            Destroy(instance.gameObject);
        }        
        instance = this;
    }

    //Go to main game scene
    public void GoToMainGame()
    {
        SceneManager.LoadScene("MainGame");
    }
    //Go to Score board scene
    public void GoToScoreBoard()
    {
        SceneManager.LoadScene("Score");
    }

}
