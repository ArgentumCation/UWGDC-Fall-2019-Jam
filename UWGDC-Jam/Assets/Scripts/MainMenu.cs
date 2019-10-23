using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject image;

    void Update()
    {
        if (Input.GetButtonDown("Restart"))
            PlayGame();
    }
    public void PlayGame()
    {
        image.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
