using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {

    public int inventorySize;
    public List<GameObject> slots;
    public List<GameObject> pickupQueue;
    public float queueCooldown = 0.1f;
    private bool isFull = false;
    private int nextEmpty = -1;


    // Start is called before the first frame update
    void Start() {
        GameObject empty = new GameObject();
        for (int i = 0; i < inventorySize; i++) {
            slots.Add(empty);
        }
    }

    // Update is called once per frame
    void Update() {
        if (isFull) {
            queueCooldown -= Time.deltaTime;

        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Pickup") {
            FindNextEmpty();
            if (nextEmpty >= 0) {
                slots[nextEmpty] = collision.gameObject.GetComponent<Pickup>().inventoryObject;
                Destroy(collision.gameObject);
            }
            else {
                pickupQueue.Add(collision.gameObject);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Pickup") {
            pickupQueue.Remove(collision.gameObject);
        }
    }

    void FindNextEmpty() {

        for (int i = 0; i < slots.Count; i++) {
            if (slots[i].tag != "InventoryItem") {
                isFull = false;
                nextEmpty = i;
                return;
            }
        }
        isFull = true;
        nextEmpty = -1;
    }
}
