using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cupa : MonoBehaviour
{
    public float vel;
   
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(1 * vel, rb.velocity.y, 0);

        if (this.transform.position.x > -60)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            vel = vel * -1;
        }

            if (collision.gameObject.CompareTag("Player") && Controller_Player.onFloor == true)
        {
            GameManager.gameOver = true;
        }
        if (collision.gameObject.CompareTag("Player") && Controller_Player.onFloor == false)
        {
            Destroy(this.gameObject);
            Controller_Player.onFloor = true;
        }
    }

}
