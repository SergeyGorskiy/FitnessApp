using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BusinessLogic.Controller
{
    public class SerializeDataSaver<T> : IDataSaver<T> where T:class
    {
        
        public void Save(T item)
        {
            var formatter = new BinaryFormatter();
            var fileName = typeof(T) + ".dat";
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, item);
            }
        }

        public List<T> Load()
        {
            var formatter = new BinaryFormatter();
            var fileName = typeof(T) + ".dat";
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is List<T> items)
                {
                    return items;
                }
                else
                {
                    return new List<T>();
                }
            }
        }
    }
}