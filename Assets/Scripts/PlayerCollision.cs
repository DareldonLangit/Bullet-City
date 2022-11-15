using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.collider.CompareTag("Platforms"))
        //{
        //    GameObject.Find("Player").GetComponent<Animator>().SetBool("isJumping", false);
        //    Debug.Log("Hell");
        //}

        if (collision.collider.tag == "DeathObstacle/Spike")
        {
            FindObjectOfType<AudioManager>().playSound("enemyHit");
            FindObjectOfType<GameManager>().playerDeath();
            gameManager.playerDeath();

        }

        if (collision.collider.tag == "DeathObstacle/Water")
        {
            FindObjectOfType<GameManager>().playerDeath();
            FindObjectOfType<AudioManager>().playSound("waterSplash");
            gameManager.playerDeath();

        }


        if (collision.collider.CompareTag("Platforms"))
        {
            FindObjectOfType<Playermovement>().animator.SetBool("isJumping", false);

        }


    }
}
