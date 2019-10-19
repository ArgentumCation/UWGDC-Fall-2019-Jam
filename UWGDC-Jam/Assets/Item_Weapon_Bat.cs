﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Weapon_Bat : MonoBehaviour
{
    bool isSwinging = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public int batDamage = 5;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(swing());
        }
    }

    public IEnumerator swing()
    {
        Debug.Log("Swinging");
        isSwinging = true;
        yield return new WaitForSeconds(0.5f);
        isSwinging = false;
        Debug.Log("Swung");
    }


    void OnCollisionStay2D(Collision2D collision)
    {
        var Enemy = collision.gameObject.GetComponent<Enemy>();
        Debug.Log("Objects Colliding");
        if (Enemy != null && isSwinging == true)
        {
            //Debug.Log("Objects Colliding");
            Enemy.enemyHealth -= batDamage;
        }
    }
}
