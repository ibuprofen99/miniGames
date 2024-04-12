using UnityEngine;

public class ScrewRotation : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public float maxRotationSpeed = 150f;
    public float acceleration = 2f;
    public float countdownDuration = 5f;
    public float switchDirectionIntervalMin = 15f;
    public float switchDirectionIntervalMax = 20f;

    public Transform characterTransform; // Reference to the character's transform

    public float currentRotationSpeed;
    private bool countdownStarted = false;
    private bool rotatingClockwise = true;
    private float nextDirectionSwitchTime;

    void Start()
    {
        // Start countdown
        Invoke("StartRotation", countdownDuration);
        currentRotationSpeed = rotationSpeed;
    }

    void Update()
    {
        if (countdownStarted)
        {
            if (Time.time >= nextDirectionSwitchTime)
            {
                RotateInOppositeDirection();
                nextDirectionSwitchTime = Time.time + Random.Range(switchDirectionIntervalMin, switchDirectionIntervalMax);

                // Rotate the character by 180 degrees
                if (characterTransform != null)
                {
                    characterTransform.Rotate(Vector3.up, 180f);
                }
            }

            // Gradually increase rotation speed
            currentRotationSpeed += acceleration * Time.deltaTime;
            currentRotationSpeed = Mathf.Min(currentRotationSpeed, maxRotationSpeed);

            // Rotate the screw
            if (rotatingClockwise)
                transform.Rotate(Vector3.up, currentRotationSpeed * Time.deltaTime);
            else
                transform.Rotate(Vector3.up, -currentRotationSpeed * Time.deltaTime);
        }
    }

    void StartRotation()
    {
        countdownStarted = true;
        // Set initial direction switch time after the initial countdown
        nextDirectionSwitchTime = Time.time + Random.Range(switchDirectionIntervalMin, switchDirectionIntervalMax);
    }

    void RotateInOppositeDirection()
    {
        rotatingClockwise = !rotatingClockwise;
    }
}
