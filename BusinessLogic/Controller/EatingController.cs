using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using BusinessLogic.Model;

namespace BusinessLogic.Controller
{
    public class EatingController : ControllerBase
    {
        private readonly User _user;
        public List<Food> Foods { get; }
        public Eating Eating { get; }
        public EatingController(User user)
        {
            this._user = user ?? throw new ArgumentNullException
                            ("Пользователь не может быть пустым.", nameof(user));
            Foods = GetAllFoods();
            Eating = GetEating();
        }
        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if (product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();
            }
            else
            {
                Eating.Add(product, weight);
                Save();
            }
        }
        private Eating GetEating()
        {
            return Load<Eating>().FirstOrDefault() ?? new Eating(_user);
        }

        private List<Food> GetAllFoods()
        {
            return Load<Food>() ?? new List<Food>();
        }

        private void Save()
        {
            Save(Foods);
            Save(new List<Eating>() {Eating});
        }
    }
}