using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoa : MonoBehaviour
{
    // shoot
    public bool isShootable = false;
    public GameObject bullet;
    public float bulletSpeed;
    public float timeBtwFire;
    private float fireCooldown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fireCooldown -= Time.deltaTime;
        if(fireCooldown < 0)
        {
            fireCooldown = timeBtwFire;
            // shoot
            EnemyFireBullet();
        }
    }
    void EnemyFireBullet()
    {
        var bullettmp = Instantiate(bullet, transform.position, Quaternion.identity);

        Rigidbody2D rb  = bullettmp.GetComponent<Rigidbody2D>();
        Vector3 playerPos = GameObject.Find("Player").transform.position;
        Vector3 direction = playerPos - transform.position;
        rb.AddForce(direction.normalized * bulletSpeed, ForceMode2D.Impulse);
    }
}
