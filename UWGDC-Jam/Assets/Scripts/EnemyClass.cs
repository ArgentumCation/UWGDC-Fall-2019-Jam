using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass : MonoBehaviour
{
    public float enemyHealth = 20;

    public virtual void Hurt(float amount)
    {
        enemyHealth -= amount;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0)
        {
            GameObject.Find("Explosion").GetComponent<AudioSource>().Play();
            OnKilled();
            Destroy(gameObject);
        }
    }

    public virtual void OnKilled() { }
}
