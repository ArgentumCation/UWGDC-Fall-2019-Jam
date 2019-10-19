using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject item;

    void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            var instance = Instantiate(item);
            player.GiveItem(instance);
            GameObject.Find("Pickup").GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }
    }
}
