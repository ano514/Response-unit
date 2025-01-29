using UnityEngine;

public class GunAimManager : MonoBehaviour
{
    public Transform torso;  // Assign the torso/spine bone
    public Camera mainCamera;
    public float maxRotationAngle = 90f; // Limit left/right rotation
    public float rotationSpeed = 5f; // Adjust smoothing speed

    void Update()
    {
        AimAtMouse();
    }

    void AimAtMouse()
    {
        // Get mouse position in world space
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            Vector3 direction = hit.point - torso.position;
            direction.y = 0; // Keep rotation horizontal

            // Convert direction to rotation
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            // Convert target rotation to local space relative to the player
            float angle = Quaternion.Angle(transform.rotation, targetRotation);
            if (angle > maxRotationAngle)
            {
                targetRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, maxRotationAngle);
            }

            // Smoothly rotate torso and gun
            torso.rotation = Quaternion.Slerp(torso.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }
}

