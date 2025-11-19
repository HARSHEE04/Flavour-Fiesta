using System;
using System.Collections.Generic;
using System.IO;
using FlavorFiesta.BusinessLogic;

namespace FlavorFiesta.DataPersistance
{
    // THIS FILE WAS MADE AND EDITED BY HARSHETA SHARMA
    internal class RecipeManagerDataPersistance
    {
        private string _filePath;

        public List<Recipe> ReadRecipesFromCSV()
        {
            _filePath = "C:/Users/Harsh/Downloads/recipes.txt";

            List<Recipe> list = new List<Recipe>();

            try
            {
                string[] lines = File.ReadAllLines(_filePath);

                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    string[] parts = line.Split(',');

                    // Skip invalid rows
                    if (parts.Length < 11)
                        continue;

                    // Trim everything
                    for (int i = 0; i < parts.Length; i++)
                        parts[i] = parts[i].Trim();

                    string name = parts[0];
                    string recipeImage = parts[1];
                    string recipeURL = parts[2];

                    // Create preferences (correct order!)
                    BusinessLogic.Preferences prefs = new BusinessLogic.Preferences(
                      parts[3],  // Diet
                      parts[4],  // Cuisine
                      parts[5],  // Meal
                      parts[6],  // Calories
                      parts[7],  // Prep time
                      parts[8],  // Cook time
                      parts[9],  // Servings
                      parts[10]  // Total time
                  );

                    Recipe recipe = new Recipe(name, recipeImage, recipeURL, prefs);
                    list.Add(recipe);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading recipes: " + ex.Message);
            }

            return list;
        }
    }
}
