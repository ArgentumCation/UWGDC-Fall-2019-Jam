using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : Bullet
{
    public GameObject fragmentPrefab;

    protected override void BulletHit(EnemyClass eee)
    {
        foreach (Collider2D hit in Physics2D.OverlapCircleAll(transform.position, 2))
        {
            var enemy = hit.gameObject.GetComponent<EnemyClass>();
            if (enemy != null)
                enemy.Hurt(9999);
        }
        for (int i = 0; i < 12; i++)
        {
            var frag = Instantiate(fragmentPrefab);
            frag.transform.position = transform.position;
        }
        GameObject.Find("GrenadeSound").GetComponent<AudioSource>().Play();
    }
}
