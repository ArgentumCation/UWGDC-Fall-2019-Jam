﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Player target;
    private Rigidbody2D body;
    public float speed;
    private bool moveToPlayer = true;

    // Start is called before the first frame update
    void Start()
    {
        target = Component.FindObjectOfType<Player>();
        body = GetComponent<Rigidbody2D>();
    }

    private Vector3 VectorToTarget()
    {
        Vector3 toTarget = (target.transform.position + RandomInCircle() * 2) - transform.position;
        return toTarget.normalized;
    }

    private Vector3 RandomInCircle()
    {
        Vector3 v = Random.insideUnitSphere;
        v.z = 0;
        return v;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moveToPlayer)
        {
            body.velocity = VectorToTarget() * speed;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.Hurt(1);
            StartCoroutine(JumpBack());
        }
    }

    IEnumerator JumpBack()
    {
        moveToPlayer = false;
        body.isKinematic = true;
        body.velocity = VectorToTarget() * -12;
        yield return new WaitForSeconds(0.1f);
        body.isKinematic = false;
        moveToPlayer = true;
    }
}