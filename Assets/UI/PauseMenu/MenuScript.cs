using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    bool isPaused;
    public GameObject PauseMenu;
    public GameObject PauseButtonInGame;

    public void Start()
    {
        PauseMenu.SetActive(false);
        PauseButtonInGame.SetActive(true);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenuActivation();
        }
    }

    public void PauseMenuActivation()
    {
        {
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0 : 1;
            PauseMenu.SetActive(isPaused);
            PauseButtonInGame.SetActive(!isPaused);
        }
        return;
    }
    public void MenuButtonOnClick()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void QuitButtonOnClick()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
				Application.Quit();
        #endif
    }
}
