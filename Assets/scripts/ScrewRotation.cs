using UnityEngine;
using System.Collections.Generic;

public class ScrewRotation : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public float maxRotationSpeed = 60f;
    public float acceleration = 2f;
    public float countdownDuration = 5f;
    public float switchDirectionIntervalMin = 30f;
    public float switchDirectionIntervalMax = 35f;

    public Transform characterTransform; // Reference to the character's transform

    public float currentRotationSpeed;
    private bool countdownStarted = false;
    private bool rotatingClockwise = true;
    private float nextDirectionSwitchTime;

    // Reference to ObstacleSpawner script
    public ObstacleSpawner obstacleSpawner;

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

                // Turn off obstacles for 2 seconds and then turn them back on and randomize
                TurnOffObstaclesForDuration(2f);
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

    // Method to turn off obstacles for a specified duration and then turn them back on and randomize
    void TurnOffObstaclesForDuration(float duration)
    {
        // Turn off obstacles
        obstacleSpawner.DisableAllObstacles();

        // Turn on obstacles and randomize after specified duration
        Invoke("RandomizeObstacles", duration);
    }

    // Method to randomize obstacles
    void RandomizeObstacles()
    {
        obstacleSpawner.SpawnObstacles();
    }
}
