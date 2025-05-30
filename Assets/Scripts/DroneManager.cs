using UnityEngine;
using System.Collections.Generic;
using UnityEngine.XR;
using NUnit.Framework.Internal.Execution;
using System;

public class DroneController : MonoBehaviour
{
    [SerializeField] private Transform target;              // The target, e.g., helicopter
    [SerializeField] private GameObject dronePrefab;        // Drone template/prefab
    [SerializeField] private int droneCount = 5;            // Number of drones to spawn
    [SerializeField] private float moveSpeed = 5f;   
    
    [SerializeField] private float startingDist = 100f;            // Start distance

[SerializeField] private float offset = 10f;     

    private List<GameObject> drones = new List<GameObject>();

    void Start()
    {
        SpawnDrones();
    }

    void Update()
    {
        MoveDronesTowardsTarget();
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
                if (distance < 0.5f)  // Adjust threshold for contact
                {
                    Debug.Log("Game Over");
                    // Optionally: disable the drone to stop further movement
                    //drone.SetActive(false);
                }
            }
        }
    }
}

