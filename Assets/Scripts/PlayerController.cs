using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpHeight = 2f;
    public float gravity = -9.81f;

    private CharacterController controller;
    private Animator animator;
    private Vector3 velocity;
    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            animator.SetBool("isJumping", false);
        }

        float moveZ = Input.GetAxis("Vertical"); // Up/Down arrows or W/S
        float moveX = Input.GetAxis("Horizontal"); // Left/Right arrows or A/D

        Vector3 move = transform.forward * moveZ + transform.right * moveX;
        controller.Move(move * speed * Time.deltaTime);

        // Animation blending
        float currentSpeed = new Vector2(moveX, moveZ).magnitude;
        animator.SetFloat("Speed", currentSpeed);

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            animator.SetBool("isJumping", true);
        }

        // Gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}

