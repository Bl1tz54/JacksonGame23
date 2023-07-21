using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public float moveSpeed;
    // variable for move speed
    public Rigidbody2D rb;
    // link to rigid body
    private Vector2 moveDirection; 

    void Update()
    {
        // Update is called once per frame (driven by frame rate)
        //better for imputs
        ProcessInputs();
    }

    private void FixedUpdate()
    {
        // gets called a set amount of times per update, better for physics calculations  
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;  // todo come back
    }

    void Move (){
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
