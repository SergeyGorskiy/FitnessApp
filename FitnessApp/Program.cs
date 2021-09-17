using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Controller;
using BusinessLogic.Model;
using FitnessApp.Languages;

namespace FitnessApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("ru-ru");
            var resourceManager = new ResourceManager
                ("FitnessApp.Languages.Messages", typeof(Program).Assembly);
            
            Console.WriteLine(resourceManager.GetString("Hello", culture));

            Console.WriteLine(resourceManager.GetString("EnterName", culture));
            var userName = Console.ReadLine();

            var userController = new UserController(userName);
            var eatingController = new EatingController(userController.CurrentUser);
            var exersiseController = new ExerciseController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.Write(resourceManager.GetString("EnterGender", culture));
                var gender = Console.ReadLine();

                var birthDate = ParseDateTime("дата рождения");
                var weight = ParseDouble("вес");
                var height = ParseDouble("рост");

                userController.SetNewUserData(gender, birthDate, weight, height);
            }
            Console.WriteLine(userController.CurrentUser);


            while (true)
            {
                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("E - ввести прием пищи.");
                Console.WriteLine("А - ввести упражнение");
                Console.WriteLine("Q - выход");
                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterEating();
                        eatingController.Add(foods.Food, foods.Weight);

                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t{item.Key} - {item.Value}");
                        }
                        break;
                    case ConsoleKey.A:
                        var exe = EnterExersise();
                        exersiseController.Add(exe.Activity, exe.Begin, exe.End);
                        foreach (var item in exersiseController.Exercises)
                        {
                            Console.WriteLine($"\t{item.Activity} с {item.Start.ToShortTimeString()} до {item.Finish.ToShortTimeString()}");
                        }
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }
                Console.ReadLine();
            }
        }

        private static (DateTime Begin, DateTime End, Activity Activity) EnterExersise()
        {
            Console.Write("Введите название упражнения: ");
            var name = Console.ReadLine();

            var energy = ParseDouble("расход энергии в минуту");
            var begin = ParseDateTime("начало упражнения");
            var end = ParseDateTime("окончание упражнения");

            var activity = new Activity(name, energy);
            return (begin, end, activity);
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("Введите имя продукта: ");
            var food = Console.ReadLine();

            var prots = ParseDouble("белки");
            var fats = ParseDouble("жиры");
            var carbo = ParseDouble("углеводы");
            var calories = ParseDouble("калорийность");
            var weight = ParseDouble("вес порции");

            var product = new Food(food, prots, fats, carbo, calories);
            
            return (Food: product, Weight: weight);
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Введите {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неверный формат поля {name}!");
                }
            }
        }
        private static DateTime ParseDateTime(string value)
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write($"Введите {value} (dd.mm.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Неверный формат {value}!");
                }
            }
            return birthDate;
        }
    }
}
