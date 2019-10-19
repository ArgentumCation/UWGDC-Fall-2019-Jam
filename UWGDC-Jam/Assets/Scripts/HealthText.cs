using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour
{
    private Text healthText;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        healthText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
            healthText.text = "you died :(";
        else
            healthText.text = "Health: " + Mathf.RoundToInt(player.health);
    }
}
