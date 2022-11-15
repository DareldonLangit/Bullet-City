using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region
    public int maxHealth = 100;
    public int coinPoints = 5;
    int currentHealth;
    public int damage = 20;

    public HealthBar healthbar;
    //public GameObject popupCoin;
    //public GameObject deathAnimation;
    public bool hasDeathAnimation;
    #endregion

    #region
    private AudioManager audioManager;
    private GameManager gameManager;
    #endregion


    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        gameManager = FindObjectOfType<GameManager>();
        currentHealth = maxHealth;
        healthbar.setMaxHealth(maxHealth);
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.setHealth(currentHealth);
        //FindObjectOfType<AudioManager>().playSound("enemyHit");
        if (currentHealth <= 0)
        {
            //if (hasDeathAnimation)
            //{
            //    deathAnimation.transform.localScale = gameObject.transform.localScale;
            //    Instantiate(deathAnimation, gameObject.transform.position, gameObject.transform.rotation);
            //    destroyEnemy();
            //}
            //else
            //{
            //    destroyEnemy();
            //}

            destroyEnemy();
        }
    }

    public void swordSwing()
    {
        audioManager.playSound("swordSwing");
    }


    void destroyEnemy()
    {

        //popupCoin.GetComponent<CoinPopScript>().coins = coinPoints;
        //Instantiate(popupCoin, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
        gameManager.addAmountToCoins(coinPoints);
        audioManager.playSound("enemyDead");

    }


}
