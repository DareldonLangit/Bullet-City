using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PausedScript : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject pauseImage;
    public GameObject controllerUI;
    public bool isPause = false;

    public void Resume()
    {
        isPause = false;
        FindObjectOfType<Playermovement>().enabled = true;
        foreach(Transform child in controllerUI.transform)
        {
            child.gameObject.SetActive(true);
        }
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        pauseImage.SetActive(true);

    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
        isPause = false;
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }


    public void Paused()
    {
        isPause = true;
        FindObjectOfType<Playermovement>().enabled = false;
        foreach (Transform child in controllerUI.transform)
        {
            child.gameObject.SetActive(false);
        }
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
