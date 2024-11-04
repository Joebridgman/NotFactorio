using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Boulder : Mineable {

    public GameObject stonePickupObject;
    GameObject activeParticles;
    public GameObject particlesPrefab;
    public GameObject particlesTarget;
    public bool isParticlesOn = false;

    public Boulder() {
        maxHealth = 100;
        health = maxHealth;
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        if (health <= 0) {
            int stoneDrops = Random.Range(5, 11);
            List<GameObject> stones = new List<GameObject>();
            for (int i = 0; i < stoneDrops; i++) {
                stones.Add(Instantiate(stonePickupObject, gameObject.transform.position, new Quaternion()));
            }
            DropExplosion(stones);
            Destroy(activeParticles);
            isParticlesOn = false;
            Destroy(gameObject);
        }

        if(isParticlesOn) {
            activeParticles.GetComponent<Particles>().particlesTarget = this.particlesTarget.transform.position;
        }
    }

    public void Mine() {
        health -= 5;
        AdjustHealthBar();
       
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


