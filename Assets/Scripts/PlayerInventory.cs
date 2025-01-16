using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerInventory : MonoBehaviour {

    public int inventorySize;
    public List<Slot> slots;
    public List<GameObject> pickupQueue;
    public Toolbar toolbar;
    public float queueCooldown = 0.1f;
    private bool isFull = false;
    public Inventory inventory;


    // Start is called before the first frame update
    void Start() {
        slots = new List<Slot>();
        for (int i = 0; i < inventorySize; i++) {
            slots.Add(new Slot());
        }
        inventory.LoadInventory(inventorySize);
    }

    // Update is called once per frame
    void Update() {
        if (isFull) {
            queueCooldown -= Time.deltaTime;

        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Pickup") {
            var inventoryItem = collision.gameObject.GetComponent<Pickup>().inventoryObject.GetComponent<InventoryItem>();
            for (int i = 0; i < slots.Count; i++) {
                if (slots[i].id == 0) {
                    slots[i] = new Slot(inventoryItem.id, 1, inventoryItem.maxStack, inventoryItem.sprite);
                    Destroy(collision.gameObject);
                    isFull = false;

                    inventory.UpdateInventory(slots[i], i);
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

public class Slot {


    public int id;
    public int currentAmount;
    public int maxStack;
    public Sprite sprite;

    public Slot() {
        id = 0;
    }
    public Slot(int id, int currentAmount, int maxStack, Sprite sprite) {
        this.id = id;
        this.currentAmount = currentAmount;
        this.maxStack = maxStack;
        this.sprite = sprite;
    }
}