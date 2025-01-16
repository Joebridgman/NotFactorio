using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {

    public GameObject target;
    public float laserCooldown = 0.1f;

    // Start is called before the first frame update
    void Start() {
        target = null;
    }

    // Update is called once per frame
    void Update() {

        transform.gameObject.GetComponent<Animator>().SetBool("IsMining", false);
        laserCooldown -= Time.deltaTime;

        if (target != null) {

            if (laserCooldown < 0) {
                laserCooldown = 0;
            }

            if (Input.GetMouseButton(0)) {

                transform.gameObject.GetComponent<Animator>().SetBool("IsMining", true);
                if (laserCooldown == 0) {
                    if (!target.GetComponent<Mineable>().isParticlesOn) {
                        target.GetComponent<Mineable>().particlesTarget = gameObject;
                        target.GetComponent<Mineable>().turnOnParticles();
                    }
                    target.GetComponent<Mineable>().Mine();
                    laserCooldown = 0.1f;
                }
            }
            else {
                target.GetComponent<Mineable>().turnOffParticles();
            }
        }
    }
}
