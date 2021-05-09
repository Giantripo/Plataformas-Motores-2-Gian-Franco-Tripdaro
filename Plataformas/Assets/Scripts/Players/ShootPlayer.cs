using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : Controller_Player
{

    private int jumpCounter = 0;


    public float velDisparo;
    public Rigidbody balaPrefab;
    public Transform disparador;
    private Rigidbody balaImpulso;
    
    
    

    public override bool IsOnSomething()
    {
        return Physics.BoxCast(transform.position, new Vector3(transform.localScale.x * 0.9f, transform.localScale.y / 3, transform.localScale.z * 0.9f), Vector3.down, out downHit, Quaternion.identity, downDistanceRay);
    }

    public override void Jump()
    {
        if (IsOnSomething())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //instancia el prefab en una posicion determinada
                balaImpulso = Instantiate(balaPrefab, disparador.position, Quaternion.identity);
                //le añade una fuerza al prefab para que sea disparado
                balaImpulso.AddForce(-disparador.forward * 100 * velDisparo);

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
