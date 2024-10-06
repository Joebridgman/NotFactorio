using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {

    public GameObject target;
    public List<GameObject> mineables;
    public float laserCooldown = 1.0f;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        transform.parent.gameObject.GetComponent<Animator>().SetBool("IsMining", false);
        laserCooldown -= Time.deltaTime;

        if (mineables.Count != 0) {
            target = mineables[0];

            if (target != null) {
                target.GetComponent<SpriteRenderer>().color = Color.green;
            }

            if (laserCooldown < 0) {
                laserCooldown = 0;
            }

            if (Input.GetKey(KeyCode.Space) && target != null) {

                if(!target.GetComponent<Boulder>().isParticlesOn) {
                    target.GetComponent<Boulder>().particlesTarget = gameObject;
                    target.GetComponent<Boulder>().turnOnParticles();
                }
                
                transform.parent.gameObject.GetComponent<Animator>().SetBool("IsMining", true);

                if(laserCooldown == 0) {
                    target.GetComponent<Boulder>().Mine();
                    laserCooldown = 1.0f;
                }
            } else {
                target.GetComponent<Boulder>().turnOffParticles();
            }
        }
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
