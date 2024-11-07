using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public int id;
    public string displayName;
    public int maxStack;
    public int currentAmount;
    public Sprite sprite;

    public InventoryItem() { 
        id = 0;
        displayName = string.Empty;
    }
}
