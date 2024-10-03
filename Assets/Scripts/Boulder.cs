using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour {

    public int health = 100;
    public GameObject stonePickupObject;
    public bool isInRange = false;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (health <= 0) {
            Instantiate(stonePickupObject, transform);
            Destroy(this);
        }
    }
}
