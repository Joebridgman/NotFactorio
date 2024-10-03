using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {

    public GameObject boulder;
    public float laserCooldown = 0.5f;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        
        laserCooldown -= Time.deltaTime;
        
        if (laserCooldown < 0) {
            laserCooldown = 0;
        }

        if (Input.GetKey(KeyCode.Space) && laserCooldown == 0 && boulder != null) {
            Mine();
            laserCooldown = 0.5f;
        }
    }

    void Mine() {
        if (boulder.GetComponent<Boulder>().health <= 0) {
            boulder = null;
        }
        boulder.GetComponent<Boulder>().health -= 25;
        Debug.Log("Boulder health: " + boulder.GetComponent<Boulder>().health);       
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Boulder") {
            boulder = collision.gameObject;
        }
    }
}
