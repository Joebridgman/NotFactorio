using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Toolbar : MonoBehaviour {

    public List<InventoryItem> slots;
    public void UpdateSlots(Slot item, int slot) {
        var currentItem = slots[slot];
        currentItem.currentAmount = item.currentAmount;
        currentItem.gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = item.sprite;
        currentItem.gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().color = Color.white;
        currentItem.gameObject.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = item.currentAmount.ToString();
    }
}
