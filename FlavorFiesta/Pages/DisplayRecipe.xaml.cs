using FlavorFiesta.BusinessLogic;

namespace FlavorFiesta.Pages
{
    public partial class DisplayRecipe : ContentPage
    {
        private Recipe chosenRecipe;

        // THIS FILE WAS MADE AND EDITED BY HARSHETA SHARMA
        public DisplayRecipe(Recipe selectedRecipe)
        {
            InitializeComponent();

            try
            {
                // Store the selected recipe
                chosenRecipe = selectedRecipe;

                // If somehow null was passed, avoid crash
                if (chosenRecipe == null)
                {
                    RecipeName.Text = "Recipe not found";
                    RecipeURL.Text = "N/A";
                    ChosenRecipeImage.Source = "placeholder.png"; // optional fallback
                    return;
                }

                // Set UI values
                RecipeName.Text = chosenRecipe.Name ?? "Unknown Recipe";
                RecipeURL.Text = chosenRecipe.RecipeURL ?? "No URL available";

                // Load image safely
                if (!string.IsNullOrWhiteSpace(chosenRecipe.RecipeImage))
                {
                    ChosenRecipeImage.Source = chosenRecipe.RecipeImage;
                }
                else
                {
                    ChosenRecipeImage.Source = "placeholder.png"; // fallback
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred in DisplayRecipe constructor: " + ex.Message);
                DisplayAlert("Error", "Failed to load recipe details.", "OK");
            }
        }

        private void OnExit(object sender, EventArgs e)
        {
            // Exit the MAUI application completely
            System.Environment.Exit(0);
            // Source: https://stackoverflow.com/questions/692323/when-should-one-use-environment-exit-to-terminate-a-console-application
        }
    }
}
