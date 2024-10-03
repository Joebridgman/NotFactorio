using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : Mineable {

    public GameObject stonePickupObject;

    public Boulder() {
        health = 100;
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (health <= 0) {
            Instantiate(stonePickupObject, gameObject.transform.position, new Quaternion());
            Destroy(gameObject);
        }
    }
}
