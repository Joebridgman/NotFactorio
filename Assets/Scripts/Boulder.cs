using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Boulder : Mineable {

    public GameObject stonePickupObject;
    public GameObject healthBar;
    GameObject activeParticles;
    public GameObject particlesPrefab;
    public GameObject particlesTarget;
    public bool isParticlesOn = false;

    public Boulder() {
        health = 100;
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        if(health < 100) {
            healthBar.SetActive(true);
        }

        if(health <= 75 && health > 35) {
            healthBar.GetComponent<SpriteRenderer>().color = Color.yellow;
        } else if(health <= 35) {
            healthBar.GetComponent<SpriteRenderer>().color = Color.red;
        }

        if (health <= 0) {
            Instantiate(stonePickupObject, gameObject.transform.position, new Quaternion());
            Destroy(activeParticles);
            isParticlesOn = false;
            Destroy(gameObject);
        }

        if(isParticlesOn) {
            activeParticles.GetComponent<Particles>().particlesTarget = this.particlesTarget.transform.position
                ;
        }
    }

    public void Mine() {
        health -= 5;

        healthBar.transform.localScale = new Vector3(4.25f * ((float)health / 100), healthBar.transform.localScale.y, healthBar.transform.localScale.z);
        Debug.Log("Mineable health: " + health);
    }

    public void turnOnParticles() {
        isParticlesOn = true;
        activeParticles = Instantiate(particlesPrefab, transform.position, Quaternion.identity);

    }
    public void turnOffParticles() {
        isParticlesOn = false;
        Destroy(activeParticles);
    }
}


