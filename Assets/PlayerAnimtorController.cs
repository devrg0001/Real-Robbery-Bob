using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Get player input on vertical axis (W/S or Up/Down arrows)
        float moveInput = Input.GetAxis("Vertical");
        float speed = Mathf.Abs(moveInput);

        // Set Speed parameter in the Animator
        animator.SetFloat("Speed", speed);
    }
}

