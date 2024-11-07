using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolbar : MonoBehaviour {

    public List<InventoryItem> slots;
    public void UpdateSlots(InventoryItem item, int slot) {
        slots[slot].currentAmount = item.currentAmount;
        slots[slot].sprite = item.sprite;
    }
}
