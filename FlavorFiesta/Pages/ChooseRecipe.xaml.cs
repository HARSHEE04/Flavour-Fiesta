using System.Diagnostics;
using FlavorFiesta.BusinessLogic;
using FlavorFiesta.DataPersistance;
namespace FlavorFiesta.Pages;

public partial class ChooseRecipe : ContentPage
{
    //THIS FILE WAS MADE BY HARSHETA SHARMA AND EDITED BY HARSHETA SHARMA AND MARYAM E
    private RecipeManager _recipeManager;
    private RecipeManagerDataPersistance _csvRecipes;

    private Recipe allMatchingRecipes;
    public ChooseRecipe(BusinessLogic.Preferences prefs)
    {
        InitializeComponent();

        Debug.WriteLine($"Received preferences: DietType={prefs.DietType}, CuisineType={prefs.CuisineType}, RecipeType={prefs.MealType}");

        _recipeManager = new RecipeManager();
        _csvRecipes = new RecipeManagerDataPersistance();

        try
        {
            allMatchingRecipes = _recipeManager.SearchRecipe(prefs, _csvRecipes);

            if (allMatchingRecipes == null)
            {
                DisplayAlert("No Results", "No recipes matched your preferences.", "OK");
                return;
            }

            // Now it's safe to assign BindingContext
            BindingContext = allMatchingRecipes;

            Recipe1Name.Text = allMatchingRecipes.Name;
            RecipeImage.Source = allMatchingRecipes.RecipeImage;
            Recipe1PrepTme.Text = $"The Prep time for this is: {allMatchingRecipes.RecipePreferences.PrepTimeRange} minutes";
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error searching recipes: {ex.Message}");
            DisplayAlert("Error", "Failed to retrieve recipes.", "OK");
        }
    }


    private void OnMoreInfo(object sender, EventArgs e)
    {
        Navigation.PushAsync(new DisplayRecipe(allMatchingRecipes));
    }
}