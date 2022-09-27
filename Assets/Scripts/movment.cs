using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class movment : MonoBehaviour
{
    Vector2 moveInput;

    Rigidbody2D myRigidbody;

    Animator myAnimator;

    CapsuleCollider2D myCapsuleCollider;

    float IntialGravity;
    // increamenting the speed 
    [SerializeField] float runSpeed = 10f;

    [SerializeField] float JumpSpeed = 5f;
    [SerializeField] float ClimbSpeed = 5f;

    
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCapsuleCollider = GetComponent<CapsuleCollider2D>();
        IntialGravity = myRigidbody.gravityScale;
    }

   
    void Update()
    {
        Run();
        FlipSprite();
        ClimbeLadder();
    }

   void OnMove(InputValue value){
        // grab the input value and print it 
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }

    void OnJump(InputValue value){
        //jumping in the air is prevented 
        if(!myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))){
            return;
        }

        //there is not continouse movment just one press would eb enough for functionality 
        if(value.isPressed){
            myRigidbody.velocity += new Vector2(0f,JumpSpeed);
        }

        


    }

    void Run(){
        Vector2 PlayerVelocity = new Vector2 ( moveInput.x * runSpeed ,myRigidbody.velocity.y);
        //keep the y speed as it was so the player wont fall into the ground slowly 
        myRigidbody.velocity = PlayerVelocity;

        //changing state from idling to running 
    
        bool PlayerHasSpeed = Mathf.Abs(myRigidbody.velocity.x) >Mathf.Epsilon;
        
        //flipping the player to left and right based on keyboard input
        myAnimator.SetBool("isRunning",PlayerHasSpeed);
        
    }


    void FlipSprite(){
        //no flipping in case of speed being zero 
        bool PlayerHasSpeed = Mathf.Abs(myRigidbody.velocity.x) >Mathf.Epsilon;
        if(PlayerHasSpeed){
        //flipping the player to left and right based on keyboard input
        transform.localScale = new Vector2 (Mathf.Sign(myRigidbody.velocity.x),1f);
        
        }
    }

    void ClimbeLadder(){

         if(!myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Climbing"))){


            myRigidbody.gravityScale = IntialGravity;
            myAnimator.SetBool("isClimbing",false);
            return;
        }
         Vector2 ClimbVelocity = new Vector2 (myRigidbody.velocity.x,moveInput.y * ClimbSpeed );
        //x stays the same and y have the climb speed 
        myRigidbody.velocity = ClimbVelocity;
        //when player is on the ladder gravity zero perevnt sliding 
        myRigidbody.gravityScale = 0 ;

         bool PlayerIsClimbing = Mathf.Abs(myRigidbody.velocity.y) >Mathf.Epsilon;
        
        //flipping the player to left and right based on keyboard input
        myAnimator.SetBool("isClimbing",PlayerIsClimbing);
    }

}
