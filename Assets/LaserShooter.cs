using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LaserShooter : MonoBehaviour
{
    public float laserLength = 100f;
    public LineRenderer lineRenderer;
    public Transform laserOrigin;         // 🔴 Drag the empty object here
    public LayerMask droneLayer;

    [SerializeField] private Transform target;              // The target, e.g., helicopter
    [SerializeField] private GameObject dronePrefab;        // Drone template/prefab
    [SerializeField] private int droneCount = 5;            // Number of drones to spawn
    [SerializeField] private float moveSpeed = .5f;

    [SerializeField] private float startingDist = 400f;            // Start distance

    [SerializeField] private float offset = 2.82f;
    
    [SerializeField] private int score = 0;

    [SerializeField] private TextMeshProUGUI gameOverText; // Text to display game over message

    [SerializeField] private TextMeshProUGUI scoreText; // Text to display game over message

    private List<GameObject> drones = new List<GameObject>();

    void Start()
    {
        scoreText.text = "Score: " + score.ToString();
        SpawnDrones();
    }

    void Update()
    {

        MoveDronesTowardsTarget();

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
                score++;
                scoreText.text = "Score: " + score.ToString();

                Destroy(hit.collider.gameObject);

                float XDistance = UnityEngine.Random.Range(-startingDist, startingDist);
                Vector3 randomPosition = new Vector3(XDistance, 0, (float) Math.Sqrt(startingDist * startingDist - XDistance * XDistance));
                GameObject drone = Instantiate(dronePrefab, target.transform.position + randomPosition, Quaternion.identity);
                drones.Add(drone);
            }
        }

        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
    }


    private void SpawnDrones()
    {
        for (int i = 0; i < droneCount; i++)
        {
            

            float XDistance = UnityEngine.Random.Range(-startingDist, startingDist);
            Vector3 randomPosition = new Vector3(XDistance, 0, (float) Math.Sqrt(startingDist * startingDist - XDistance * XDistance));
            GameObject drone = Instantiate(dronePrefab, target.transform.position + randomPosition, Quaternion.identity);
            drones.Add(drone);
        }
    }

    private void MoveDronesTowardsTarget()
    {
        foreach (GameObject drone in drones)
        {
            if (drone != null && target != null)
            {
                drone.transform.position = Vector3.MoveTowards(drone.transform.position, target.transform.position, moveSpeed * Time.deltaTime * Vector3.Distance(drone.transform.position, target.position));

                drone.transform.position = new Vector3(drone.transform.position.x,target.transform.position.y-offset,drone.transform.position.z);

                float distance = Vector3.Distance(drone.transform.position, target.position);
                if (distance < 5f)  // Adjust threshold for contact
                {
                    Debug.Log("Game Over");
                    gameOverText.text = "Game Over"; // Display game over message
                    foreach (GameObject droned in drones)
                    {
                        droned.SetActive(false); // Disable all drones
                    }
                }
            }
        }
    }
}
