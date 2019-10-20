using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : EnemyClass
{
    private Player target;
    private Rigidbody2D body;
    public float speed;
    public float dropProb = 0.1f;
    public List<GameObject> droppedItems = new List<GameObject>();
    private bool moveToPlayer = true;
    

    // Start is called before the first frame update
    void Start()
    {
        target = Component.FindObjectOfType<Player>();
        body = GetComponent<Rigidbody2D>();
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
