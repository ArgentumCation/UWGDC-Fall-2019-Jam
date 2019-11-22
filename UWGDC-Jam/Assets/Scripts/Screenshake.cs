using UnityEngine;

public class Screenshake : MonoBehaviour
{
    // Transform of the GameObject you want to shake
    private Transform transform;

    // Desired duration of the shake effect
    private float shakeDuration;

    // A measure of magnitude for the shake. Tweak based on your preference
    private readonly float shakeMagnitude = 0.05f;

    // A measure of how quickly the shake effect should evaporate
    private readonly float dampingSpeed = 5.0f;

    // The initial position of the GameObject
    private Vector3 initialPosition;

    private void Awake()
    {
        if (transform == null) transform = GetComponent(typeof(Transform)) as Transform;
    }

    private void OnEnable()
    {
        initialPosition = transform.localPosition;
    }

    private void Update()
    {
        if (shakeDuration > 0)
        {
            transform.localPosition =
                initialPosition + Random.insideUnitSphere * shakeMagnitude;

            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeDuration = 0f;
            transform.localPosition = initialPosition;
        }
    }
    
    public void TriggerShake() {
        shakeDuration = 2.0f;
    }
}