using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeFragment : MonoBehaviour
{
    private Vector3 velocity;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        var animator = GetComponentInChildren<Animator>();
        animator.Play("level256 animation", 0, Random.value);
        velocity = Random.insideUnitCircle * 6f;
        yield return new WaitForSeconds(0.33f);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += velocity * Time.deltaTime;
    }
}
