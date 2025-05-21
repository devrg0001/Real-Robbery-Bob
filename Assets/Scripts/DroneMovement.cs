using UnityEditor;
using UnityEngine;


public class DroneMovement : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    private float translateSpeed;
    private float offsetSpeed;
    private float rotateSpeed;
    public GameObject character;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        translateSpeed = gameManager.translateSpeed;
        offsetSpeed = gameManager.offsetSpeed;
        rotateSpeed = gameManager.rotateSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            gameManager.xOffset += offsetSpeed * Time.deltaTime;
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameManager.xOffset -= offsetSpeed * Time.deltaTime;
        
        }
        if (Input.GetKey(KeyCode.W))
        {
            gameManager.yOffset += offsetSpeed * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.S))
        {
            gameManager.yOffset -= offsetSpeed * Time.deltaTime;
 
        }
        if (Input.GetKey(KeyCode.Q))
        {
           
            character.transform.position += Vector3.up * translateSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.E))
        {
         
            character.transform.position += Vector3.down * translateSpeed * Time.deltaTime;
        }
        

    }
}
