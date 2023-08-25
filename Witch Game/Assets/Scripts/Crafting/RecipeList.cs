using System.Collections.Generic;
using System.Linq;

public class RecipeList{
    private static RecipeList Instance;

    private List<Recipe> recipeList;

    private RecipeList()
    {
        FillDictionary();
    }

    public static RecipeList GetInstance()
    {
        Instance ??= new RecipeList();

        return Instance;
    }

    public Recipe GetRecipe(Item[] items)
    {
        foreach (Recipe recipe in recipeList)
        {
            if (recipe.items.SequenceEqual(items)) return recipe;
        }

        return null;
    }

    private void FillDictionary()
    {
        recipeList = new List<Recipe>()
        {
            HealthPotion(),
            SpeedPotion(),
            SpellPotion(),
        };
    }

    private Recipe HealthPotion()
    {
        Item glass = InventoryItemList.GetInstance().GetItem("Glass Shard");
        Item paint = InventoryItemList.GetInstance().GetItem("Red Paint");

        return FormRecipe(paint, paint, glass, glass, InventoryItemList.GetInstance().GetPotion("Health Potion"));
    }

    private Recipe SpeedPotion()
    {
        Item glass = InventoryItemList.GetInstance().GetItem("Glass Shard");
        Item paint = InventoryItemList.GetInstance().GetItem("Blue Paint");

        return FormRecipe(paint, paint, glass, glass, InventoryItemList.GetInstance().GetPotion("Speed Potion"));
    }

    private Recipe SpellPotion()
    {
        Item glass = InventoryItemList.GetInstance().GetItem("Glass Shard");
        Item redPaint = InventoryItemList.GetInstance().GetItem("Red Paint");
        Item bluePaint = InventoryItemList.GetInstance().GetItem("Blue Paint");

        return FormRecipe(redPaint, bluePaint, glass, glass, InventoryItemList.GetInstance().GetPotion("Spell Potion"));
    }

    private Recipe FormRecipe(Item i1, Item i2, Item i3, Item i4, Potion potion)
    {
        Item[] items = {i1, i2, i3, i4};

        return new Recipe(items, potion);
    }
}