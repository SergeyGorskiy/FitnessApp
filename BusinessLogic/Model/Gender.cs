using System;

namespace BusinessLogic.Model
{
    [Serializable]
    public class Gender
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пола не может быть пустым или null ", nameof(name));
            }
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}