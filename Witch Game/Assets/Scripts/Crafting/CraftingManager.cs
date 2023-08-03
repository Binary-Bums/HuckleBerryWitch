using System.Collections.Generic;
using UnityEngine;

public class CraftingManager : MonoBehaviour {
    private List<Recipe> recipeList;

    private void Start() {
        recipeList = GetComponent<RecipeList>().GetRecipes();
    }
}