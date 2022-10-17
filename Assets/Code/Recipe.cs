using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TOM.Core.RecipeManager
{
    [System.Serializable]
    public class Recipe
    {
        public string recipeTag;
        public List<Item> inputs;
        public List<Item >outputs;

    }
}
