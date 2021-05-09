using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisiblePlayer : Controller_Player
{
    private int jumpCounter = 0;
    
    

    public override bool IsOnSomething()
    {
        return Physics.BoxCast(transform.position, new Vector3(transform.localScale.x * 0.9f, transform.localScale.y / 3, transform.localScale.z * 0.9f), Vector3.down, out downHit, Quaternion.identity, downDistanceRay);
    }

    public override void Jump()
    {
        if (IsOnSomething())
        {
            Renderer rend = gameObject.GetComponent<Renderer>();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rend.enabled = false;

            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                rend.enabled = true;

            }

            if (Input.GetKeyDown(KeyCode.W))
            {
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
                    rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
                    jumpCounter--;
                }
            }
        }
    }
}
