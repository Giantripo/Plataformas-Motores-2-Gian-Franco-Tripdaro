using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiatorTurtle : MonoBehaviour
{
    public static bool coord =false;
    public GameObject turtle;
   public Transform instantiator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (coord)
        {
            coord = false;
            Instantiate(turtle, instantiator.position, Quaternion.identity);
        }
    }
}
