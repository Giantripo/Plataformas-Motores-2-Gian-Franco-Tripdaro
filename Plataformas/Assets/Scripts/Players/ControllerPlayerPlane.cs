using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayerPlane :  Controller_Player
{

    //public void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.W))
    //    {
    //        Jump();
    //        rb.useGravity = false;
    //    }
    //    if (Input.GetKeyDown(KeyCode.S))
    //    {
    //        rb.useGravity = true;
    //    }

    //}

    private int jumpCounter = 0;

    public override bool IsOnSomething()
    {
        return Physics.BoxCast(transform.position, new Vector3(transform.localScale.x * 0.9f, transform.localScale.y / 3, transform.localScale.z * 0.9f), Vector3.down, out downHit, Quaternion.identity, downDistanceRay);
    }

    public override void Jump()
    {
        if (IsOnSomething())
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                rb.useGravity = false;
                jumpCounter = 1;
                rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (jumpCounter > 0)
                {
                    rb.useGravity = true;
                    rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
                    jumpCounter--;
                }
            }
        }
    }
}
