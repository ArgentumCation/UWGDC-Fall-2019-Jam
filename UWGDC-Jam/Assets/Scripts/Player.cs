using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    void Update()
    {
        Vector3 vel = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        vel *= speed * Time.deltaTime;
        transform.position += vel;
    }

    public void Hurt(float amount)
    {
        Debug.Log("ouch");
    }
}
