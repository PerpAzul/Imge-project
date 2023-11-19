using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public CharacterController controller;
    private Vector2 movement;

    //speed of player
    public float speed;
    Vector3 velocity;
    
    //jump height
    public float jumpHeight;
    
    //gravity
    public float gravity;
    
    //variabels to see if player is on the ground
    bool isGrounded;

    //Life
    public float lives;
    
    //Dash
    [SerializeField] private Transform orientation;
    [SerializeField] private float dashForce;
    [SerializeField] private float dashUpwardForce;
    [SerializeField] private float cooldownTime = 2;
    private float nextDashTime = 0;
    private bool isCooldown;
    private float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //check if player is on the ground or not
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        //moving the player
        Vector3 move = movement.x * transform.right + movement.y * transform.forward;
        controller.Move( move * speed * Time.deltaTime);
        

        //applying gravity to the player
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    
    public void doMove(InputAction.CallbackContext obj)
    {
        movement = obj.ReadValue<Vector2>();
    }
    
    public void doJump(InputAction.CallbackContext obj)
    {
        if (isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
    
    public void doDash(InputAction.CallbackContext obj)
    {
        if (Time.time > nextDashTime)
        {
            timer = cooldownTime;
            isCooldown = true;
            Vector3 move = orientation.forward * dashForce + orientation.up * dashUpwardForce;
            controller.Move(move);
            nextDashTime = Time.time + cooldownTime;
        }
    }
}
