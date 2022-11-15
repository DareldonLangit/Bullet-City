using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Gun : MonoBehaviour
{
    public int damage;
    public float canfire = 1f;
    public float firerate = 1f;

    public Transform firepoint;
    public GameObject bulletPrefab;
    public Button shootButton;

    private bool isHeld = false;
    private ButtonPressed buttonpressed;
    //public Animator weaponAnimation;
    bool fireAnimation = false;

    // Start is called before the first frame update
    void Start()
    {
        buttonpressed = FindObjectOfType<ButtonPressed>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {

        //FOR KEYBOARD
        //if (Input.GetButton("Fire1") && Time.time > canfire)
        //{
        //    Shoot();
        //    canfire = Time.time + firerate;
        //}

        //FOR JOYSTICK AND BUTTONS
        checkIfCanFire();
    }

    public void checkIfCanFire()
    {
        try
        {
            if (buttonpressed.isHeld && Time.time > canfire)
            {
                Shoot();
                canfire = Time.time + firerate;
            }
        }catch(Exception e)
        {

        }
    }

    public void Shoot()
    {
        AudioManager audioManager = FindObjectOfType<AudioManager>();

        //fireAnimation = !fireAnimation;
        //weaponAnimation.SetBool("isFiring", fireAnimation);
        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);

        Animator animator = gameObject.GetComponent<Animator>();
        animator.SetBool("shoot", true);

        try
        {
            audioManager.playSound("gunShot");
        }
        catch(Exception e)
        {

        }

        //if (animator.GetCurrentAnimatorStateInfo(0).IsName("Fire"))
        //{
        //    animator.SetBool("shoot", false);

        //}
        //else
        //{

        //}
        //FindObjectOfType<AudioManager>().playSound("gunShot");
    }

    public void cancelAnimation()
    {
        Animator animator = gameObject.GetComponent<Animator>();
        animator.SetBool("shoot", false);
    }
}
