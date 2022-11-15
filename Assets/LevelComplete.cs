using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    
    public GameObject completeUI;

    AudioSource source = null;
    bool isPlaying = false;

    private AudioManager audioManager;


    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.collider.tag == "Player")
    //    {


    //        collision.collider.gameObject.SetActive(false);
    //        FindObjectOfType<AudioManager>().stopSound("bgMusic");
    //        FindObjectOfType<AudioManager>().stopSound("Track2");
    //        source.Play();
    //        isPlaying = true;

    //    }
    //}


    private void Start()
    {
        Sound s = FindObjectOfType<AudioManager>().getSound("levelReached");
        source = s.source;
    }

    private void Update()
    {
        if (isPlaying == true)
        {
            if (!source.isPlaying)
            {
                completeUI.SetActive(true);

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && isPlaying == false)
        {
            isPlaying = true;
            audioManager.stopSound("bgMusic");
            audioManager.playSound("levelReached");
            Invoke("delayUI", 1f);
        }
    }

    private void delayUI()
    {
        completeUI.SetActive(true);
    }

}
