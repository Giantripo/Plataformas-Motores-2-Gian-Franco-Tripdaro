using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnfloorTrue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Floor"))
        {
           Controller_Player.onFloor = true;
        }

       
    }
}
