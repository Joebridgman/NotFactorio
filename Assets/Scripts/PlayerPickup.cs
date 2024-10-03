using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerPickup : MonoBehaviour {

    public List<GameObject> pickups;
    public GameObject player;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        foreach (var pickup in pickups) {
            pickup.GetComponent<Rigidbody2D>().AddForce((pickup.GetComponent<Transform>().position - 
                                                        player.GetComponent<Transform>().position).normalized * -6);
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Pickup") {
            pickups.Add(collision.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Pickup") {
            pickups.Remove(collision.gameObject);
        }
    }
}
