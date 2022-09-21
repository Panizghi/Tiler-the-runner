using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class movment : MonoBehaviour
{
    Vector2 moveInput;

    Rigidbody2D myRigidbody;


    // increamenting the speed 
    [SerializeField] float runSpeed = 10f;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        Run();
    }

   void OnMove(InputValue value){
        // grab the input value and print it 
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }

    void Run(){
        Vector2 PlayerVelocity = new Vector2 ( moveInput.x * runSpeed ,myRigidbody.velocity.y);
        //keep the y speed as it was so the player wont fall into the ground slowly 
        myRigidbody.velocity = PlayerVelocity;
    }
}
