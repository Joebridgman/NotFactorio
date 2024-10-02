using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Sprite up;
    public Sprite down;
    public Sprite left;
    public Sprite right;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        if (Input.GetKey(KeyCode.W)) {
            GetComponent<Rigidbody2D>().AddForce(transform.up * 100);
            GetComponent<SpriteRenderer>().sprite = up;
        }

        else if (Input.GetKey(KeyCode.S)) {
            GetComponent<Rigidbody2D>().AddForce(transform.up * -100);
            GetComponent<SpriteRenderer>().sprite = down;
        } 

        else if (Input.GetKey(KeyCode.D)) {
            GetComponent<Rigidbody2D>().AddForce(transform.right * 100);
            GetComponent<SpriteRenderer>().flipX = true;
            GetComponent<Animator>().SetBool("IsWalking", true);
            GetComponent<SpriteRenderer>().sprite = right;
        }

        else if (Input.GetKey(KeyCode.A)) {
            GetComponent<Rigidbody2D>().AddForce(transform.right * -100);
            GetComponent<SpriteRenderer>().flipX = false;
            GetComponent<Animator>().SetBool("IsWalking", true);
            GetComponent<SpriteRenderer>().sprite = left;
        }

        else {
            GetComponent<Animator>().SetBool("IsWalking", false);
        }

    }
}
