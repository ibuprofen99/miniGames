using UnityEngine;

public class ScrewCamera : MonoBehaviour
{
    public float distance = 10f; // Distance from the target
    public float height = 3f; // Height of the camera
    public float lateralOffset = 1f; // Lateral offset from the target
    public Transform character; // Character's transform (formerly 'target')
    public float smoothSpeed = 5f; // Smoothness of camera movement
    public float rotationDamping = 3f; // Damping for camera rotation

    void LateUpdate()
    {
        if (!character)
            return;

        // Calculate lateral offset based on target's right direction
        Vector3 rightOffset = character.right * lateralOffset; // Offset to the right

        // Calculate target position
        Vector3 targetPosition = character.position - character.forward * distance + Vector3.up * height + rightOffset;

        // Smoothly move the camera towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);

        // Calculate target rotation
        Quaternion targetRotation = Quaternion.LookRotation(character.position - transform.position, Vector3.up);

        // Smoothly rotate the camera towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationDamping * Time.deltaTime);
    }
}
