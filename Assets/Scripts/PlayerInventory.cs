using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerInventory : MonoBehaviour {

    public int inventorySize;
    public List<InventoryItem> slots;
    public List<GameObject> pickupQueue;
    public Toolbar toolbar;
    public float queueCooldown = 0.1f;
    private bool isFull = false;


    // Start is called before the first frame update
    void Start() {
        slots = new List<InventoryItem>();
        for (int i = 0; i < inventorySize; i++) {
            var emptyItem = gameObject.AddComponent<InventoryItem>();
            slots.Add(emptyItem);
        }
    }

    // Update is called once per frame
    void Update() {
        if (isFull) {
            queueCooldown -= Time.deltaTime;

        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        var inventoryItem = collision.gameObject.GetComponent<Pickup>().inventoryObject.GetComponent<InventoryItem>();
        if (collision.tag == "Pickup") {
            for (int i = 0; i < slots.Count; i++) {
                if (slots[i].id == 0) {
                    slots[i] = inventoryItem;
                    slots[i].currentAmount = 1;
                    Destroy(collision.gameObject);
                    isFull = false;

                    toolbar.UpdateSlots(slots[i], i);
                    Debug.Log(slots[i] + " " + slots[i].currentAmount);
                    return;
                }
                else if (inventoryItem.id == slots[i].id) {
                    if (slots[i].currentAmount + 1 <= slots[i].maxStack) {
                        slots[i].currentAmount += 1;
                        Destroy(collision.gameObject);
                        isFull = false;
                        toolbar.UpdateSlots(slots[i], i);
                        Debug.Log(slots[i] + " " + slots[i].currentAmount);
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