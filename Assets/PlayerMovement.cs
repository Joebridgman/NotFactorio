using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * 100);
        }
        if (Input.GetKey(KeyCode.S))
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * -100);
        }
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().AddForce(transform.right * 100);
        }
        if(Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().AddForce(transform.right * -100);
        }
    }
}
