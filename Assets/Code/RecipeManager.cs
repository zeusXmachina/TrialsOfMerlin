using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TOM.Core.RecipeManager
{
    public class RecipeManager : MonoBehaviour
    {

        /*
         Aim of this is to conatin a list of all recipes

         methods for checking and validating recipes 
          // should return output of recipe

        outputs required such as UI and Inventory capabilities 






         */


        public static RecipeManager instance;

        //array of all recipes
        //editor setup
        [SerializeField] private Recipe[] allRecipes;
        [SerializeField] private int inputMax;

        [SerializeField] private List<Item> setupIngredients;


        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
            }
            else
                instance = this;
        }


        public void TryRecipe(string tag, List<Item> ingredients ) 
        {
            if (ingredients.Count != 0)
            {

                for (int i = 0; i < allRecipes.Length; i++)
                {
                    if (allRecipes[i].recipeTag == tag)
                    {
                        //found the recipe using tag 
                        //test the recipe

                        bool[] flags = new bool[allRecipes[i].inputs.Count];

                        // ValidateRecipe(ingredients, allRecipes[i].inputs);
                        foreach (Item input in allRecipes[i].inputs)
                        {

                            if (ingredients.Contains(input))
                            {
                                flags[ingredients.IndexOf(input)] = true;
                                //check amount 
                                Debug.Log(allRecipes[i].recipeTag + " Created");
                            }
                            else
                            {
                                //receipe fails 
                                Debug.Log(allRecipes[i].recipeTag + " Recipe Failed");
                            }

                        }






                        break;
                    }
                    else
                    {

                        Debug.Log("No Recipe by that name exist, check the tag entered");
                    }
                }


                //could return a yeild 
            }
            else {
                Debug.Log("No Ingredients provided");
            
            }
        }

        public void ValidateRecipe( Item[] ingredients,  Item[] inputs )
        {
          
        
        
        }

        [ContextMenu("SetupRecipeDebug")]
        public void SetupRecipe() {
            TryRecipe("FirebaseBasic", setupIngredients);
        
        
        }



        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }






    }

}