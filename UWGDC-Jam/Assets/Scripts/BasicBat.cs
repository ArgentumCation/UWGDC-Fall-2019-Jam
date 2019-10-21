using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBat : MonoBehaviour
{
    private BoxCollider2D batHitBox;
    private SpriteRenderer batBody;
    private bool isSwinging = false;
    private AudioSource sound;

    private Vector3 fistMovement = new Vector3(0.0f, 0.15f, 0);
    

    // Start is called before the first frame update
    void Start()
    {
        this.transform.localPosition = fistMovement;

        batHitBox = GetComponent<BoxCollider2D>();
        batBody = GetComponent<SpriteRenderer>();
        batHitBox.enabled = false;
        batBody.enabled = false;

        sound = GetComponent<AudioSource>();
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
            this.transform.localPosition += new Vector3(2f, 0, 0) * Time.deltaTime;
        }
    }

    

    public IEnumerator swing()
    {
        sound.Play();
        batHitBox.enabled = true;
        batBody.enabled = true;
        isSwinging = true;
        this.transform.localPosition = fistMovement;
        yield return new WaitForSeconds(0.1f);
        isSwinging = false;
        batHitBox.enabled = false;
        batBody.enabled = false;
    }


    void OnCollisionStay2D(Collision2D collision)
    {
        var Enemy = collision.gameObject.GetComponent<EnemyClass>();
      //  Debug.Log("Objects Colliding");
        if (Enemy != null && isSwinging == true)
        {
            Enemy.Hurt(batDamage);
            isSwinging = false;
        }
    }
}
