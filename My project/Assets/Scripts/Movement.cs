using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    enum Direction
    {
        North, South, East, West
    }

    public float speed;

    private Rigidbody2D rb;

    private Direction movingDir;

    [SerializeField] bool movingHorizontally = false, canCheck = true;
    [SerializeField] LayerMask obstacleMask;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movingHorizontally)
        {
            if(Physics2D.Raycast(transform.position, Vector2.left, .6f, obstacleMask) || Physics2D.Raycast(transform.position, Vector2.right, .6f, obstacleMask))
            {
                canCheck = true;
            }
            else
            {
                canCheck = false;
            }
            
            if(Physics2D.Raycast(transform.position, Vector2.up, .6f, obstacleMask) || Physics2D.Raycast(transform.position, Vector2.down, .6f, obstacleMask))
            {
                canCheck = true;
            }
            else
            {
                canCheck = false;
            }
        }

        if (canCheck)
        {
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                rb.constraints = RigidbodyConstraints2D.FreezePositionY;
                movingHorizontally = true;

                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    movingDir = Direction.East;
                }
                else

                {
                    movingDir = Direction.West;
                }
            }
            else if(Input.GetAxisRaw("Vertical") != 0)

            {
                rb.constraints = RigidbodyConstraints2D.FreezePositionX;
                movingHorizontally = false;
            
                if (Input.GetAxisRaw("Vertical") > 0)
                {
                    movingDir = Direction.North;
                }
                else

                {
                    movingDir = Direction.South;
                }
            }
        }
    }

        private void FixedUpdate()
    {
        switch (movingDir)
        {
            case Direction.North:
                rb.velocity = new Vector2(0, speed * Time.fixedDeltaTime);   
                break;
            case Direction.South:
                rb.velocity = new Vector2(0, -speed * Time.fixedDeltaTime);   
                break;
            case Direction.East:
                rb.velocity = new Vector2(speed * Time.fixedDeltaTime, 0);   
                break;
            case Direction.West:
                rb.velocity = new Vector2(-speed * Time.fixedDeltaTime, 0);
                break;
            
        }
    }
}