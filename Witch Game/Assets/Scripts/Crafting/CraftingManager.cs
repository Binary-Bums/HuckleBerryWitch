using System.Collections.Generic;
using UnityEngine;

public class CraftingManager : MonoBehaviour {
    private PlayerInventory playerInventory;
    public GameObject slot, itemContainer;
    public int rows = 2;
    public int columns = 2;

    private void Start() {
        for (int i = 0; i < rows * columns; i++)
        {
            GameObject square = Instantiate(slot, itemContainer.transform);
            
        }
    }
}