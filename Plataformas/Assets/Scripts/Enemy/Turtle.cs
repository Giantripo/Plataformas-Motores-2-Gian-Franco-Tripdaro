using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour
{
   
    public Rigidbody balaPrefab;
    public Transform disparador;
    public float cont;
    public float vel;
    private Rigidbody rb;
 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cont = 1;
        transform.Rotate(new Vector3(0, 90, 0));
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(1 * vel, rb.velocity.y, 0);

        cont -= Time.deltaTime;

        if (cont < 0)
        {
           
            //instancia el prefab en una posicion determinada
            Instantiate(balaPrefab, disparador.position, Quaternion.identity);
            //le añade una fuerza al prefab para que sea disparado
            
           
            cont = 3;
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
        }
    }
}
