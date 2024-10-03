using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {

    public GameObject target;
    public List<GameObject> mineables;
    public float laserCooldown = 0.5f;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        
        laserCooldown -= Time.deltaTime;

        if (mineables.Count != 0) {
            target = mineables[0];

            if (target != null) {
                target.GetComponent<SpriteRenderer>().color = Color.green;
            }

            if (laserCooldown < 0) {
                laserCooldown = 0;
            }

            if (Input.GetKey(KeyCode.Space) && laserCooldown == 0 && target != null) {
                Mine();
                laserCooldown = 0.5f;
            }
        }
    }

    void Mine() {
        target.GetComponent<Mineable>().health -= 25;
        Debug.Log("Mineable health: " + target.GetComponent<Mineable>().health);       
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Mineable") {
            mineables.Add(collision.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Mineable") {
            target.GetComponent<SpriteRenderer>().color = Color.white;
            target = null;
            mineables.Remove(collision.gameObject);
        }
    }
}
