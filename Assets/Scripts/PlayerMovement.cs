using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Sprite up;
    public Sprite down;
    public Sprite left;
    public Sprite right;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void FixedUpdate() {
        if (Input.GetKey(KeyCode.W)) {
            GetComponent<Rigidbody2D>().AddForce(transform.up * 100);
            GetComponent<SpriteRenderer>().sprite = up;
        }
        if (Input.GetKey(KeyCode.S)) {
            GetComponent<Rigidbody2D>().AddForce(transform.up * -100);
            GetComponent<SpriteRenderer>().sprite = down;
        }
        if (Input.GetKey(KeyCode.D)) {
            GetComponent<Rigidbody2D>().AddForce(transform.right * 100);
            GetComponent<SpriteRenderer>().sprite = right;
        }
        if (Input.GetKey(KeyCode.A)) {
            GetComponent<Rigidbody2D>().AddForce(transform.right * -100);
            GetComponent<SpriteRenderer>().sprite = left;
        }
    }
}
