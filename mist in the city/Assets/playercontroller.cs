using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public CharacterController controller;
    public float playerSpeed = 50f;
    public float gravity = -9.82f;
    Vector3 velocity;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isgrounded;
    public float h = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isgrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isgrounded && velocity.y<0)
        {
            velocity.y = -2f;
        }
        float moveX = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime;

        Vector3 move = transform.right * moveX + transform.forward * moveY;

        if(Input.GetButton("Jump") && isgrounded)
        {
            velocity.y = Mathf.Sqrt(h * -2 * gravity);
        }

        controller.Move(move);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
