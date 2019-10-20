using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBat : MonoBehaviour
{

    private BoxCollider2D batHitBox;
    private SpriteRenderer batBody;
    private bool isSwinging = false;

    private Vector3 fistMovement = new Vector3(-0.18f, 0.23f, 0);
    

    // Start is called before the first frame update
    void Start()
    {
        this.transform.localPosition = fistMovement;

        batHitBox = GetComponent<BoxCollider2D>();
        batBody = GetComponent<SpriteRenderer>();
        batHitBox.enabled = false;
        batBody.enabled = false;
    }




    public float batDamage = 5;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            StartCoroutine(swing());

        }
        if (isSwinging)
        {
            this.transform.localPosition += new Vector3(0.15f, 0, 0);
        }
    }

    

    public IEnumerator swing()
    {
        batHitBox.enabled = true;
        batBody.enabled = true;
        isSwinging = true;
        yield return new WaitForSeconds(0.1f);
        isSwinging = false;
        batHitBox.enabled = false;
        batBody.enabled = false;
        this.transform.localPosition = new Vector3(-0.18f, 0.23f, 0);
    }


    void OnCollisionStay2D(Collision2D collision)
    {
        var Enemy = collision.gameObject.GetComponent<EnemyClass>();
      //  Debug.Log("Objects Colliding");
        if (Enemy != null && isSwinging == true)
        {
            Enemy.Hurt(batDamage);
            Debug.Log("Hit");
            isSwinging = false;
        }
    }
}
