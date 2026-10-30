namespace DiaryFood.Services
{
    public class CalculateService
    {
        public string Gender { get; set; }
        public string Goal { get; set; }
        public double Weight { get; set; }
        public int Height { get; set; }
        public int Age { get; set; }
        public double Activity { get; set; }
        public double Calories { get; set; }
        public double Protein { get; set; }
        public double Fat { get; set; }
        public double Carbs { get; set; }
        public double NormCalories { get; set; }
        public double NormProtein { get; set; }
        public double NormFat { get; set; }
        public double NormCarbs { get; set; }

        public CalculateService(string gender, string goal, double weight, int height, int age, double activity)
        {
            Gender = gender;
            Goal = goal;
            Weight = weight;
            Height = height;
            Activity = activity;
            Age = age;
        }
        //По формуле Маффлина
        public void CalculateMafSanZh()
        {
            double targetCalories;

            if (Gender == "Мужской")
            {
                targetCalories = ((10 * Weight) + (6.25 * Height) - (5 * Age) + 5) * Activity;

            }
            else
            {
                targetCalories = ((10 * Weight) + (6.25 * Height) - (5 * Age) - 161) * Activity;
            }
            NormCalories = targetCalories;
            CalculateNormBZY();
            CalculateKBZ(targetCalories);
        }

        //По формуле Бенедикта
        public void CalculateHarBened()
        {
            double targetCalories;

            if (Gender == "Мужской")
            {
                targetCalories = (66.5 + (13.75 * Weight) + (5.003 * Height) - (6.755 * Age)) * Activity;
            }
            else
            {
                targetCalories = (655.1 + (9.563 * Weight) + (1.850 * Height) - (4.676 * Age)) * Activity;
            }
            NormCalories = targetCalories;
            CalculateNormBZY();
            CalculateKBZ(targetCalories);
        }

        //Подсчет калорий в зависимости от цели
        private void CalculateKBZ(double targetCalories)
        {
            switch (Goal)
            {
                case "Похудение":
                    Calories = targetCalories - targetCalories * 0.15;
                    CalculateBZY(Calories);
                    break;
                case "Поддержание веса":
                    Calories = targetCalories;
                    CalculateBZY(Calories);
                    break;
                case "Набор веса":
                    Calories = targetCalories + targetCalories * 0.15;
                    CalculateBZY(Calories);
                    break;
            }
        }

        //Подсчет нормы КБЖУ
        private void CalculateNormBZY()
        {
            NormProtein = (NormCalories * 0.30) / 4;
            NormFat = (NormCalories * 0.30) / 9;
            NormCarbs = (NormCalories * 0.40) / 4;
        }
        //Подсчет нормы КБЖУ в зависимости от цели
        private void CalculateBZY(double Calories)
        {
            Protein = (Calories * 0.30) / 4;
            Fat = (Calories * 0.30) / 9;
            Carbs = (Calories * 0.40) / 4;
        }

    }
}
