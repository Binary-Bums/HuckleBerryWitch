using System.Collections.Generic;
using UnityEngine;

public class RecipeList : MonoBehaviour {
    // public static RecipeList Instance { get; private set; }

    [SerializeField] private List<Item> itemList;
    [SerializeField] private List<Potion> potionList;
    private List<string> itemKeys = new List<string>();
    private List<string> potionKeys = new List<string>();
    private IDictionary<string, Potion> potionDict;
    private List<Recipe> recipeList;
    

    private void Start() {
        foreach (Item i in itemList) itemKeys.Add(i.id);

        potionDict = new Dictionary<string, Potion>();

        foreach (Potion p in potionList)
        {
            potionKeys.Add(p.id);
            potionDict.Add(p.id, p);
        }

        FillList();
    }

    public List<Recipe> GetRecipes()
    { return recipeList; }

    private void FillList()
    {
        recipeList = new List<Recipe>()
        {
            HealthPotion(),
            SpellPotion(),
            SpeedPotion1(),
            SpeedPotion2(),
        };
    }

    private Recipe HealthPotion()
    {
        string[] items = {"Glass Shard", "Glass Shard", "Red Paint", "Red Paint"};
        
        return new Recipe(items, potionDict["Health Potion"]);
    }
    private Recipe SpellPotion()
    {
        string[] items = {"Glass Shard", "Glass Shard", "Blue Paint", "Blue Paint"};
        
        return new Recipe(items, potionDict["Spell Potion"]);
    }
    private Recipe SpeedPotion1()
    {
        string[] items = {"Glass Shard", "Glass Shard", "Red Paint", "Blue Paint"};
        
        return new Recipe(items, potionDict["Speed Potion"]);
    }
    private Recipe SpeedPotion2()
    {
        string[] items = {"Glass Shard", "Glass Shard", "Blue Paint", "Red Paint"};
        
        return new Recipe(items, potionDict["Speed Potion"]);
    }
}