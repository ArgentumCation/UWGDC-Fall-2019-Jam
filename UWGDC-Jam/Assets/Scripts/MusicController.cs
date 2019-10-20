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

    public void FastSpeed()
    {
        main.pitch = 1.5f;
        glitch.pitch = 1.5f;
    }

    public void NormalSpeed()
    {
        main.pitch = 1;
        glitch.pitch = 1;
    }
}
