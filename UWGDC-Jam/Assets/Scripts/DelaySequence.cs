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

    public int startThreshold = 0;
    private int thresholdCount = 0;

    public List<Step> sequence = new List<Step>();

    private float lastTime;
    private int stepI;

    void OnEnable()
    {
        stepI = 0;
        lastTime = -1;
    }

    public void ThresholdTrigger()
    {
        thresholdCount++;
    }

    // Update is called once per frame
    void Update()
    {
        if (thresholdCount >= startThreshold && lastTime < 0)
            lastTime = Time.time;

        if (lastTime < 0)
            return;

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
