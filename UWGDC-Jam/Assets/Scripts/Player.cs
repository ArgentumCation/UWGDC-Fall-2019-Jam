using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float health = 100;
    private SpriteRenderer render;
    private AudioSource hurtSound;
    private Rigidbody2D body;
    private bool mouseAim = true;
    private GameObject weapon;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        hurtSound = GetComponent<AudioSource>();
        render = GetComponentInChildren<SpriteRenderer>();
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



    void OnCollisionEnter2D(Collision2D collision)
    {
        var speedBooster = collision.gameObject.GetComponent<SpeedBoost>();
        if (speedBooster != null)
        {
            StartCoroutine(SpeedBoostDuration());
        }
    }

    IEnumerator SpeedBoostDuration()
    {
        var music = Component.FindObjectOfType<MusicController>();
        music.FastSpeed();
        this.speed *= 1.5f;
        yield return new WaitForSeconds(10);
        music.NormalSpeed();
        this.speed *= 2/3f;
    }

    public void Hurt(float amount)
    {
        health -= amount;
        if (health > 0)
        {
            hurtSound.Play();
            StartCoroutine(HurtFlash());
        }
    }

    private IEnumerator HurtFlash()
    {
        render.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        render.color = Color.white;
    }

    public void GiveItem(GameObject item)
    {
        if (weapon != null)
            Destroy(weapon.gameObject);
        item.transform.parent = transform;
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.identity;
        weapon = item;
    }
}
