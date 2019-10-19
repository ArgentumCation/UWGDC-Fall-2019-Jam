using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Player target;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        target = Component.FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 toTarget = target.transform.position - transform.position;
        toTarget = toTarget.normalized;
        toTarget *= speed * Time.deltaTime;
        transform.position += toTarget;
    }
}
