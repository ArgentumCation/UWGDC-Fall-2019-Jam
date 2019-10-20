using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource main, glitch;

    void Start()
    {
        Main();
    }

    public void Glitch()
    {
        main.volume = 0;
        glitch.volume = 1;
    }

    public void Main()
    {
        main.volume = 1;
        glitch.volume = 0;
    }
}
