using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingManager : MonoBehaviour {
    private PlayerInventory playerInventory;
    [SerializeField] private Button craftButton, backButton;
    [SerializeField] private GameObject itemContainer;
    [SerializeField] private CraftingPotionSlot potionSlot;
    public int rows = 2;
    public int columns = 2;

    private Item[] items = new Item[4];
    private CraftingItemSlot[] itemSlots = new CraftingItemSlot[4];
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
            itemSlots[i] = itemContainer.transform.GetChild(i).GetComponent<CraftingItemSlot>();
        }

        gameObject.SetActive(false);
        readyForEnable = true;
    }

    private void OnEnable() {
        Time.timeScale = 0;
        if (readyForEnable) SetBlanks();
    }

    private void OnDisable() {
        Time.timeScale = 1;
    }

    private void SetBlanks()
    {
        foreach (CraftingItemSlot slot in itemSlots)
        {
            slot.Reset();
        }

        potionSlot.Reset();
    }

    private void Craft()
    {
        for(int i = 0; i < itemSlots.Length; i++)
        {
            items[i] = InventoryItemList.GetInstance().GetItem(itemSlots[i].inventoryItem.id);
        }
        activeRecipe = RecipeList.GetInstance().GetRecipe(items);
        

        if (activeRecipe != null)
        {
            potionSlot.Initialize(activeRecipe.potion);

            foreach (CraftingItemSlot slot in itemSlots)
            {
                slot.Reset();
            }
        }
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