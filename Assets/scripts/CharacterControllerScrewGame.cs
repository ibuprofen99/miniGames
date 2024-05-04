using UnityEngine;

public class CharacterControllerScrewGame : MonoBehaviour
{
    private Animator animator;
    public ScrewRotation screwRotation; // Reference to the ScrewRotation script
    public float maxRotationSpeed = 150f; // Maximum rotation speed of the screw in degrees per second
    public float minRotationSpeedToMove = 10f; // Minimum screw rotation speed required for character to start moving

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Get the rotation speed from the ScrewRotation script
        float rotationSpeed = screwRotation.currentRotationSpeed;

        // Determine movement speed based on the rotation speed of the screw
        float speed = Mathf.Max(0f, rotationSpeed - minRotationSpeedToMove);

        Debug.Log(speed);

        // Set animation speed based on rotation speed
        animator.SetFloat("Speed", speed / maxRotationSpeed); // Normalize speed to the range [0, 1]
        animator.speed = Mathf.Max(1f, speed / 50f); // Change animation speed based on 1/3 maxRotationSpeed value, minimum animation speed must be 1 or else it'll look funky
    }
}
