using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public ContactFilter2D movementFilter;

    Vector2 movementInput;
    Rigidbody2D rb;
    private Animator animator;

    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        movementFilter.SetLayerMask(~LayerMask.GetMask("Combat"));
    }
//collision detection
    private void FixedUpdate()  {
        // If movement input is not 0. try to move
        if(movementInput != Vector2.zero){
            bool success = TryMove(movementInput);

            if(!success) {
                success = TryMove(new Vector2(movementInput.x, 0));

                if(!success) {
                    success = TryMove(new Vector2(0, movementInput.y));
                }
            }
        }       
    }

    private bool TryMove(Vector2 direction) {
        // Check for potential collisions
        int count = rb.Cast(
            direction, //X and Y values between -1 and 1 that represent the direction from the body to look for collisions
            movementFilter, // The settings that determine where a collision can occur on such as layers to collie with
            castCollisions, // List of collisions to store the found collisions into after Cast is finished
            moveSpeed * Time.fixedDeltaTime); // The amount to cast equal to the movemet plus an offset

        if(count == 0){
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
            return true;
         } else {
            return false;
        }
    }


    void OnMove(InputValue movementValue)   {
        movementInput = movementValue.Get<Vector2>();
        animator.SetFloat("X",movementInput.x);
        animator.SetFloat("Y",movementInput.y);
        animator.SetFloat("Speed", movementInput.sqrMagnitude);
    }
}
//We're live!
