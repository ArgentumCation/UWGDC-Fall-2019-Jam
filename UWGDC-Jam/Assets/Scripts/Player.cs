using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float health = 100;

    void Update()
    {
        Vector3 vel = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        vel *= speed;
        transform.position += vel * Time.deltaTime;
        if (vel.sqrMagnitude > 0.01)
            transform.rotation = Quaternion.Euler(0, 0, Vector3.SignedAngle(Vector3.right, vel, Vector3.forward));
    }

    public void Hurt(float amount)
    {
        Debug.Log("ouch");
        health -= amount;
    }
}
