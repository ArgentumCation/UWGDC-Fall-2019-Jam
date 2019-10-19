using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DelaySequence : MonoBehaviour
{
    [System.Serializable]
    public class Step
    {
        public float delay;
        public UnityEvent action;
    }

    public List<Step> sequence = new List<Step>();

    private float lastTime;
    private int stepI;

    void OnEnable()
    {
        stepI = 0;
        lastTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (stepI < sequence.Count && Time.time > lastTime + sequence[stepI].delay)
        {
            sequence[stepI].action.Invoke();
            lastTime += sequence[stepI].delay;
            stepI++;
        }
    }

    public void TestLog(string message)
    {
        Debug.Log(message);
    }
}
