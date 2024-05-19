using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{

    private GameObject player;
    private Rigidbody2D playerRigidBody;
    private Collider2D playerCollider;
    private Collider2D platformCollider;
    private bool currentlyFallingThrough = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerRigidBody = player.GetComponent<Rigidbody2D>();
        playerCollider = player.GetComponent<Collider2D>();
        platformCollider = gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerRigidBody.velocity.y > 0 || player.GetComponent<PlayerController>().getPlatformFall() || currentlyFallingThrough)
        {
            Physics2D.IgnoreCollision(playerCollider, platformCollider, true);

            if (player.GetComponent<PlayerController>().getPlatformFall())
            {
                currentlyFallingThrough = true;
            }

        } else if (!currentlyFallingThrough)
        {
            Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
        }

        if(currentlyFallingThrough)
        {
            if (DetectOverlapArea())
            {
                currentlyFallingThrough = true;
            } else
            {
                currentlyFallingThrough = false;
            }
        }
    }

    bool DetectOverlapArea()
    {
        // Get the bounds of the platform
        Bounds platformBounds = platformCollider.bounds;
        // Get the bounds of the player
        Bounds playerBounds = playerCollider.bounds;

        // Check if the bounds intersect
        if (platformBounds.Intersects(playerBounds))
        {
            // Calculate the intersection area
            float intersectionWidth = Mathf.Min(platformBounds.max.x, playerBounds.max.x) - Mathf.Max(platformBounds.min.x, playerBounds.min.x);
            float intersectionHeight = Mathf.Min(platformBounds.max.y, playerBounds.max.y) - Mathf.Max(platformBounds.min.y, playerBounds.min.y);

            // Ensure that the intersection area is greater than zero
            if (intersectionWidth > 0 && intersectionHeight > 0)
            {
                return true;
            }
        }

        return false;
    }
}
