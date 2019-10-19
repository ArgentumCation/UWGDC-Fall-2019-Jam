using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float health = 100;
    private AudioSource hurtSound;
    private Rigidbody2D body;
    private bool mouseAim = true;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        hurtSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (health <= 0)
        {
            health = 0;
            Destroy(gameObject);
            GameObject.Find("Die").GetComponent<AudioSource>().Play();
            GameObject.Find("EventText").GetComponent<EventMessage>().ShowMesssage("YOU DIED");
        }
    }

    void FixedUpdate()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        if (move.sqrMagnitude > 1)
            move = move.normalized;
        body.velocity = move * speed;

        if (mouseAim && (Input.GetAxis("Aim X") != 0 || Input.GetAxis("Aim Y") != 0))
            mouseAim = false;

        Vector2 aim;
        if (mouseAim)
            aim = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        else
            aim = new Vector2(Input.GetAxis("Aim X"), Input.GetAxis("Aim Y"));
        if (aim.magnitude > 0.01)
            transform.rotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.right, aim));
    }

    public void Hurt(float amount)
    {
        health -= amount;
        if (health > 0)
            hurtSound.Play();
    }
}
