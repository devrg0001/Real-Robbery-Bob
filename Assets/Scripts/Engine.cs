using System;
using UnityEngine;

public class Engine : MonoBehaviour
{
    [SerializeField] private float engineSpeed = 10f;
    [SerializeField] private Boolean[] Axis = new Boolean[3];

    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void Update()
    {
        if (Axis[0] == true)
        {
            transform.Rotate(0, engineSpeed, 0, Space.Self);
        }
        if (Axis[1] == true)
        {
            transform.Rotate(engineSpeed, 0, 0, Space.Self);
        }
        if (Axis[2] == true)
        {
            transform.Rotate(0, 0, engineSpeed, Space.Self);
        }
    }
}
