using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingManager : MonoBehaviour {
    private PlayerInventory playerInventory;
    [SerializeField] private Button craftButton, backButton;
    [SerializeField] private GameObject slot, itemContainer;
    public int rows = 2;
    public int columns = 2;
    public Sprite sprite;

    private Item[] items = new Item[4];
    private GameObject[] slots = new GameObject[4];

    private void Start() {
        playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
        craftButton.onClick.AddListener(Craft);
        backButton.onClick.AddListener(Back);

    }

    private void OnEnable() {
        SetBlanks();
        FillTable();
    }

    private void FillTable()
    {
        int i = 0;

        while (i < rows)
        {
            items[i] = EquippableList.GetInstance().GetItem("Red Paint");
            slots[i].GetComponent<InventorySlot>().Initialize(items[i], sprite);
            Debug.Log(items[i].id);
            i++;
        }

        while (i < rows + columns)
        {
            items[i] = EquippableList.GetInstance().GetItem("Glass Shard");
            slots[i].GetComponent<InventorySlot>().Initialize(items[i], sprite);
            Debug.Log(items[i].id);
            i++;
        }
    }

    private void SetBlanks()
    {
        
        for (int i = 0; i < itemContainer.transform.childCount; i++)
        {
            Destroy(itemContainer.transform.GetChild(i).gameObject);
            items[i] = null;
        }

        for (int i = 0; i < rows * columns; i++)
        {
            GameObject square = Instantiate(slot, itemContainer.transform);
            slots[i] = square;
        }
    }

    private void Craft()
    {
        Recipe recipe = RecipeList.GetInstance().GetRecipe(items);

        Debug.Log(recipe + " " + items);

        if (recipe != null)
        {
            
            foreach (Item item in items) playerInventory.RemoveFromInventory(item);

            playerInventory.AddToInventory(recipe.potion, sprite);

            SetBlanks();

            
        }
    }

    public void AddToTable(Equippable e)
    {

    }

    private void Back()
    {
        gameObject.SetActive(false);
    }
}