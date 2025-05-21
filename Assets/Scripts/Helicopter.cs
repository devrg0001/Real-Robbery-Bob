using System;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private GameManager gameManager;
    private float translateSpeed;
    private float offsetSpeed;
    private float rotateSpeed;

    [SerializeField] private GameObject chopper;
    [SerializeField] private GameObject chopperParent;

    [SerializeField] private float visable;

    float xAngle = 0;
    float yAngle = 0;
    void Start()
    {
        translateSpeed = gameManager.translateSpeed;
        offsetSpeed = gameManager.offsetSpeed;
        rotateSpeed = gameManager.rotateSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            xAngle = offsetSpeed * Time.deltaTime;


        }
        if (Input.GetKey(KeyCode.S))
        {
            xAngle = -offsetSpeed * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.A))
        {
            yAngle = -offsetSpeed * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.D))
        {
            yAngle = offsetSpeed * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.position += Vector3.up * translateSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.position += Vector3.down * translateSpeed * Time.deltaTime;
        }
        move();
        xAngle = 0;
        yAngle = 0;

    }

    private void move()
    {
        gameManager.xOffset += (float)Math.Sin(chopper.transform.localRotation.eulerAngles.x * Math.PI / 180) * (float)Math.Sin(chopperParent.transform.rotation.eulerAngles.y * Math.PI / 180) * offsetSpeed * Time.deltaTime;
        gameManager.yOffset += (float)Math.Sin(chopper.transform.localRotation.eulerAngles.x * Math.PI / 180) * (float)Math.Cos(chopperParent.transform.rotation.eulerAngles.y * Math.PI / 180) * (-offsetSpeed) * Time.deltaTime;
        chopper.transform.Rotate(xAngle, 0, 0, Space.Self);
        chopperParent.transform.Rotate(0, yAngle, 0, Space.World);
        
        //Debug.Log("y: " +  (float)Math.Sin(chopperParent.transform.rotation.eulerAngles.y));

        // * Math.PI / 180

    }
}
