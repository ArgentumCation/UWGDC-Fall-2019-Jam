using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float damage = 5;
    private Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.velocity = transform.right * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.gameObject.GetComponent<EnemyClass>();
        if (enemy != null)
            BulletHit(enemy);
        Destroy(gameObject);
    }

    protected virtual void BulletHit(EnemyClass enemy)
    {
        enemy.Hurt(damage);
    }
}
