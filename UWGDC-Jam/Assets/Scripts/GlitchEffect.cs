using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlitchEffect : MonoBehaviour
{
    private SpriteRenderer render;
    private AudioSource sound;

    IEnumerator Start()
    {
        render = GetComponent<SpriteRenderer>();
        sound = GetComponent<AudioSource>();
        render.enabled = false;
        while (enabled)
        {
            yield return new WaitForSeconds(Random.Range(0.1f, 2.5f));
            render.enabled = true;
            sound.Play();
            yield return new WaitForSeconds(0.1f);
            render.enabled = false;
        }
        render.enabled = false;
    }

    void OnDisable()
    {
        render.enabled = false;
    }
}
