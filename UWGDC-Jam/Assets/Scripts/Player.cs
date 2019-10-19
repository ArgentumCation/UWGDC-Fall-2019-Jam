using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float health = 100;

    void Update()
    {
        if (health < 0)
        {
            health = 0;
            Destroy(gameObject);
            return;
        }

        Vector3 vel = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        vel *= speed;
        transform.position += vel * Time.deltaTime;

        Vector2 aim = new Vector2(Input.GetAxis("Aim X"), Input.GetAxis("Aim Y"));
        if (aim.magnitude > 0.01)
            transform.rotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.right, aim));
    }

    public void Hurt(float amount)
    {
        Debug.Log("ouch");
        health -= amount;
    }
}
