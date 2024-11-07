using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Boulder : Mineable {

    public GameObject stonePickupObject;

    public Boulder() {
        MaxHealth = 100;
        Health = MaxHealth;
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        if (Health <= 0) {
            int stoneDrops = Random.Range(5, 11);
            List<GameObject> stones = new List<GameObject>();
            for (int i = 0; i < stoneDrops; i++) {
                stones.Add(Instantiate(stonePickupObject, gameObject.transform.position, new Quaternion()));
            }
            DropExplosion(stones);
            turnOffParticles();
            Destroy(gameObject);
        }
    }
}


