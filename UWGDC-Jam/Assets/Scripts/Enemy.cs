using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Player target;
    private Rigidbody2D body;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        target = Component.FindObjectOfType<Player>();
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 toTarget = target.transform.position - transform.position;
        toTarget = toTarget.normalized;
        toTarget *= speed;
        body.velocity = toTarget;
    }
}
