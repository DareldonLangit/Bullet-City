using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTheGun : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform firePoint;

    float shootTime = 1f;

    private void Start()
    {
        InvokeRepeating("Fire", 0, 1f);
    }

    private void Fire()
    {
        FindObjectOfType<Gun>().Shoot();
    }

}
