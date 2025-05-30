using UnityEngine;

public class LaserShooter : MonoBehaviour
{
    public float laserLength = 100f;
    public LineRenderer lineRenderer;
    public Transform laserOrigin;         // 🔴 Drag the empty object here
    public LayerMask droneLayer;

    void Update()
    {
        Vector3 start = laserOrigin.position;
        Vector3 direction = laserOrigin.forward;

        Ray ray = new Ray(start, direction);
        RaycastHit hit;

        Vector3 end = start + direction * laserLength;

        if (Physics.Raycast(ray, out hit, laserLength, droneLayer))
        {
            end = hit.point;

            if (hit.collider.CompareTag("Drone"))
            {
                Destroy(hit.collider.gameObject);
            }
        }

        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
    }
}
