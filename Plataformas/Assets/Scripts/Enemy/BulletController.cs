using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(new Vector3(0, 0, -90));
    }

    // Update is called once per frame
    void Update()
    {
        //if (this.transform.position.x > -60)
        //{
        //    Destroy(this.gameObject);
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Player") && Controller_Player.onFloor == true )
        {
            GameManager.gameOver = true;
        }
        if (collision.gameObject.CompareTag("Player") && Controller_Player.onFloor == false)
        {
            Destroy(this.gameObject);
            //Controller_Player.onFloor = true;
        }
    }
}
