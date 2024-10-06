using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    public int inventorySize;
    public List<GameObject> slots;
    

    // Start is called before the first frame update
    void Start()
    {
        GameObject empty = new GameObject();
        for (int i = 0; i < inventorySize; i++) {
            slots.Add(empty);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
