using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{


    [SerializeField] private GameObject camera;
    [SerializeField] public float translateSpeed = 2.0f;
    [SerializeField] public float offsetSpeed = 10f;
    [SerializeField] public float rotateSpeed = 10f;

    [SerializeField] private GameObject[] explorers;
    [SerializeField] private Vector3[] cameraOffsets;

    [SerializeField] private GameObject chopper;

    private static int current = 0;


    MapGenerator mapGen;
    public float xOffset = 0;
    public float yOffset = 0;

    public float heightOffset = 40f;

    public float noiseScale = 40;

    void Start()
    {
        explorers[current].SetActive(true);
        explorers[current+1].SetActive(false);
        
        mapGen = FindAnyObjectByType<MapGenerator>();
        mapGen.GenerateMap(0,0);
    }
    // Update is called once per frame
    void Update()
    {
        mapGen.GenerateMap(xOffset, yOffset, 1+heightOffset);
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            explorers[current].SetActive(false);
            current++;
            if (current >= explorers.Length)
            {
                current = 0;
            }
            explorers[current].SetActive(true);

            camera.transform.SetParent(explorers[current].transform);
            camera.transform.localPosition = cameraOffsets[current];

        }


        if (Input.GetKey(KeyCode.DownArrow))
        {
            camera.transform.Rotate(rotateSpeed * Time.deltaTime, 0, 0, Space.Self);

        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            camera.transform.Rotate(-rotateSpeed * Time.deltaTime, 0, 0, Space.Self);

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            camera.transform.parent.Rotate(0, rotateSpeed * 2 * Time.deltaTime, 0, Space.Self);

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            camera.transform.parent.Rotate(0, -rotateSpeed * 2 * Time.deltaTime, 0, Space.Self);

        }
        if (Input.GetKey(KeyCode.Q))
        {
            heightOffset += translateSpeed * Time.deltaTime;

            //explorers[current].transform.position += Vector3.up * translateSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.E))
        {
            heightOffset -= translateSpeed * Time.deltaTime;
 
            //explorers[current].transform.position += Vector3.down * translateSpeed * Time.deltaTime;
        }


        //camera.transform.position = explorers[current].transform.position;

    }
}
