using System.Collections.Generic;

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

    // public Recipe GetRecipe(string key)
    // {
    //     if (recipeList.ContainsKey(key)) return recipeList[key];

    //     else return null;
    // }

    private void FillDictionary()
    {


        recipeList = new List<Recipe>()
        {
            HealthPotion()
        };
    }

    private Recipe HealthPotion()
    {
        Item glass = EquippableList.GetInstance().GetItem("Glass Shard");
        Item paint = EquippableList.GetInstance().GetItem("Red Paint");

        return FormRecipe(paint, paint, glass, glass, EquippableList.GetInstance().GetPotion("Health Potion"));
    }

    private Recipe FormRecipe(Item i1, Item i2, Item i3, Item i4, Potion potion)
    {
        Item[] items = {i1, i2, i3, i4};

        return new Recipe(items, potion);
    }
}