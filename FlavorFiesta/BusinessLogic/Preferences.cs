using System;

namespace FlavorFiesta.BusinessLogic
{
    /// <summary>
    /// Represents user preferences for dietary and culinary choices.
    /// </summary>
    public class Preferences
    {
        #region Fields
        private string _dietType;
        private string _cuisineType;
        private string _mealType;
        private string _caloriesRange;
        private string _prepTimeRange;
        private string _cookTimeRange;
        private string _servingsRange;
        private string _totalTimeRange;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor aligned with the CSV columns in recipes.txt.
        /// </summary>
        public Preferences(
            string dietType,
            string cuisineType,
            string mealType,
            string caloriesRange,
            string prepTimeRange,
            string cookTimeRange,
            string servingsRange,
            string totalTimeRange)
        {
            DietType = ValidateInput(dietType, nameof(DietType));
            CuisineType = ValidateInput(cuisineType, nameof(CuisineType));
            MealType = ValidateInput(mealType, nameof(MealType));
            CaloriesRange = ValidateInput(caloriesRange, nameof(CaloriesRange));
            PrepTimeRange = ValidateInput(prepTimeRange, nameof(PrepTimeRange));
            CookTimeRange = ValidateInput(cookTimeRange, nameof(CookTimeRange));
            ServingsRange = ValidateInput(servingsRange, nameof(ServingsRange));
            TotalTimeRange = ValidateInput(totalTimeRange, nameof(TotalTimeRange));
        }
        #endregion

        #region Properties
        public string DietType
        {
            get => _dietType;
            set => _dietType = ValidateInput(value, nameof(DietType));
        }

        public string CuisineType
        {
            get => _cuisineType;
            set => _cuisineType = ValidateInput(value, nameof(CuisineType));
        }

        public string MealType
        {
            get => _mealType;
            set => _mealType = ValidateInput(value, nameof(MealType));
        }

        public string CaloriesRange
        {
            get => _caloriesRange;
            set => _caloriesRange = ValidateInput(value, nameof(CaloriesRange));
        }

        public string PrepTimeRange
        {
            get => _prepTimeRange;
            set => _prepTimeRange = ValidateInput(value, nameof(PrepTimeRange));
        }

        public string CookTimeRange
        {
            get => _cookTimeRange;
            set => _cookTimeRange = ValidateInput(value, nameof(CookTimeRange));
        }

        public string ServingsRange
        {
            get => _servingsRange;
            set => _servingsRange = ValidateInput(value, nameof(ServingsRange));
        }

        public string TotalTimeRange
        {
            get => _totalTimeRange;
            set => _totalTimeRange = ValidateInput(value, nameof(TotalTimeRange));
        }
        #endregion

        #region Methods
        private static string ValidateInput(string value, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException($"{propertyName} cannot be null or whitespace.", propertyName);

            return value.Trim(); // IMPORTANT: trims trailing CSV spaces
        }
        #endregion
    }
}
