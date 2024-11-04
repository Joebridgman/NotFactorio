using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerInventory : MonoBehaviour {

    public int inventorySize;
    public List<InventorySlot> slots;
    public List<GameObject> pickupQueue;
    public float queueCooldown = 0.1f;
    private bool isFull = false;


    // Start is called before the first frame update
    void Start() {
        slots = new List<InventorySlot>();
        for (int i = 0; i < inventorySize; i++) {
            slots.Add(new InventorySlot(gameObject));
        }
    }

    // Update is called once per frame
    void Update() {
        if (isFull) {
            queueCooldown -= Time.deltaTime;

        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        var inventoryObject = collision.gameObject.GetComponent<Pickup>().inventoryObject;
        var inventoryItem = inventoryObject.GetComponent<InventoryItem>();
        var objectId = inventoryItem.id;
        if (collision.tag == "Pickup") {
            foreach (InventorySlot slot in slots) {
                if (slot.gameObject.tag != "InventoryItem") {
                    slot.gameObject = inventoryObject;
                    slot.amount = 1;
                    Destroy(collision.gameObject);
                    isFull = false;

                    Debug.Log(slot.gameObject + " " + slot.amount);
                    return;
                }
                else if (objectId == slot.gameObject.GetComponent<InventoryItem>().id) {
                    if (slot.amount + 1 <= inventoryObject.GetComponent<InventoryItem>().maxStack) {
                        slot.amount += 1;
                        Destroy(collision.gameObject);
                        isFull = false;

                        Debug.Log(slot.gameObject + " " + slot.amount);
                        return;
                    }
                }
                isFull = true;
            }
            pickupQueue.Add(collision.gameObject);         
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Pickup") {
            pickupQueue.Remove(collision.gameObject);
        }
    }
}

public class InventorySlot {

    public int amount { get; set; }
    public GameObject gameObject { get; set; }

    public InventorySlot(GameObject parent) { 
        amount = 0;
        gameObject = new GameObject("Empty slot");
        gameObject.transform.parent = parent.transform;
    }

    public InventorySlot(GameObject gameObject, int amount) {
        this.amount = amount;
        this.gameObject = gameObject;
    }
}