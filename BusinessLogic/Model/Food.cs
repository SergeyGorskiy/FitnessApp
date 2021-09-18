using System;

namespace BusinessLogic.Model
{
    [Serializable]
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Proteins { get; set; }
        public double Fats { get; set; }
        public double Carbohydrates { get; set; }
        public double Calories { get; set; }
        private double CaloriesOnGram => Calories / 100.0;
        private double ProteinsOnGram => Proteins / 100.0;
        private double FatsOnGram => Fats / 100.0;
        private double CarbohydratesOnGram => Carbohydrates / 100.0;

        public Food(string name) : this(name, 0,0,0,0) { }

        public Food(string name, double proteins, double fats, double carbohydrates, double calories)
        {
            // todo: проверка
            Name = name;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
            Calories = calories / 100.0;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}