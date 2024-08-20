using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 movementInput;
    public float movementSpeed = 1.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movementInput.x * movementSpeed * Time.deltaTime,0,movementInput.y * movementSpeed * Time.deltaTime);
        Debug.Log("Value of x ="+movementInput.x);
        Debug.Log("Value of y =" + movementInput.y);
    }
    public void IAmovement(InputAction.CallbackContext context)
    //InputAction.CallbackContext is the type of variabel.
    // context is a special kind of varible of function which contain all the input action you have createt.

    {
        movementInput = context.ReadValue<Vector2>();
    }
}
