using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Hitbox : MonoBehaviour
{

    public int damage = 5;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            playerHealth.takeDamage(damage);
        }
    }
}
