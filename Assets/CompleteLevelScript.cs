using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CompleteLevelScript : MonoBehaviour
{

    public GameObject controllerUI;
    public GameObject animationPanel;

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        animationPanel.SetActive(true);
        Invoke("delayToMenu", 2f);
        
    }

    public void hideControllerUI()
    {
        FindObjectOfType<Playermovement>().enabled = false;
        controllerUI.SetActive(false);
        foreach(Transform child in controllerUI.transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    public void playLevelCompleteSound()
    {
        audioManager.playSound("levelComplete");
    }

    private void delayToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
