using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 0;
    public float speed = 20f;
    public Rigidbody2D rb;
    public Vector2 bulletForce;
    public Transform player;

    private void Awake()
    {
        GameObject weaponHolder = GameObject.Find("WeaponHolder");
        WeaponSwitching weaponSwitching = weaponHolder.GetComponent<WeaponSwitching>();

        //int i = 0;
        //Debug.Log(weaponSwitching.selectedWeapon);
        //foreach (Transform weapon in weaponHolder.transform)
        //{

        //    Debug.Log(weapon.name);
        //    if (i == weaponSwitching.selectedWeapon)
        //    {
        //        damage = weapon.gameObject.GetComponent<Gun>().damage;
        //    }

        //    i++;
        //}

        int[] gunDamage = { 6, 8 };
        damage = gunDamage[weaponSwitching.selectedWeapon];
    }

    private void Start()
    {

        rb.velocity = transform.right * speed;
        Destroy(this.gameObject, 2f);
    }

    private void OnTriggerEnter2D(Collider2D hitinfo)
    {
        ////Enemy enemy = collision.GetComponent<Enemy>();
        //EnemyWithWeapon enemy2 = collision.GetComponent<EnemyWithWeapon>();

        //if (enemy != null)
        //{

        //    if (rb.velocity.x < 0)
        //    {
        //        enemy.gameObject.GetComponent<Rigidbody2D>().AddForce(-bulletForce, ForceMode2D.Force);
        //    }
        //    else
        //    {
        //        enemy.gameObject.GetComponent<Rigidbody2D>().AddForce(bulletForce, ForceMode2D.Force);

        //    }

        //    enemy.takeDamage(damage);

        //}

        //if (enemy2 != null)
        //{
        //    enemy2.takeDamage(damage);
        //}

        Enemy enemy = hitinfo.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.takeDamage(damage);

            //Debug.Log("Damage: " + damage);

        }


        if (hitinfo.tag != "Coins" && hitinfo.gameObject.name != "HotZone")
        {
            FindObjectOfType<AudioManager>().playSound("bulletImpact");
            Destroy(gameObject);
        }
    }
}
