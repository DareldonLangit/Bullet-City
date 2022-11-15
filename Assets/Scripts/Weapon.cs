using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;
    //public Animator weaponAnimation;
    bool fireAnimation = false;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //fireAnimation = !fireAnimation;
            //weaponAnimation.SetBool("isFiring", fireAnimation);
            Shoot();
        }

    }

    //void Shoot()
    //{

    //    Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    //    FindObjectOfType<AudioManager>().playSound("gunShot");




    //}

    public void Shoot()
    {
        //fireAnimation = !fireAnimation;
        //weaponAnimation.SetBool("isFiring", fireAnimation);
        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Debug.Log("firing");
 
        //   FindObjectOfType<AudioManager>().playSound("gunShot");
    }

    void destroyBullet()
    {
        DestroyImmediate(bulletPrefab, true);
    }
}
