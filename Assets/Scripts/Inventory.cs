using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public GameObject inventorySlot;
    public List<InventoryItem> slots;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateInventory(Slot item, int slot) {
        var currentItem = slots[slot];
        currentItem.currentAmount = item.currentAmount;
        currentItem.gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = item.sprite;
        currentItem.gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().color = Color.white;
        currentItem.gameObject.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = item.currentAmount.ToString();
    }

    public void LoadInventory(int inventorySize) {

        double w = Screen.width;
        double h = Screen.height;
        int x = 0;
        int y = 0;
        for (int i = 0; i < inventorySize; i++) {
            GameObject j = Instantiate(inventorySlot, transform);
            if (40 * (x + 1) < w * 0.336) {
                j.transform.position += new Vector3(40 * x, 40 * y);
                x++;
            }
            else {
                x = 0;
                y--;
                j.transform.position += new Vector3(40 * x, 40 * y);
                x++;
            }
        }
    }
}
