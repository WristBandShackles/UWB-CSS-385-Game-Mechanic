using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed; // Set to 5
    public float jumpPower; // Set to 8
    private bool fallThroughPlatform = false;
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> (); // For jumping
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        PlatformFall();
    }

    private void Movement()
    {
        Vector3 movement = Vector3.zero;

        // Get Input
        movement.x = Input.GetAxis("Horizontal");

        // Move the character
        Vector3 newPosition = transform.position + (movement * moveSpeed * Time.deltaTime);
        transform.position = newPosition;


        // if space hit, Jump
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            rb2d.velocity = Vector2.up * jumpPower;
        }
    }

    private void PlatformFall()
    {
        if (Input.GetKey(KeyCode.S))
        {
            fallThroughPlatform = true;
        } else
        {
            fallThroughPlatform = false;
        }
    }

    public bool getPlatformFall()
    {
        return fallThroughPlatform;
    }
}
