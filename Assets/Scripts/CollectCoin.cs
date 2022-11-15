using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{

    private bool isCollected = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isCollected == false && collision.tag == "Player" && collision.GetType() == typeof(BoxCollider2D)){
            GameManager gameManager = FindObjectOfType<GameManager>();

            isCollected = true;
            Destroy(gameObject);
            gameManager.addSingleCoin();
        }
    }
}
