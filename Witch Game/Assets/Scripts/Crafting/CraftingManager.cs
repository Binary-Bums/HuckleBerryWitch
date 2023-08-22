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
        SetBlanks();
    }

    private void OnEnable() {
        Time.timeScale = 0;
    }

    private void OnDisable() {
        Time.timeScale = 1;
    }

    private void SetBlanks()
    {
        foreach (CraftingItemSlot slot in itemSlots)
        {
            slot.Clear();
        }

        potionSlot.Clear();
    }

    private void Craft()
    {
        for(int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].inventoryItem == null) return;

            items[i] = InventoryItemList.GetInstance().GetItem(itemSlots[i].inventoryItem.id);
        }
        activeRecipe = RecipeList.GetInstance().GetRecipe(items);
        

        if (activeRecipe != null)
        {
            potionSlot.Initialize(activeRecipe.potion);

            foreach (CraftingItemSlot slot in itemSlots)
            {
                slot.Clear();
            }
        }
    }

    private void ToggleCraftingUI()
    {
        if (gameObject.activeSelf) ClickedItem.Instance.Reset();
        gameObject.SetActive(!gameObject.activeSelf);
    }

    private void Back()
    {
        ClickedItem.Instance.Reset();
        gameObject.SetActive(false);
    }
}