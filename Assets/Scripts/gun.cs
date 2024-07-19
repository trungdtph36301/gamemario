using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePos;
    public float TimeBtwFire = 0.2f;
    public float bulletForce;
    private float timeBtwFire;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeBtwFire -= Time.deltaTime;
        if (Input.GetMouseButton(0) && timeBtwFire < 0)
        {
            FireBullet();
        }
    }
    void FireBullet()
    {
        timeBtwFire = TimeBtwFire;

        // Instantiate bullet at the fire position
        GameObject bulletTmp = Instantiate(bullet, firePos.position, firePos.rotation);

        // Get the Rigidbody2D component of the bullet
        Rigidbody2D rb = bulletTmp.GetComponent<Rigidbody2D>();

        // Determine the direction based on the character's orientation
        Vector2 fireDirection = transform.right;

        // If the character is facing left (assuming negative scale means facing left)
        if (transform.localScale.x < 0)
        {
            fireDirection = -transform.right; // Change the direction to left
        }

        // Apply force to the bullet in the determined direction
        rb.AddForce(fireDirection * bulletForce, ForceMode2D.Impulse);
    }

}
