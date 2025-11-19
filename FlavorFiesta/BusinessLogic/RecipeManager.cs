using System;
using System.Collections.Generic;
using System.Linq;
using FlavorFiesta.DataPersistance;

namespace FlavorFiesta.BusinessLogic
{
    internal class RecipeManager
    {
        /// <summary>
        /// Searches the CSV recipe list for the first recipe that matches user preferences.
        /// </summary>
        public Recipe SearchRecipe(Preferences userPreferences, RecipeManagerDataPersistance csvAccess)
        {
            List<Recipe> recipes = csvAccess.ReadRecipesFromCSV();

            // Normalize the user's input preferences
            Preferences normalizedUser = NormalizePreferences(userPreferences);

            foreach (Recipe recipe in recipes)
            {
                Preferences normalizedRecipe = NormalizePreferences(recipe.RecipePreferences);

                if (ArePreferencesEqual(normalizedRecipe, normalizedUser))
                {
                    return recipe; // return first match
                }
            }

            return null; // no match found
        }

        /// <summary>
        /// Normalizes a Preferences object by trimming and converting to lowercase.
        /// </summary>
        private Preferences NormalizePreferences(Preferences p)
        {
            return new Preferences(
                p.DietType?.Trim().ToLower(),
                p.CuisineType?.Trim().ToLower(),
                p.MealType?.Trim().ToLower(),
                p.CaloriesRange?.Trim().ToLower(),
                p.PrepTimeRange?.Trim().ToLower(),
                p.CookTimeRange?.Trim().ToLower(),
                p.ServingsRange?.Trim().ToLower(),
                p.TotalTimeRange?.Trim().ToLower()
            );
        }

        /// <summary>
        /// Compares two preferences objects for exact equality.
        /// </summary>
        private bool ArePreferencesEqual(Preferences a, Preferences b)
        {
            return a.DietType == b.DietType &&
                   a.CuisineType == b.CuisineType &&
                   a.MealType == b.MealType &&
                   a.CaloriesRange == b.CaloriesRange &&
                   a.PrepTimeRange == b.PrepTimeRange &&
                   a.CookTimeRange == b.CookTimeRange &&
                   a.ServingsRange == b.ServingsRange &&
                   a.TotalTimeRange == b.TotalTimeRange;
        }
    }
}
