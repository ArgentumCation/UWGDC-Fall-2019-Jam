using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int ammo;
    public bool isGlitch;
    private AudioSource sound;

    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        if (isGlitch)
            Component.FindObjectOfType<MusicController>().Glitch();
    }

    void OnDisable()
    {
        if (isGlitch)
            Component.FindObjectOfType<MusicController>().Main();
    }

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
        sound.Play();
        ammo--;
        if (ammo <= 0)
            Destroy(gameObject);
    }
}
