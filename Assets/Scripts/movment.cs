using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class movment : MonoBehaviour
{
    Vector2 moveInput;

    Rigidbody2D myRigidbody;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        
    }

   void OnMove(InputValue value){
        // grab the input value and print it 
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }

    void Run(){
        Vector2 PlayerVelocity = new Vector2 ( moveInput.x,0f);
        myRigidbody.velocity = PlayerVelocity;
    }
}
