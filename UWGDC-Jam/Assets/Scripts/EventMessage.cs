using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventMessage : MonoBehaviour
{
    private Text text;

    void Start()
    {
        text = GetComponent<Text>();
        text.enabled = false;
    }

    public void ShowMesssage(string message)
    {
        StartCoroutine(MessageCoroutine(message));
    }

    private IEnumerator MessageCoroutine(string message)
    {
        text.enabled = true;
        text.text = message;
        yield return new WaitForSeconds(3.0f);
        text.enabled = false;
    }
}
