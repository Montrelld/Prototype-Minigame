using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{ 
    public float jumpForce;
    public float gravityModifier; 
    private Rigidbody playerRb;
    public float speed = 10;
    public float turnSpeed = 45.0f;
    public float horizontalInput;
    public float forwardInput;
    public bool isOnGround = true;
    private Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
   

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        if (forwardInput > 0)
        {
            playerAnim.SetBool("Static_b", true);
            playerAnim.SetFloat("Speed_f", 0.30f);
        }
        
        else
        {
            playerAnim.SetFloat("Speed_f", 0);
        }


        //Move the vehicle forward bassed on vertical 
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        // Rotates the car bassed on horizontal input
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
      
    }

     private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isOnGround = true; 
            }

            
        }

}
