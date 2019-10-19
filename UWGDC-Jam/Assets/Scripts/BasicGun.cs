using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGun : MonoBehaviour
{
    public GameObject bulletPrefab;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        var bullet = Instantiate(bulletPrefab);
        var bulletBody = bullet.GetComponent<Rigidbody2D>();
        bulletBody.transform.position = transform.position;
        bulletBody.transform.rotation = transform.rotation;
    }
}
