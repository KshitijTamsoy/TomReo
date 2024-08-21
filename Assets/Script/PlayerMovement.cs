using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 movementInput;
    public float gravity = 9.8f;
    public float jumpSpeed = 20f;
    public float verticalSpeed = 0f;
    public float movementSpeed = 1.0f;
    public float moveDirection = 0.0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (verticalSpeed == 0)
        {
            GroundCheck() == false;
        }
        else if (GroundCheck() == true)
        {
            verticalSpeed = 0;
        }
        else
        {
            verticalSpeed = (verticalSpeed - gravity) * Time.deltaTime;
        }

        transform.Translate(movementInput.x * movementSpeed * Time.deltaTime, verticalSpeed, movementInput.y * movementSpeed * Time.deltaTime);
        /*Debug.Log("Value of x ="+movementInput.x);
        Debug.Log("Value of y =" + movementInput.y);*/

        /* if (isGrounded)
         {
             if (Input.GetButton("Jump"))
             {
                 moveDirection.y = jumpSpeed;
             }
             else
             {
                 moveDirection.y = 0.0;
             }
         }
         else
         {
             // Apply gravity
             moveDirection.y -= gravity * Time.deltaTime;
         }

         transform.translate(moveDirection);*/
    }

    public bool GroundCheck()
    {
        return Physics.Raycast(transform.position, transform.up * -1, 1);
    }
    public void IAmovement(InputAction.CallbackContext context)
    //InputAction.CallbackContext is the type of variabel.
    // context is a special kind of varible of function which contain all the input action you have createt.

    {
        movementInput = context.ReadValue<Vector2>();
    }
    public void IAjump(InputAction.CallbackContext context)
    {
        if (context.started == true)
        {
            verticalSpeed = jumpSpeed;

            Debug.Log("Started");
        }
        if (context.performed == true)
        {
            Debug.Log("performed");
        }
        if (context.canceled == true)
        {
            Debug.Log("canceled");
            /*movementInput = context.ReadValue<Vector3>();*/
        }
    }
}
