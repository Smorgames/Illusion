using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    public CharacterController2D characterController;
    public float horizontalMove;
    private bool moveDirection = true;

    bool isPlayerJumping = false;
    bool jump = false;

    public float runSpeed;

    public Animator playerAnimator;

    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius;

    public GameObject runEffector;

    void Update()
    {
        if (moveDirection == true)
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        else
            horizontalMove = -1 * Input.GetAxisRaw("Horizontal") * runSpeed;
        playerAnimator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        GroundCheck();
        if (Input.GetButtonDown("Jump"))
        {
            isPlayerJumping = true;
        }

        if (jump == true)
            playerAnimator.SetBool("IsJumping", true);
        else
            playerAnimator.SetBool("IsJumping", false);

        if (jump == false)
            runEffector.GetComponent<RunSound>().RunSoundEffect(horizontalMove, runEffector.GetComponent<AudioSource>());
    }

    private void FixedUpdate()
    {
        characterController.Move(horizontalMove * Time.fixedDeltaTime, false, isPlayerJumping);
        isPlayerJumping = false;
    }

    private void GroundCheck()
    {
        Collider2D[] ground = Physics2D.OverlapCircleAll(groundCheck.position, groundCheckRadius, groundLayer);
        if (ground.Length >= 1)
            jump = false;
        else
            jump = true;
    }

    //private void OnDrawGizmosSelected()
    //{
    //    if (groundCheck == null)
    //        return;
    //    Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    //}

    public void ReverseHorizontalMove(bool direction)
    {
        moveDirection = direction;
    }
}
