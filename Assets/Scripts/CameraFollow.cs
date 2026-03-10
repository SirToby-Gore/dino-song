using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 Offset;
    [SerializeField] private float Damping;

    public Transform target;

    private Vector3 Velocity = Vector3.zero;

    private void FixedUpdate()
    {
        Vector3 TargetPosition = target.position + Offset;
        TargetPosition.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, TargetPosition, ref Velocity, Damping);
    }
}
