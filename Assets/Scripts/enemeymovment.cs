using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemeymovment : MonoBehaviour
{   

    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D myRigidbody;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   //similar to player movement only moving in x direction 
        myRigidbody.velocity = new Vector2 (moveSpeed, 0f) ;
    }

      void FlipFacing(){

        //flipping the player to left and right based on keyboard input
        //flip the current sign 
        transform.localScale = new Vector2 (-(Mathf.Sign(myRigidbody.velocity.x)),1f);
        
        }
    void OnTriggerExit2D(Collider2D other) {
        //change direction when you hit the wall
        moveSpeed = -moveSpeed;
        //call the method 
        FlipFacing();
    }
}
