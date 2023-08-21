using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingManager : MonoBehaviour {
    private PlayerInventory playerInventory;
    [SerializeField] private Button craftButton, backButton;
    [SerializeField] private GameObject itemContainer;
    [SerializeField] private InventorySlot potionSlot;
    public int rows = 2;
    public int columns = 2;

    private Item[] items = new Item[4];
    private InventorySlot[] itemSlots = new InventorySlot[4];
    private Recipe activeRecipe;

    private bool readyForEnable = false;

    private void Awake() {
        craftButton.onClick.AddListener(Craft);
        backButton.onClick.AddListener(Back);
        CraftingToggle.ToggleCrafting += ToggleCraftingUI;
    }

    private void Start() {
        playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
        for (int i = 0; i < itemContainer.transform.childCount; i++)
        {
            itemSlots[i] = itemContainer.transform.GetChild(i).GetComponent<InventorySlot>();
        }

        gameObject.SetActive(false);
        readyForEnable = true;
    }

    private void OnEnable() {
        Time.timeScale = 0;
        if (readyForEnable) SetBlanks();
        // FillTable();
        
    }

    private void OnDisable() {
        Time.timeScale = 1;
    }

    private void FillTable()
    {
        int i = 0;

        while (i < rows)
        {
            items[i] = InventoryItemList.GetInstance().GetItem("Red Paint");
            itemSlots[i].GetComponent<InventorySlot>().Initialize(items[i]);
            i++;
        }

        while (i < rows + columns)
        {
            items[i] = InventoryItemList.GetInstance().GetItem("Glass Shard");
            itemSlots[i].GetComponent<InventorySlot>().Initialize(items[i]);
            i++;
        }

        activeRecipe = RecipeList.GetInstance().GetRecipe(items);
        potionSlot.Initialize(activeRecipe.potion);
    }

    private void SetBlanks()
    {
        foreach (InventorySlot inventorySlot in itemSlots)
        {
            inventorySlot.Reset();
        }

        potionSlot.Reset();
    }

    private void Craft()
    {
        if (potionSlot.inventoryItem != null)
        {
            
            // foreach (Item item in items) playerInventory.RemoveFromInventory(item);

            playerInventory.AddToInventory(potionSlot.inventoryItem);

            SetBlanks();

            
        }
    }

    public void AddToTable(InventoryItem e)
    {

    }

    private void ToggleCraftingUI()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    private void Back()
    {
        gameObject.SetActive(false);
    }
}