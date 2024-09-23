using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Sprite up;
    private Sprite down;
    private Sprite left;
    private Sprite right;

    // Start is called before the first frame update
    void Start()
    {
        up = Resources.Load("up", typeof(Sprite)) as Sprite;
        down = Resources.Load("down", typeof(Sprite)) as Sprite;
        left = Resources.Load("left", typeof(Sprite)) as Sprite;
        right = Resources.Load("right", typeof(Sprite)) as Sprite;
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
            GetComponent<SpriteRenderer>().sprite = up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * -100);
            GetComponent<SpriteRenderer>().sprite = down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().AddForce(transform.right * 100);
            GetComponent<SpriteRenderer>().sprite = right;
        }
        if(Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().AddForce(transform.right * -100);
            GetComponent<SpriteRenderer>().sprite = left;
        }
    }
}
