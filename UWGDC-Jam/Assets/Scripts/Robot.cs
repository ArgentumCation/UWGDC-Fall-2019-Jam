using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : BasicGun
{
    private const float RANGE = 3.5f;
    private const float RATE = 0.5f;

    public override void Start()
    {
        base.Start();
        StartCoroutine(RobotCo());
    }

    private IEnumerator RobotCo()
    {
        while (true)
        {
            yield return new WaitForSeconds(RATE);
            Collider2D closest = null;
            float closestDist = RANGE;
            foreach (Collider2D coll in Physics2D.OverlapCircleAll(transform.position, RANGE))
            {
                if (coll.GetComponent<EnemyCharacter>() == null)
                    continue;
                float dist = (coll.transform.position - transform.position).magnitude;
                if (dist < closestDist)
                {
                    closestDist = dist;
                    closest = coll;
                }
            }
            if (closest != null)
            {
                Vector2 aim = closest.transform.position - transform.position;
                transform.rotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.right, aim));
                Shoot();
            }
        }
    }

    public override void Update() { }
}
