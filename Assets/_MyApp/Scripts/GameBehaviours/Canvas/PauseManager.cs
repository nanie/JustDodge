using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject CustomizationCamera;
    public GameObject PauseCanvas;
    public GameObject GameCanvas;
    public Button btnResume; 
    bool paused = false;

    void Start()
    {
        //Registers onclick call to resume button
        btnResume.onClick.AddListener(ResumeGame);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            //If game paused, resume game
            if(paused)
            {
                ResumeGame();
            }
            else
            {
            //If game not paused, pause game
                PauseGame();
            }
            //Invert boolean
            paused = !paused;
        }
    }

    public void PauseGame()
    {
        //Stop everything time scaled on game
        Time.timeScale = 0;
        //Show Camera and Canvas for paused game
        mainCamera.SetActive(false);
        CustomizationCamera.SetActive(true);
        PauseCanvas.SetActive(true);
        GameCanvas.SetActive(false);
    }

    public void ResumeGame()
    {  
        //Resume everything time scaled on game
        mainCamera.SetActive(true);
        //Show Camera and Canvas for game
        CustomizationCamera.SetActive(false);
        PauseCanvas.SetActive(false);
        GameCanvas.SetActive(true);
        Time.timeScale = 1;
    }
}
