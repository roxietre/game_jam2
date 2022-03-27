using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Shoot : MonoBehaviour
{
    public Transform firePoint1;
    public Transform firePoint2;
    public GameObject bossProjectile;
    public float fireRate = 0.5f;
    private float nextFire = 0f;
    private int fp = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            fp = Shoot(fp);
        }
    }

    int Shoot(int firepoint)
    {
        if (firepoint == 1)
        {
            GameObject bullet = Instantiate(bossProjectile, firePoint1.position, firePoint1.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint1.up * 15, ForceMode2D.Impulse);
            Destroy(bullet, 2f);
            return 2;
        }
        if (firepoint == 2)
        {
            GameObject bullet = Instantiate(bossProjectile, firePoint2.position, firePoint2.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint2.up * 15, ForceMode2D.Impulse);
            Destroy(bullet, 2f);
            return 1;
        }
        return firepoint;
    }
}
