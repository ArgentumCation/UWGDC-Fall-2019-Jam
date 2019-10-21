using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyCharacter : EnemyClass
{
    private Player target;
    private Rigidbody2D body;
    public float dropProb = 0.1f;
    public List<GameObject> droppedItems = new List<GameObject>();

    private AIPath aiPath;

    // Start is called before the first frame update
    void Start()
    {
        target = Component.FindObjectOfType<Player>();
        body = GetComponent<Rigidbody2D>();
        aiPath = GetComponent<AIPath>();
        GetComponent<AIDestinationSetter>().target = target.transform;
    }

    private Vector3 VectorToTarget()
    {
        if (target == null)
            return Vector3.zero;
        Vector3 toTarget = (target.transform.position + RandomInCircle()) - transform.position;
        return toTarget.normalized;
    }

    private Vector3 RandomInCircle()
    {
        Vector3 v = Random.insideUnitSphere;
        v.z = 0;
        return v;
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
        if (aiPath != null)
            aiPath.enabled = false;
        body.isKinematic = true;
        body.velocity = VectorToTarget() * -12;
        yield return new WaitForSeconds(0.1f);
        body.isKinematic = false;
        if (aiPath != null)
            aiPath.enabled = true;
    }

    public override void Hurt(float amount)
    {
        base.Hurt(amount);
        StartCoroutine(JumpBack());
    }

    public override void OnKilled()
    {
        base.OnKilled();
        if (Random.value < dropProb)
        {
            int dropI = Random.Range(0, droppedItems.Count);
            var item = Instantiate(droppedItems[dropI]);
            item.transform.position = transform.position;
        }
    }
}
