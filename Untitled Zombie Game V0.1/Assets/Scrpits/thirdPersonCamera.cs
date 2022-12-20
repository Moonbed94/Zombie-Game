using UnityEngine;

public class thirdPersonCamera : MonoBehaviour
{
    // The target to follow
    public Transform target;

    // The distance from the target
    public float distance = 5.0f;

    // The height above the target
    public float height = 2.0f;

    // The damping factor
    public float damping = 5.0f;

    // The minimum angle of the camera
    public float minAngle = -40.0f;

    // The maximum angle of the camera
    public float maxAngle = 80.0f;

    // The current angle of the camera
    private float currentAngle = 0.0f;

    // The current distance of the camera
    private float currentDistance = 0.0f;

    // The current height of the camera
    private float currentHeight = 0.0f;

    void LateUpdate()
    {
        // Calculate the new angle of the camera
        currentAngle = Mathf.LerpAngle(currentAngle, Input.GetAxis("Mouse X") * damping, Time.deltaTime);

        // Calculate the new distance of the camera
        currentDistance = Mathf.Lerp(currentDistance, Input.GetAxis("Mouse ScrollWheel") * damping, Time.deltaTime);

        // Calculate the new height of the camera
        currentHeight = Mathf.Lerp(currentHeight, Input.GetAxis("Vertical") * damping, Time.deltaTime);

        // Clamp the angle of the camera
        currentAngle = Mathf.Clamp(currentAngle, minAngle, maxAngle);

        // Set the position of the camera
        Vector3 localPosition = new Vector3(0.0f, currentHeight, -currentDistance);
        transform.position = target.TransformPoint(localPosition);

        // Set the rotation of the camera
        transform.rotation = target.rotation * Quaternion.Euler(currentAngle, 0.0f, 0.0f);
    }
}

